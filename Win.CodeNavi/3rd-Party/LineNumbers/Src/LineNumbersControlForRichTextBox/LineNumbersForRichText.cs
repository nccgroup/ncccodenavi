/*
 * (C) 2011 Anton Pototsky
 * Based on VB.NET project by nogChoco: http://www.codeproject.com/KB/cpp/linenumbers_for_rtb.aspx
 * Licensed under The Code Project Open License (CPOL): http://www.codeproject.com/info/cpol10.aspx
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LineNumbersControlForRichTextBox
{
	[DefaultProperty("ParentRichTextBox")]
	public class LineNumbersForRichText : Control
	{
		// Constants
#region Constants

		private const string DefaultLineNumbersFormat = "0";
		protected readonly char[] LineBreakCharacters = new[] { '\n', '\r' };
		private const int ScrollTimeoutTicks = 500000;

#endregion

		// Fields
#region Fields

		[AccessedThroughProperty("RTParent")]
		private RichTextBox pParent = null;
		[AccessedThroughProperty("Timer")]
		private Timer pTimer = null;
		private bool pAutoSizing = true;
		private Size pAutoSizingSize = new Size(0, 0);
		private Color pBorderLinesColor = Color.SlateGray;
		private bool pBorderLinesShow = true;
		private DashStyle pBorderLinesStyle = DashStyle.Dot;
		private float pBorderLinesThickness = 1f;
		private Rectangle pContentRectangle = new Rectangle();
		private LineNumberDockSide pDockSide = LineNumberDockSide.Left;
		private LinearGradientMode pGradientDirection = LinearGradientMode.Horizontal;
		private Color pGradientEndColor = Color.LightSteelBlue;
		private bool pGradientShow = true;
		private Color pGradientStartColor = Color.Transparent;
		private Color pGridLinesColor = Color.SlateGray;
		private bool pGridLinesShow = true;
		private DashStyle pGridLinesStyle = DashStyle.Dot;
		private float pGridLinesThickness = 1f;
		private ContentAlignment pLineNumbersAlignment = ContentAlignment.TopRight;
		private bool pLineNumbersAntiAlias = true;
		private bool pLineNumbersClipByItemRectangle = true;
		private string pLineNumbersFormat = DefaultLineNumbersFormat;
		private Size pLineNumbersOffset = new Size(0, 0);
		private bool pLineNumbersShow = true;
		private bool pLineNumbersShowAsHexadecimal = false;
		private bool pLineNumbersShowLeadingZeroes = true;
		private readonly List<LineNumberItem> pLineNumberItems = new List<LineNumberItem>();
		private Color pMarginLinesColor = Color.SlateGray;
		private bool pMarginLinesShow = true;
		private LineNumberDockSide pMarginLinesSide = LineNumberDockSide.Right;
		private DashStyle pMarginLinesStyle = DashStyle.Solid;
		private float pMarginLinesThickness = 1f;
		private int pParentInMe = 0;
		private bool pParentIsScrolling = false;
		private Point pPointInMe = new Point(0, 0);
		private Point pPointInParent = new Point(0, 0);
		private bool pSeeThroughMode = false;

#endregion

		// Methods
#region Methods

		public LineNumbersForRichText()
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			Margin = new Padding(0);
			Padding = new Padding(0, 0, 2, 0);
			Timer = new Timer { Enabled = false, Interval = 200 };
			UpdateSizeAndPosition();
			Invalidate();
		}

		private void FindStartIndex(ref int min, ref int max, ref int target)
		{
			// Recursive meyhod to compute best starting index - only run when pRTParent is known to exist
			if(max != (min + 1) && min != (max + min) / 2)
			{
				int pos = RTParent.GetPositionFromCharIndex((max + min) / 2).Y;
				if(pos == target)
				{
					// BestStartIndex found
					min = (max + min) / 2;
				}
				else if(pos > target)
				{
					// Look again, in lower half
					max = (max + min) / 2;
					FindStartIndex(ref min, ref max, ref target);
				}
				else if(pos < 0)
				{
					// Look again, in top half
					min = (max + min) / 2;
					FindStartIndex(ref min, ref max, ref target);
				}
			}
		}

		protected override void OnHandleCreated(EventArgs e)
		{
			base.OnHandleCreated(e);
			AutoSize = false;
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			if(DesignMode)
			{
				Refresh();
			}
			base.OnLocationChanged(e);
			Invalidate();
		}

		/// <summary>
		/// OnPaint will go through the enabled elements (vertical ReminderMessage, GridLines, LineNumbers, BorderLines,
		/// MarginLines) and will draw them if enabled. At the same time, it will build GraphicsPaths for each of those
		/// elements (that are enabled), which will be used in SeeThroughMode (if it's active): the figures in the
		/// GraphicsPaths will form a customized outline for the control by setting them as the Region of the LineNumber
		/// control. Note: the vertical ReminderMessages are only drawn during designtime. 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			// Build the list of visible LineNumberItems (= pLineNumberItems) first. (doesn't take long, so it can stay in OnPaint)
			UpdateVisibleLineNumberItems();
			base.OnPaint(e);
			// Quality settings
			e.Graphics.TextRenderingHint = pLineNumbersAntiAlias ? TextRenderingHint.AntiAlias : TextRenderingHint.SystemDefault;
			// NOTE: The GraphicsPaths are only used for SeeThroughMode
			// FillMode.Winding: combined outline ( Alternate: XOR'ed outline )
			GraphicsPath gpGridLines = new GraphicsPath(FillMode.Winding);
			GraphicsPath gpBorderLines = new GraphicsPath(FillMode.Winding);
			GraphicsPath gpMarginLines = new GraphicsPath(FillMode.Winding);
			GraphicsPath gpLineNumbers = new GraphicsPath(FillMode.Winding);
			if(DesignMode)
			{
				string reminderToShow = string.Empty;
				if(RTParent == null)
				{
					reminderToShow = "-!- Set ParentRichTextBox -!-";
				}
				else if(pLineNumberItems.Count == 0)
				{
					reminderToShow = "LineNumbers (  " + RTParent.Name + "  )";
				}
				if(reminderToShow.Length > 0)
				{
					e.Graphics.TranslateTransform(Width / 2f, Height / 2f);
					e.Graphics.RotateTransform(-90f);
					StringFormat format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
					SizeF textSize = e.Graphics.MeasureString(reminderToShow, Font, new Point(0, 0), format);
					e.Graphics.DrawString(reminderToShow, Font, Brushes.WhiteSmoke, 1f, 1f, format);
					e.Graphics.DrawString(reminderToShow, Font, Brushes.Firebrick, 0f, 0f, format);
					e.Graphics.ResetTransform();
					Rectangle reminderRectangle = new Rectangle((int)Math.Round((Width / 2.0) - (textSize.Height / 2.0)),
																 (int)Math.Round((Height / 2.0) - (textSize.Width / 2.0)),
																 (int)Math.Round(textSize.Height), (int)Math.Round(textSize.Width));
					gpLineNumbers.AddRectangle(reminderRectangle);
					gpLineNumbers.CloseFigure();
					if(pAutoSizing)
					{
						reminderRectangle.Inflate((int)Math.Round(textSize.Height * 0.2), (int)Math.Round(textSize.Width * 0.1));
						pAutoSizingSize = new Size(reminderRectangle.Width, reminderRectangle.Height);
					}
				}
			}
			if(pLineNumberItems.Count > 0)
			{
				// The visible LineNumberItems with their BackgroundGradient and GridLines
				// Loop through every visible LineNumberItem
				using(Pen pen = new Pen(pGridLinesColor, pGridLinesThickness) { DashStyle = pGridLinesStyle })
				{
					StringFormat format = new StringFormat
					{
						Alignment = StringAlignment.Near,
						LineAlignment = StringAlignment.Near,
						FormatFlags =
							StringFormatFlags.NoClip | StringFormatFlags.NoWrap | StringFormatFlags.FitBlackBox
					};
					for(int i = 0; i <= pLineNumberItems.Count - 1; i++)
					{
						// Background gradient
						if(pGradientShow)
						{
							using(LinearGradientBrush brush = new LinearGradientBrush(pLineNumberItems[i].Rectangle,
								pGradientStartColor, pGradientEndColor, pGradientDirection))
							{
								e.Graphics.FillRectangle(brush, pLineNumberItems[i].Rectangle);
							}
						}
						// Grid lines
						if(pGridLinesShow)
						{
							e.Graphics.DrawLine(pen, new Point(0, pLineNumberItems[i].Rectangle.Y),
								new Point(Width, pLineNumberItems[i].Rectangle.Y));
							Rectangle rect = new Rectangle((int)Math.Round(-pGridLinesThickness), pLineNumberItems[i].Rectangle.Y,
								(int)Math.Round(Width + (pGridLinesThickness * 2.0)),
								(int)Math.Round((Height - pLineNumberItems[0].Rectangle.Y) + pGridLinesThickness));
							gpGridLines.AddRectangle(rect);
							gpGridLines.CloseFigure();
						}
						// Line numbers
						if(pLineNumbersShow)
						{
							string textToShow;
							if(pLineNumbersShowLeadingZeroes)
							{
								textToShow = pLineNumbersShowAsHexadecimal
												? pLineNumberItems[i].LineNumber.ToString("X")
												: pLineNumberItems[i].LineNumber.ToString(pLineNumbersFormat);
							}
							else
							{
								textToShow = pLineNumbersShowAsHexadecimal
												? pLineNumberItems[i].LineNumber.ToString("X")
												: pLineNumberItems[i].LineNumber.ToString();
							}
							Point point = new Point(0, 0);
							SizeF textSize = e.Graphics.MeasureString(textToShow, Font, point, format);
							// Text alignment
							point = GetAlignmentPoint(textSize, pLineNumberItems[i]);
							// Text clipping
							Rectangle itemClipRectangle = new Rectangle(point, textSize.ToSize());
							if(pLineNumbersClipByItemRectangle)
							{
								// If selected, the text will be clipped so that it doesn't spill out of its own
								// LineNumberItem-area. Only the part of the text inside the LineNumberItem.
								// Rectangle should be visible, so intersect with the ItemRectangle.
								// The SetClip method temporary restricts the drawing area of the control for whatever
								// is drawn next.
								itemClipRectangle.Intersect(pLineNumberItems[i].Rectangle);
								e.Graphics.SetClip(itemClipRectangle);
							}
							// Text drawing
							using(SolidBrush brush = new SolidBrush(ForeColor))
							{
								e.Graphics.DrawString(textToShow, Font, brush, point, format);
								e.Graphics.ResetClip();
							}
							// The GraphicsPath for the LineNumber is just a rectangle behind the text, to keep the paintingspeed high and avoid ugly artifacts.
							gpLineNumbers.AddRectangle(itemClipRectangle);
							gpLineNumbers.CloseFigure();
						}
					}
					// Grid lines thickness and linestyle in SeeThroughMode. All GraphicsPath lines are drawn as solid to keep the paintingspeed high.
					if(pGridLinesShow)
					{
						pen.DashStyle = DashStyle.Solid;
						gpGridLines.Widen(pen);
					}
				}
			}
			Point left = new Point((int)Math.Round(Math.Floor(pBorderLinesThickness / 2.0)),
									 (int)Math.Round(Math.Floor(pBorderLinesThickness / 2.0)));
			Point right = new Point((int)Math.Round(Width - Math.Ceiling(pBorderLinesThickness / 2.0)),
									  (int)Math.Round(Height - Math.Ceiling(pBorderLinesThickness / 2.0)));
			// Border lines
			Point[] borderLinesPoints = new Point[5];
			borderLinesPoints[0] = new Point(left.X, left.Y);
			borderLinesPoints[1] = new Point(right.X, left.Y);
			borderLinesPoints[2] = new Point(right.X, right.Y);
			borderLinesPoints[3] = new Point(left.X, right.Y);
			borderLinesPoints[4] = new Point(left.X, left.Y);
			if(pBorderLinesShow)
			{
				using(Pen pen = new Pen(pBorderLinesColor, pBorderLinesThickness) { DashStyle = pBorderLinesStyle })
				{
					e.Graphics.DrawLines(pen, borderLinesPoints);
					gpBorderLines.AddLines(borderLinesPoints);
					gpBorderLines.CloseFigure();
					pen.DashStyle = DashStyle.Solid;
					gpBorderLines.Widen(pen);
				}
			}
			// Margin lines
			if(pMarginLinesShow && (pMarginLinesSide > LineNumberDockSide.None))
			{
				left = new Point((int)Math.Round(-pMarginLinesThickness), (int)Math.Round(-pMarginLinesThickness));
				right = new Point((int)Math.Round(Width + pMarginLinesThickness),
									(int)Math.Round(Height + pMarginLinesThickness));
				using(Pen pen = new Pen(pMarginLinesColor, pMarginLinesThickness) { DashStyle = pMarginLinesStyle })
				{
					if((pMarginLinesSide == LineNumberDockSide.Left) | (pMarginLinesSide == LineNumberDockSide.Height))
					{
						e.Graphics.DrawLine(pen, new Point((int)Math.Round(Math.Floor(pMarginLinesThickness / 2.0)), 0),
											new Point((int)Math.Round(Math.Floor(pMarginLinesThickness / 2.0)), Height - 1));
						left = new Point((int)Math.Round(Math.Ceiling(pMarginLinesThickness / 2.0)),
										   (int)Math.Round(-pMarginLinesThickness));
					}
					if((pMarginLinesSide == LineNumberDockSide.Right) | (pMarginLinesSide == LineNumberDockSide.Height))
					{
						e.Graphics.DrawLine(pen, new Point((int)Math.Round(Width - Math.Ceiling(pMarginLinesThickness / 2.0)), 0),
											new Point((int)Math.Round(Width - Math.Ceiling(pMarginLinesThickness / 2.0)), Height - 1));
						right = new Point((int)Math.Round(Width - Math.Ceiling(pMarginLinesThickness / 2.0)),
											(int)Math.Round(Height + pMarginLinesThickness));
					}
					// GraphicsPath for the MarginLines(s): MarginLines(s) are drawn as a rectangle connecting the left
					// and right points, which are either inside or outside of sight, depending on whether the MarginLines
					// at that side is visible. "left": TopLeft and "right": BottomRight
					gpMarginLines.AddRectangle(new Rectangle(left, new Size(right.X - left.X, right.Y - left.Y)));
					pen.DashStyle = DashStyle.Solid;
					gpMarginLines.Widen(pen);
				}
			}
			Region region = new Region(ClientRectangle);
			// SeeThroughMode: combine all the GraphicsPaths and set them as the region for the control.
			if(pSeeThroughMode)
			{
				region.MakeEmpty();
				region.Union(gpBorderLines);
				region.Union(gpMarginLines);
				region.Union(gpGridLines);
				region.Union(gpLineNumbers);
			}
			if(region.GetBounds(e.Graphics).IsEmpty)
			{
				// Note: If the control is in a condition that would show it as empty, then a border-region is still
				// drawn regardless of it's borders on/off state. This is added to make sure that the bounds of the
				// control are never lost (it would remain empty if this was not done).
				gpBorderLines.AddLines(borderLinesPoints);
				gpBorderLines.CloseFigure();
				using(Pen pen = new Pen(pBorderLinesColor, 1f) { DashStyle = DashStyle.Solid })
				{
					gpBorderLines.Widen(pen);
					region = new Region(gpBorderLines);
				}
			}
			Region = region;
		}

		private Point GetAlignmentPoint(SizeF textSize, LineNumberItem item)
		{
			Point point;
			switch(pLineNumbersAlignment)
			{
				case ContentAlignment.TopLeft:
				point = new Point((item.Rectangle.Left + Padding.Left) + pLineNumbersOffset.Width,
									  (item.Rectangle.Top + Padding.Top) + pLineNumbersOffset.Height);
				break;

				case ContentAlignment.MiddleLeft:
				point = new Point((item.Rectangle.Left + Padding.Left) + pLineNumbersOffset.Width,
								  (int)
								  Math.Round(((item.Rectangle.Top +
											   (item.Rectangle.Height / 2.0)) + pLineNumbersOffset.Height) -
											 (textSize.Height / 2.0)));
				break;

				case ContentAlignment.BottomLeft:
				point = new Point((item.Rectangle.Left + Padding.Left) + pLineNumbersOffset.Width,
								  (int)
								  Math.Round((((item.Rectangle.Bottom - Padding.Bottom) + 1) +
											  pLineNumbersOffset.Height) - textSize.Height));
				break;

				case ContentAlignment.TopCenter:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Width / 2.0) + pLineNumbersOffset.Width) - (textSize.Width / 2.0)),
						(item.Rectangle.Top + Padding.Top) + pLineNumbersOffset.Height);
				break;

				case ContentAlignment.MiddleCenter:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Width / 2.0) + pLineNumbersOffset.Width) - (textSize.Width / 2.0)),
						(int)
						Math.Round(((item.Rectangle.Top + (item.Rectangle.Height / 2.0)) +
									pLineNumbersOffset.Height) - (textSize.Height / 2.0)));
				break;

				case ContentAlignment.BottomCenter:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Width / 2.0) + pLineNumbersOffset.Width) - (textSize.Width / 2.0)),
						(int)
						Math.Round((((item.Rectangle.Bottom - Padding.Bottom) + 1) + pLineNumbersOffset.Height) -
								   textSize.Height));
				break;

				case ContentAlignment.TopRight:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Right - Padding.Right) + pLineNumbersOffset.Width) -
								   textSize.Width), (item.Rectangle.Top + Padding.Top) + pLineNumbersOffset.Height);
				break;

				case ContentAlignment.MiddleRight:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Right - Padding.Right) + pLineNumbersOffset.Width) -
								   textSize.Width),
						(int)
						Math.Round(((item.Rectangle.Top + (item.Rectangle.Height / 2.0)) +
									pLineNumbersOffset.Height) - (textSize.Height / 2.0)));
				break;

				case ContentAlignment.BottomRight:
				point =
					new Point(
						(int)
						Math.Round(((item.Rectangle.Right - Padding.Right) + pLineNumbersOffset.Width) -
								   textSize.Width),
						(int)
						Math.Round((((item.Rectangle.Bottom - Padding.Bottom) + 1) + pLineNumbersOffset.Height) -
								   textSize.Height));
				break;
				default:
				point = new Point(0, 0);
				break;
			}
			return point;
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if(DesignMode)
			{
				Refresh();
			}
			base.OnSizeChanged(e);
			Invalidate();
		}

		public override void Refresh()
		{
			base.Refresh();
			UpdateSizeAndPosition();
		}

		private void UpdateSizeAndPosition()
		{
			if(!AutoSize && !(((Dock == DockStyle.Bottom) | (Dock == DockStyle.Fill)) | (Dock == DockStyle.Top)))
			{
				Point zNewLocation = Location;
				Size zNewSize = Size;
				if(pAutoSizing)
				{
					if(RTParent == null)
					{
						if(pAutoSizingSize.Width > 0)
						{
							zNewSize.Width = pAutoSizingSize.Width;
						}
						if(pAutoSizingSize.Height > 0)
						{
							zNewSize.Height = pAutoSizingSize.Height;
						}
						Size = zNewSize;
					}
					else if((Dock == DockStyle.Left) | (Dock == DockStyle.Right))
					{
						if(pAutoSizingSize.Width > 0)
						{
							zNewSize.Width = pAutoSizingSize.Width;
						}
						Width = zNewSize.Width;
					}
					else if(pDockSide != LineNumberDockSide.None)
					{
						if(pAutoSizingSize.Width > 0)
						{
							zNewSize.Width = pAutoSizingSize.Width;
						}
						zNewSize.Height = RTParent.Height;
						if(pDockSide == LineNumberDockSide.Left)
						{
							zNewLocation.X = (RTParent.Left - zNewSize.Width) - 1;
						}
						if(pDockSide == LineNumberDockSide.Right)
						{
							zNewLocation.X = RTParent.Right + 1;
						}
						zNewLocation.Y = RTParent.Top;
						Location = zNewLocation;
						Size = zNewSize;
					}
					else if(pDockSide == LineNumberDockSide.None)
					{
						if(pAutoSizingSize.Width > 0)
						{
							zNewSize.Width = pAutoSizingSize.Width;
						}
						Size = zNewSize;
					}
				}
				else
				{
					if(RTParent == null)
					{
						if(pAutoSizingSize.Width > 0)
						{
							zNewSize.Width = pAutoSizingSize.Width;
						}
						if(pAutoSizingSize.Height > 0)
						{
							zNewSize.Height = pAutoSizingSize.Height;
						}
						Size = zNewSize;
					}
					else if(pDockSide != LineNumberDockSide.None)
					{
						zNewSize.Height = RTParent.Height;
						if(pDockSide == LineNumberDockSide.Left)
						{
							zNewLocation.X = (RTParent.Left - zNewSize.Width) - 1;
						}
						if(pDockSide == LineNumberDockSide.Right)
						{
							zNewLocation.X = RTParent.Right + 1;
						}
						zNewLocation.Y = RTParent.Top;
						Location = zNewLocation;
						Size = zNewSize;
					}
				}
			}
		}

		/// <summary>
		/// This Sub determines which textlines are visible in the ParentRichTextBox, and makes LineNumberItems (LineNumber + ItemRectangle)
		/// for each visible line. They are put into the pLineNumberItems List that will be used by the OnPaint event to draw the LineNumberItems.
		/// </summary>
		private void UpdateVisibleLineNumberItems()
		{
			pLineNumberItems.Clear();
			pLineNumbersFormat = DefaultLineNumbersFormat;
			CalculateAutoSizing();
			if((RTParent != null) && (RTParent.Text != ""))
			{
				// Make sure the LineNumbers are aligning to the same height as the pRTParent textlines by converting to
				// screencoordinates and using that as an offset that gets added to the points for the LineNumberItems
				pPointInParent = RTParent.PointToScreen(RTParent.ClientRectangle.Location);
				pPointInMe = PointToScreen(new Point(0, 0));
				// pParentInMe is the vertical offset to make the LineNumberItems line up with the textlines in pRTParent.
				pParentInMe = (pPointInParent.Y - pPointInMe.Y) + 1;
				// The first visible LineNumber may not be the first visible line of text in the RTB if the
				// LineNumbercontrol's .Top is lower on the form than the .Top of the parent RichTextBox.
				// Therefor, pPointInParent will now be used to find pPointInMe's equivalent height in pRTParent,
				// which is needed to find the best StartIndex later on.
				pPointInParent = RTParent.PointToClient(pPointInMe);
				// Additional complication is the fact that when wordwrap is enabled on the RTB, the wordwrapped text
				// spills into the RTB.Lines collection, so we need to split the text into lines ourselves, and use
				// the Index of each split-line's first character instead of the RTB's.
				string[] split = RTParent.Text.Split(LineBreakCharacters);
				if(split.Length < 2)
				{
					// Just one line in the text = one line number
					// NOTE:  pContentRectangle is built by the pRTParent.ContentsResized event.
					Point point = RTParent.GetPositionFromCharIndex(0);
					pLineNumberItems.Add(new LineNumberItem(1,
						new Rectangle(new Point(0, (point.Y - 1) + pParentInMe),
							new Size(Width, pContentRectangle.Height - point.Y))));
				}
				else
				{
					// Multiple lines, but store only those LineNumberItems for lines that are visible.
					TimeSpan timeSpan = new TimeSpan(DateTime.Now.Ticks);
					int startIndex = 0;
					int a = RTParent.Text.Length - 1;
					int y = pPointInParent.Y;
					FindStartIndex(ref startIndex, ref a, ref y);
					pPointInParent.Y = y;
					// startIndex now holds the index of a character in the first visible line from zParent.Text
					// Now it will be pointed at the first character of that line
					startIndex = Math.Max(0, Math.Min(RTParent.Text.Length - 1, RTParent.Text.Substring(0, startIndex).LastIndexOf('\n') + 1));
					// We now need to find out which split-line that character is in, by counting the LineBreakCharacters
					// appearances that come before it.
					a = Math.Max(0, RTParent.Text.Substring(0, startIndex).Split(LineBreakCharacters).Length - 1);
					// startIndex starts off pointing at the first character of the first visible line, and will be then
					// be pointed to the index of the first character on the next line.
					while(a <= split.Length - 1)
					{
						Point point = RTParent.GetPositionFromCharIndex(startIndex);
						startIndex += Math.Max(1, split[a].Length + 1);
						if((point.Y + pParentInMe) > Height)
						{
							break;
						}
						// For performance reasons, the list of LineNumberItems (pLineNumberItems) is first built with
						// only the location of its itemrectangle being used. The height of those rectangles will be
						// computed afterwards by comparing the items' Y coordinates.
						pLineNumberItems.Add(new LineNumberItem(a + 1, new Rectangle(0, (point.Y - 1) + pParentInMe, Width, 1)));
						if(pParentIsScrolling && (DateTime.Now.Ticks > (timeSpan.Ticks + ScrollTimeoutTicks)))
						{
							// The more lines there are in the RTB, the slower the RTB's .GetPositionFromCharIndex()
							// method becomes. To avoid those delays from interfering with the scrollingspeed,
							// this speedbased exit for is applied (0.05 sec). pLineNumberItems will have at least 1 item,
							// and if that's the only one, then change its location to 0,0 to make it readable
							if(pLineNumberItems.Count == 1)
							{
								pLineNumberItems[0].Rectangle.Y = 0;
							}
							pParentIsScrolling = false;
							Timer.Start();
							break;
						}
						a++;
					}
					if(pLineNumberItems.Count == 0)
					{
						return;
					}
					// Add an extra placeholder item to the end, to make the heightcomputation easier
					if(a < split.Length)
					{
						// Getting here means the while loop was exited before reaching the last split textline
						// startIndex will still be pointing to the startcharacter of the next line, so we can use that:
						Point point = RTParent.GetPositionFromCharIndex(Math.Min(startIndex, RTParent.Text.Length - 1));
						pLineNumberItems.Add(new LineNumberItem(-1, new Rectangle(0, (point.Y - 1) + pParentInMe, 0, 0)));
					}
					else
					{
						// Getting here means the while loop ran to the end ("a" is now split.Length). 
						pLineNumberItems.Add(new LineNumberItem(-1, new Rectangle(0, pContentRectangle.Bottom, 0, 0)));
					}
					// And now we can easily compute the height of the LineNumberItems by comparing each item's Y
					// coordinate with that of the next line. There's at least two items in the list, and the last
					// item is a "nextline-placeholder" that will be removed.
					for(a = 0; a <= pLineNumberItems.Count - 2; a++)
					{
						pLineNumberItems[a].Rectangle.Height = Math.Max(1, pLineNumberItems[a + 1].Rectangle.Y - pLineNumberItems[a].Rectangle.Y);
					}
					// Removing the placeholder item
					pLineNumberItems.RemoveAt(pLineNumberItems.Count - 1);
					// Set the Format to the width of the highest possible number so that LeadingZeroes shows the
					// correct amount of zeroes.
					pLineNumbersFormat = string.Empty.PadRight(pLineNumbersShowAsHexadecimal ? split.Length.ToString("X").Length : split.Length.ToString().Length, '0');
				}
				CalculateAutoSizing();
			}
		}

		private void CalculateAutoSizing()
		{
			pAutoSizingSize = new Size(0, 0);
			if(pAutoSizing)
			{
				// To measure the LineNumber's width, its Format 0 is replaced by w as that is likely to be one of the widest characters in non-monospace fonts.
				pAutoSizingSize = new Size(TextRenderer.MeasureText(pLineNumbersFormat.Replace('0', 'W'), Font).Width, 0);
			}
		}

#endregion

		// Handlers
#region Handlers

		private void RTParentChanged(object sender, EventArgs e)
		{
			Refresh();
			Invalidate();
		}

		private void ParentContentsResized(object sender, ContentsResizedEventArgs e)
		{
			pContentRectangle = e.NewRectangle;
			Refresh();
			Invalidate();
		}

		private void ParentDisposed(object sender, EventArgs e)
		{
			ParentRichTextBox = null;
			Refresh();
			Invalidate();
		}

		private void ParentScroll(object sender, EventArgs e)
		{
			pParentIsScrolling = true;
			Invalidate();
		}

		private void TimerTick(object sender, EventArgs e)
		{
			pParentIsScrolling = false;
			Timer.Stop();
			Invalidate();
		}

#endregion

		// Properties
#region Properties

		[Description("Use this property to enable the control to act as an overlay ontop of the RichTextBox."), Category("Additional Behavior")]
		public bool SeeThroughMode
		{
			get
			{
				return pSeeThroughMode;
			}
			set
			{
				pSeeThroughMode = value;
				Invalidate();
			}
		}

		[Browsable(false)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
				Invalidate();
			}
		}

		[Description("Use this property to automatically resize the control (and reposition it if needed)."), Category("Additional Behavior")]
		public bool AutoSizing
		{
			get
			{
				return pAutoSizing;
			}
			set
			{
				pAutoSizing = value;
				Refresh();
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public Color BackgroundGradientAlphaColor
		{
			get
			{
				return pGradientStartColor;
			}
			set
			{
				pGradientStartColor = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public Color BackgroundGradientBetaColor
		{
			get
			{
				return pGradientEndColor;
			}
			set
			{
				pGradientEndColor = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public LinearGradientMode BackgroundGradientDirection
		{
			get
			{
				return pGradientDirection;
			}
			set
			{
				pGradientDirection = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public Color BorderLinesColor
		{
			get
			{
				return pBorderLinesColor;
			}
			set
			{
				pBorderLinesColor = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public DashStyle BorderLinesStyle
		{
			get
			{
				return pBorderLinesStyle;
			}
			set
			{
				if(value == DashStyle.Custom)
				{
					value = DashStyle.Solid;
				}
				pBorderLinesStyle = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public float BorderLinesThickness
		{
			get
			{
				return pBorderLinesThickness;
			}
			set
			{
				pBorderLinesThickness = Math.Max(1f, Math.Min(255f, value));
				Invalidate();
			}
		}

		[Description("Use this property to dock the LineNumbers to a chosen side of the chosen RichTextBox."), Category("Additional Behavior")]
		public LineNumberDockSide DockSide
		{
			get
			{
				return pDockSide;
			}
			set
			{
				pDockSide = value;
				Refresh();
				Invalidate();
			}
		}

		[Browsable(true)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				Refresh();
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public Color GridLinesColor
		{
			get
			{
				return pGridLinesColor;
			}
			set
			{
				pGridLinesColor = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public DashStyle GridLinesStyle
		{
			get
			{
				return pGridLinesStyle;
			}
			set
			{
				if(value == DashStyle.Custom)
				{
					value = DashStyle.Solid;
				}
				pGridLinesStyle = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public float GridLinesThickness
		{
			get
			{
				return pGridLinesThickness;
			}
			set
			{
				pGridLinesThickness = Math.Max(1f, Math.Min(255f, value));
				Invalidate();
			}
		}

		[Description("Use this to align the LineNumbers to a chosen corner (or center) within their item-area."), Category("Additional Behavior")]
		public ContentAlignment LineNumbersAlignment
		{
			get
			{
				return pLineNumbersAlignment;
			}
			set
			{
				pLineNumbersAlignment = value;
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("Use this to apply Anti-Aliasing to the LineNumbers (high quality). Some fonts will look better without it, though.")]
		public bool LineNumbersAntiAlias
		{
			get
			{
				return pLineNumbersAntiAlias;
			}
			set
			{
				pLineNumbersAntiAlias = value;
				Refresh();
				Invalidate();
			}
		}

		[Description("Use this to set whether the LineNumbers should be shown as hexadecimal values."), Category("Additional Behavior")]
		public bool LineNumbersAsHexadecimal
		{
			get
			{
				return pLineNumbersShowAsHexadecimal;
			}
			set
			{
				pLineNumbersShowAsHexadecimal = value;
				Refresh();
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("Use this to set whether the LineNumbers are allowed to spill out of their item-area, or should be clipped by it.")]
		public bool LineNumbersClippedByItemRectangle
		{
			get
			{
				return pLineNumbersClipByItemRectangle;
			}
			set
			{
				pLineNumbersClipByItemRectangle = value;
				Invalidate();
			}
		}

		[Description("Use this to set whether the LineNumbers should have leading zeroes (based on the total amount of textlines)."), Category("Additional Behavior")]
		public bool LineNumbersLeadingZeroes
		{
			get
			{
				return pLineNumbersShowLeadingZeroes;
			}
			set
			{
				pLineNumbersShowLeadingZeroes = value;
				Refresh();
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("Use this property to manually reposition the LineNumbers, relative to their current location.")]
		public Size LineNumbersOffset
		{
			get
			{
				return pLineNumbersOffset;
			}
			set
			{
				pLineNumbersOffset = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public Color MarginLinesColor
		{
			get
			{
				return pMarginLinesColor;
			}
			set
			{
				pMarginLinesColor = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public LineNumberDockSide MarginLinesSide
		{
			get
			{
				return pMarginLinesSide;
			}
			set
			{
				pMarginLinesSide = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public DashStyle MarginLinesStyle
		{
			get
			{
				return pMarginLinesStyle;
			}
			set
			{
				if(value == DashStyle.Custom)
				{
					value = DashStyle.Solid;
				}
				pMarginLinesStyle = value;
				Invalidate();
			}
		}

		[Category("Additional Appearance")]
		public float MarginLinesThickness
		{
			get
			{
				return pMarginLinesThickness;
			}
			set
			{
				pMarginLinesThickness = Math.Max(1f, Math.Min(255f, value));
				Invalidate();
			}
		}

		[Category("Add LineNumbers to"), Description("Use this property to enable LineNumbers for the chosen RichTextBox.")]
		public RichTextBox ParentRichTextBox
		{
			get
			{
				return RTParent;
			}
			set
			{
				RTParent = value;
				if(RTParent != null)
				{
					Parent = RTParent.Parent;
					RTParent.Refresh();
				}
				Text = "";
				Refresh();
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("The BackgroundGradient is a gradual blend of two colors, shown in the back of each LineNumber's item-area.")]
		public bool ShowBackgroundGradient
		{
			get
			{
				return pGradientShow;
			}
			set
			{
				pGradientShow = value;
				Invalidate();
			}
		}

		[Description("BorderLines are shown on all sides of the LineNumber control."), Category("Additional Behavior")]
		public bool ShowBorderLines
		{
			get
			{
				return pBorderLinesShow;
			}
			set
			{
				pBorderLinesShow = value;
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("GridLines are the horizontal divider-lines shown above each LineNumber.")]
		public bool ShowGridLines
		{
			get
			{
				return pGridLinesShow;
			}
			set
			{
				pGridLinesShow = value;
				Invalidate();
			}
		}

		[Category("Additional Behavior")]
		public bool ShowLineNumbers
		{
			get
			{
				return pLineNumbersShow;
			}
			set
			{
				pLineNumbersShow = value;
				Invalidate();
			}
		}

		[Category("Additional Behavior"), Description("MarginLines are shown on the Left or Right (or both in Height-mode) of the LineNumber control.")]
		public bool ShowMarginLines
		{
			get
			{
				return pMarginLinesShow;
			}
			set
			{
				pMarginLinesShow = value;
				Invalidate();
			}
		}

		[Browsable(false), AmbientValue(""), DefaultValue("")]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				Invalidate();
			}
		}

		private RichTextBox RTParent
		{
			[DebuggerNonUserCode]
			get
			{
				return pParent;
			}
			[MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
			set
			{
				EventHandler handler = ParentDisposed;
				ContentsResizedEventHandler handler2 = ParentContentsResized;
				EventHandler handler3 = ParentScroll;
				EventHandler handler4 = ParentScroll;
				EventHandler handler5 = RTParentChanged;
				EventHandler handler6 = RTParentChanged;
				EventHandler handler7 = RTParentChanged;
				EventHandler handler8 = RTParentChanged;
				EventHandler handler9 = RTParentChanged;
				EventHandler handler10 = RTParentChanged;
				if(pParent != null)
				{
					pParent.Disposed -= handler;
					pParent.ContentsResized -= handler2;
					pParent.VScroll -= handler3;
					pParent.HScroll -= handler4;
					pParent.MultilineChanged -= handler5;
					pParent.TextChanged -= handler6;
					pParent.DockChanged -= handler7;
					pParent.Resize -= handler8;
					pParent.Move -= handler9;
					pParent.LocationChanged -= handler10;
				}
				pParent = value;
				if(pParent != null)
				{
					pParent.Disposed += handler;
					pParent.ContentsResized += handler2;
					pParent.VScroll += handler3;
					pParent.HScroll += handler4;
					pParent.MultilineChanged += handler5;
					pParent.TextChanged += handler6;
					pParent.DockChanged += handler7;
					pParent.Resize += handler8;
					pParent.Move += handler9;
					pParent.LocationChanged += handler10;
				}
			}
		}

		private Timer Timer
		{
			[DebuggerNonUserCode]
			get
			{
				return pTimer;
			}
			[MethodImpl(MethodImplOptions.Synchronized), DebuggerNonUserCode]
			set
			{
				EventHandler handler = TimerTick;
				if(pTimer != null)
				{
					pTimer.Tick -= handler;
				}
				pTimer = value;
				if(pTimer != null)
				{
					pTimer.Tick += handler;
				}
			}
		}

#endregion

		// Nested Types
#region Nested Types

		public enum LineNumberDockSide
		{
			Height = 4,
			Left = 1,
			None = 0,
			Right = 2
		}

		private class LineNumberItem
		{
			// Fields
			internal int LineNumber;
			internal Rectangle Rectangle;

			// Methods
			internal LineNumberItem(int zLineNumber, Rectangle zRectangle)
			{
				LineNumber = zLineNumber;
				Rectangle = zRectangle;
			}
		}

#endregion
	}
}
