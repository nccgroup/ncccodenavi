= Changes in 1.0 =

== FEATURES ==
- FEATURE: Tabbed browsing - Dan M
- FEATURE: Show file in explorer (right-click in search results) - Dan M
- FEATURE: Double-click or press enter on filename in file browser now opens it in a sepeate code viewer window
- FEATURE: Code editor window: right-click to send the full path to notes. - Dan M
- FEATURE: Prompt user if you click the x or close and you have windows open - Dan M
- FEATURE: Automatic saving of notes (off by default) - Dan M
- FEATURE: Basic colourization support for language keywords
- FEATURE: Initial support for ignoring comments (see file .\Grepify.Comments\Comments.grepify for definitions) - Richard T
- FEATURE: Regex for file and directory exclusions - Richard T / Tim B
- FEATURE: Version checking

== BUG FIXES ==
- BUG FIX: Overselections on lines in notes now dont throw an exception when doing right-click - Richard T
- BUG FIX: Sorted out the notes pain so it is such a terrible user exerpience when scroll bars are about
- BUG FIX: Make clear what the export function needs and why - Dan M

= TO-DO LIST =
- Select a word in code view and highlight all instances in the file - Dan M
- Avoid icon re-use for different reasons - Dan M
- Load notes button. Maybe a model splash screen with: restore workspace vs. clean slate - Dan M
- Improved Code syntax highlighting

= Changes in Beta 4 =

== FEATURES ==
- FEATURE: File browser now implemented fully
- FEATURE: Search for files and directories in the file browser - Dan M
- FEATURE: You can right-click on the file in the file browser and open in a separate code view window
- FEATURE: Search status in the bottom of the search dialogue - Dan M
- FEATURE: Search results can now be sorted by clicking on the titles - Dan M / Richard T

== BUG FIXES ==
- BUG FIX: Was missing files with unicode in (a whopper of a bug) - Richard T

= Changes in Beta 3 =
- Text size and colour support in the notes
- Grepify profile support
- Ctrl - W to close windows (Daniel W)
- Vertical scroll bars now visible when maximized
- Several people pointed out that Ctrl-Tab works to cycle windows (Ctrl-Space now removed)
- Renamed 'Search' on the Code View right-click menu to highlight the fact it searches across the code base