@echo off

REM 
REM thank you - http://stackoverflow.com/questions/3848597/bat-current-folder-name 
REM
@setlocal enableextensions enabledelayedexpansion
    @echo off
    set startdir=%cd%
    set temp=%startdir%
    set folder=
:loop
    if not "x%temp:~-1%"=="x\" (
        set folder=!temp:~-1!!folder!
        set temp=!temp:~0,-1!
        goto :loop
    )
    endlocal && set folder=%folder%


REM
REM Now for the rest
REM
echo [i] Current directory %folder%

date /t > Package.log
time /t >> Package.log

if %folder% == Release (
	echo [*] Correct directory
) else (
	echo [!] You need to be in the Release directory
 	goto :eof
)

md Package > nul 2> nul
cd Package
copy "..\..\Win.CodeNavi\Win.CodeNavi\bin\Release\*.exe"
copy "..\..\Win.CodeNavi\Win.CodeNavi\bin\Release\*.dll"
copy "..\..\Win.CodeNavi\3rd-Party\ScintillaNET v2.5.2 Source\bin\Release\*.dll"
del WeifenLuo.WinFormsUI.Docking.dll > nul 2> nul

md Grepify.Comments > nul 2> nul
copy ..\..\Configuration\Grepify.Comments\*.* .\Grepify.Comments
md Grepify.Profiles > nul 2> nul
copy ..\..\Configuration\Grepify.Profiles\*.* .\Grepify.Profiles
md NCCCodeNavi.CodeHighlighting > nul 2> nul
copy ..\..\Configuration\NCCCodeNavi.CodeHighlighting\*.* .\NCCCodeNavi.CodeHighlighting
md NCCCodeNavi.Exclusions > nul 2> nul
copy ..\..\Configuration\NCCCodeNavi.Exclusions\*.* .\NCCCodeNavi.Exclusions
md Notepad++.Profiles > nul 2> nul
copy "..\..\Configuration\Notepad++.Profiles\*.*" ".\Notepad++.Profiles"

cd ..

:eof