@echo off
setlocal EnableExtensions EnableDelayedExpansion

REM ==================================================
REM OSL Builder
REM ==================================================

chcp 65001 > nul
title OSL Builder
color 0B

REM Get the directory where this script is located.
set "SCRIPT_DIR=%~dp0"

REM Move to the script directory.
cd /d "%SCRIPT_DIR%"

REM Locate 7-Zip once for the whole session (used to create ZIP archives).
call :FIND_7ZIP

if "!SEVENZIP!"=="" (
echo.
echo ⚠️ 7-Zip ^(7z.exe^) not found.
echo    Install 7-Zip ^(https://www.7-zip.org^)
echo.
pause
)

REM ==================================================
REM MAIN MENU
REM ==================================================

:MAIN_MENU
cls

set "BUILD_SERVER=0"
set "BUILD_OVERLAY_WINDOWS=0"
set "BUILD_OVERLAY_LINUX=0"
set "ZIP_SERVER=0"
set "ZIP_OVERLAY_WINDOWS=0"
set "ZIP_OVERLAY_LINUX=0"

echo.
echo ========================================================
echo.
echo                   🚀 OSL BUILDER
echo.
echo ========================================================
echo.
echo   [1] 🚀 Build all
echo.
echo   [2] 🖥️ Build OSL-Server
echo.
echo   [3] 🪟 Build OSL-Overlay Windows
echo.
echo   [4] 🐧 Build OSL-Overlay Linux
echo.
echo   [5] 🎯 Custom build selection
echo.
echo   [6] 📦 Generate ZIP only
echo.
echo   [0] ❌ Exit
echo.
echo ========================================================
echo.

choice /C 1234560 /N /M "Select an option"

if errorlevel 7 goto EXIT
if errorlevel 6 goto ZIP_ONLY_MENU
if errorlevel 5 goto CUSTOM_BUILD
if errorlevel 4 goto SELECT_OVERLAY_LINUX
if errorlevel 3 goto SELECT_OVERLAY_WINDOWS
if errorlevel 2 goto SELECT_SERVER
if errorlevel 1 goto SELECT_ALL

REM ==================================================
REM ZIP ONLY
REM ==================================================

:ZIP_ONLY_MENU

cls

set "ZIP_SERVER=0"
set "ZIP_OVERLAY_WINDOWS=0"
set "ZIP_OVERLAY_LINUX=0"

echo.
echo ========================================================
echo.
echo                  📦 GENERATE ZIP
echo.
echo ========================================================
echo.

choice /C YN /N /M "Zip OSL-Server (win-x64) ? [Y/N]"

if errorlevel 2 (
set "ZIP_SERVER=0"
) else (
set "ZIP_SERVER=1"
)

choice /C YN /N /M "Zip OSL-Overlay Windows (win-x64) ? [Y/N]"

if errorlevel 2 (
set "ZIP_OVERLAY_WINDOWS=0"
) else (
set "ZIP_OVERLAY_WINDOWS=1"
)

choice /C YN /N /M "Zip OSL-Overlay Linux (linux-x64) ? [Y/N]"

if errorlevel 2 (
set "ZIP_OVERLAY_LINUX=0"
) else (
set "ZIP_OVERLAY_LINUX=1"
)

if "!ZIP_SERVER!!ZIP_OVERLAY_WINDOWS!!ZIP_OVERLAY_LINUX!"=="000" (
echo.
echo ⚠️ No target selected.
pause
goto MAIN_MENU
)

cls

echo.
echo ========================================================
echo.
echo                  📦 GENERATE ZIP
echo.
echo ========================================================
echo.

if "!ZIP_SERVER!"=="1" (
call :ZIP_PROJECT ^
    "OSL-Server" ^
    "..\OSL-Publish\OSL-Server\win-x64" ^
    "win-x64" ^
    "..\OSL-Server"
)

if "!ZIP_OVERLAY_WINDOWS!"=="1" (
call :ZIP_PROJECT ^
    "OSL-Overlay" ^
    "..\OSL-Publish\OSL-Overlay\win-x64" ^
    "win-x64" ^
    "..\OSL-Overlay"
)

if "!ZIP_OVERLAY_LINUX!"=="1" (
call :ZIP_PROJECT ^
    "OSL-Overlay" ^
    "..\OSL-Publish\OSL-Overlay\linux-x64" ^
    "linux-x64" ^
    "..\OSL-Overlay"
)

echo.
echo ========================================================
echo.
echo                  ✔ ZIP GENERATION DONE
echo.
echo ========================================================
echo.

pause

goto MAIN_MENU

REM ==================================================
REM SELECT BUILD ALL
REM ==================================================

:SELECT_ALL

set "BUILD_SERVER=1"
set "BUILD_OVERLAY_WINDOWS=1"
set "BUILD_OVERLAY_LINUX=1"

goto SELECT_CONFIGURATION

REM ==================================================
REM SELECT BUILD SERVER
REM ==================================================

:SELECT_SERVER

set "BUILD_SERVER=1"

goto SELECT_CONFIGURATION

REM ==================================================
REM SELECT BUILD OVERLAY WINDOWS
REM ==================================================

:SELECT_OVERLAY_WINDOWS

set "BUILD_OVERLAY_WINDOWS=1"

goto SELECT_CONFIGURATION

REM ==================================================
REM SELECT BUILD OVERLAY LINUX
REM ==================================================

:SELECT_OVERLAY_LINUX

set "BUILD_OVERLAY_LINUX=1"

goto SELECT_CONFIGURATION

REM ==================================================
REM CUSTOM BUILD
REM ==================================================

:CUSTOM_BUILD

cls

echo.
echo ========================================================
echo.
echo                    🎯 CUSTOM BUILD
echo.
echo ========================================================
echo.

choice /C YN /N /M "Build OSL-Server ? [Y/N]"

if errorlevel 2 (
set "BUILD_SERVER=0"
) else (
set "BUILD_SERVER=1"
)

choice /C YN /N /M "Build OSL-Overlay Windows ? [Y/N]"

if errorlevel 2 (
set "BUILD_OVERLAY_WINDOWS=0"
) else (
set "BUILD_OVERLAY_WINDOWS=1"
)

choice /C YN /N /M "Build OSL-Overlay Linux ? [Y/N]"

if errorlevel 2 (
set "BUILD_OVERLAY_LINUX=0"
) else (
set "BUILD_OVERLAY_LINUX=1"
)

if "!BUILD_SERVER!!BUILD_OVERLAY_WINDOWS!!BUILD_OVERLAY_LINUX!"=="000" (
echo.
echo ⚠️ No build selected.
pause
goto MAIN_MENU
)

goto SELECT_CONFIGURATION

REM ==================================================
REM SELECT BUILD CONFIGURATION
REM ==================================================

:SELECT_CONFIGURATION

cls

echo.
echo ========================================================
echo.
echo                   🔧 BUILD CONFIGURATION
echo.
echo ========================================================
echo.
echo   [1] 🚀 Release
echo.
echo   [2] 🐞 Debug
echo.
echo   [0] 🔙 Back
echo.
echo ========================================================
echo.

choice /C 120 /N /M "Select configuration"

if errorlevel 3 goto MAIN_MENU

if errorlevel 2 (
set "BUILD_CONFIGURATION=Debug"
) else (
set "BUILD_CONFIGURATION=Release"
)

goto SELECT_RELEASE_TYPE

REM ==================================================
REM SELECT RELEASE TYPE
REM ==================================================

:SELECT_RELEASE_TYPE

cls

echo.
echo ========================================================
echo.
echo                    🏷️ RELEASE TYPE
echo.
echo ========================================================
echo.
echo   [1] 🚀 Release
echo.
echo   [2] 🧪 Alpha
echo.
echo   [3] 🧪 Beta
echo.
echo   [4] 🧪 Release Candidate
echo.
echo ========================================================
echo.

choice /C 1234 /N /M "Select release type"

if errorlevel 4 goto RELEASE_TYPE_RC
if errorlevel 3 goto RELEASE_TYPE_BETA
if errorlevel 2 goto RELEASE_TYPE_ALPHA
if errorlevel 1 goto RELEASE_TYPE_RELEASE

:RELEASE_TYPE_RELEASE
set "RELEASE_TYPE=Release"
goto GET_VERSIONS

:RELEASE_TYPE_ALPHA
set "RELEASE_TYPE=Alpha"
goto GET_VERSIONS

:RELEASE_TYPE_BETA
set "RELEASE_TYPE=Beta"
goto GET_VERSIONS

:RELEASE_TYPE_RC
set "RELEASE_TYPE=RC"
goto GET_VERSIONS

REM ==================================================
REM GET VERSIONS
REM ==================================================

:GET_VERSIONS

if "!BUILD_SERVER!"=="1" goto GET_SERVER_VERSION
if "!BUILD_OVERLAY_WINDOWS!"=="1" goto GET_OVERLAY_VERSION
if "!BUILD_OVERLAY_LINUX!"=="1" goto GET_OVERLAY_VERSION

goto COMPUTE_BUILD_DATE

REM ==================================================
REM GET SERVER VERSION
REM ==================================================

:GET_SERVER_VERSION

cls

echo.
echo ========================================================
echo.
echo                     📦 VERSION SETUP
echo.
echo ========================================================
echo.

call :READ_CURRENT_VERSION "..\OSL-Server\version.json" CURRENT_SERVER_VERSION

echo 🖥️ OSL-Server

if not "!CURRENT_SERVER_VERSION!"=="" (
echo    Current version: !CURRENT_SERVER_VERSION!
)

echo.
echo    Leave empty to keep the current version.
echo.

set "SERVER_VERSION="
set /p "SERVER_VERSION=Enter version [X.Y.Z]: "

REM Remove spaces from the beginning and end.
set "SERVER_VERSION=!SERVER_VERSION: =!"

REM Use current version if input is empty.
if "!SERVER_VERSION!"=="" (
set "SERVER_VERSION=!CURRENT_SERVER_VERSION!"
)

echo.
echo    Checking version: [!SERVER_VERSION!]
echo.

call :VALIDATE_VERSION "!SERVER_VERSION!"

if errorlevel 1 (
echo ❌ Invalid version format.
echo.
echo    Expected format: X.Y.Z
echo    Example: 1.0.0
echo.
pause
goto GET_SERVER_VERSION
)

echo ✔ Version accepted: !SERVER_VERSION!
echo.

if "!BUILD_OVERLAY_WINDOWS!"=="1" goto GET_OVERLAY_VERSION
if "!BUILD_OVERLAY_LINUX!"=="1" goto GET_OVERLAY_VERSION

goto COMPUTE_BUILD_DATE

REM ==================================================
REM GET OVERLAY VERSION
REM ==================================================

:GET_OVERLAY_VERSION

cls

echo.
echo ========================================================
echo.
echo                     📦 VERSION SETUP
echo.
echo ========================================================
echo.

call :READ_CURRENT_VERSION "..\OSL-Overlay\version.json" CURRENT_OVERLAY_VERSION

echo 🎨 OSL-Overlay

if not "!CURRENT_OVERLAY_VERSION!"=="" (
echo    Current version: !CURRENT_OVERLAY_VERSION!
)

echo.
echo    Leave empty to keep the current version.
echo.

set "OVERLAY_VERSION="
set /p "OVERLAY_VERSION=Enter version [X.Y.Z]: "

REM Remove spaces from the beginning and end.
set "OVERLAY_VERSION=!OVERLAY_VERSION: =!"

REM Use current version if input is empty.
if "!OVERLAY_VERSION!"=="" (
set "OVERLAY_VERSION=!CURRENT_OVERLAY_VERSION!"
)

echo.
echo    Checking version: [!OVERLAY_VERSION!]
echo.

call :VALIDATE_VERSION "!OVERLAY_VERSION!"

if errorlevel 1 (
echo ❌ Invalid version format.
echo.
echo    Expected format: X.Y.Z
echo    Example: 1.0.0
echo.
pause
goto GET_OVERLAY_VERSION
)

echo ✔ Version accepted: !OVERLAY_VERSION!
echo.

goto COMPUTE_BUILD_DATE

REM ==================================================
REM BUILD DATE
REM ==================================================

:COMPUTE_BUILD_DATE

set "BUILD_DATE=%DATE%"
set "BUILD_TIME=%TIME%"
set "BUILD_TIME=!BUILD_TIME:~0,8!"

goto BUILD_SUMMARY

REM ==================================================
REM BUILD SUMMARY
REM ==================================================

:BUILD_SUMMARY

cls

echo ========================================================
echo.
echo                    📊 BUILD SUMMARY
echo.
echo ========================================================
echo.

echo 🔧 Configuration: !BUILD_CONFIGURATION!
echo 🏷️ Release type: !RELEASE_TYPE!
echo 📅 Build date: !BUILD_DATE!
echo 🕒 Build time: !BUILD_TIME!
echo.

if "!BUILD_SERVER!"=="1" (
echo 🖥️ OSL-Server
echo    Version: !SERVER_VERSION!
echo    Runtime: win-x64
echo.
)

if "!BUILD_OVERLAY_WINDOWS!"=="1" (
echo 🪟 OSL-Overlay
echo    Version: !OVERLAY_VERSION!
echo    Runtime: win-x64
echo.
)

if "!BUILD_OVERLAY_LINUX!"=="1" (
echo 🐧 OSL-Overlay
echo    Version: !OVERLAY_VERSION!
echo    Runtime: linux-x64
echo.
)

echo ========================================================
echo.

choice /C YN /N /M "Start build ? [Y/N]"

if errorlevel 2 (
echo.
echo Build cancelled. No file has been modified.
pause
goto MAIN_MENU
)

REM Version confirmed: this is the ONLY point where version.json / Version.props are written.
goto WRITE_VERSION_FILES

REM ==================================================
REM WRITE VERSION FILES (only reached if build confirmed)
REM ==================================================

:WRITE_VERSION_FILES

cls

echo.
echo ========================================================
echo.
echo                📝 UPDATING VERSION FILES
echo.
echo ========================================================
echo.

REM ------------------------------
REM OSL-SERVER
REM ------------------------------

if "!BUILD_SERVER!"=="1" (

echo 🖥️ Updating OSL-Server...

(
    echo {
    echo   "version": "!SERVER_VERSION!",
    echo   "releaseType": "!RELEASE_TYPE!"
    echo }
) > "..\OSL-Server\version.json"

(
    echo ^<Project^>
    echo   ^<PropertyGroup^>
    echo     ^<Version^>!SERVER_VERSION!^</Version^>
    echo     ^<AssemblyVersion^>!SERVER_VERSION!.0^</AssemblyVersion^>
    echo     ^<FileVersion^>!SERVER_VERSION!.0^</FileVersion^>
    echo   ^</PropertyGroup^>
    echo ^</Project^>
) > "..\OSL-Server\Version.props"

echo    ✔ version.json updated
echo    ✔ Version.props updated
echo.

)

REM ------------------------------
REM OSL-OVERLAY
REM ------------------------------

if "!BUILD_OVERLAY_WINDOWS!"=="1" goto WRITE_OVERLAY_FILES
if "!BUILD_OVERLAY_LINUX!"=="1" goto WRITE_OVERLAY_FILES

goto START_BUILDS

:WRITE_OVERLAY_FILES

echo 🎨 Updating OSL-Overlay...

(
echo {
echo   "version": "!OVERLAY_VERSION!",
echo   "releaseType": "!RELEASE_TYPE!"
echo }
) > "..\OSL-Overlay\version.json"

(
echo ^<Project^>
echo   ^<PropertyGroup^>
echo     ^<Version^>!OVERLAY_VERSION!^</Version^>
echo     ^<AssemblyVersion^>!OVERLAY_VERSION!.0^</AssemblyVersion^>
echo     ^<FileVersion^>!OVERLAY_VERSION!.0^</FileVersion^>
echo   ^</PropertyGroup^>
echo ^</Project^>
) > "..\OSL-Overlay\Version.props"

echo    ✔ version.json updated
echo    ✔ Version.props updated
echo.

REM ==================================================
REM START BUILDS
REM ==================================================

:START_BUILDS

if "!BUILD_SERVER!"=="1" (

call :BUILD_PROJECT ^
    "OSL-Server" ^
    "..\OSL-Server\OSL-Server.csproj" ^
    "win-x64" ^
    "..\OSL-Publish\OSL-Server\win-x64" ^
    "!SERVER_VERSION!"

if errorlevel 1 goto BUILD_ERROR

)

if "!BUILD_OVERLAY_WINDOWS!"=="1" (

call :BUILD_PROJECT ^
    "OSL-Overlay" ^
    "..\OSL-Overlay\OSL-Overlay.csproj" ^
    "win-x64" ^
    "..\OSL-Publish\OSL-Overlay\win-x64" ^
    "!OVERLAY_VERSION!"

if errorlevel 1 goto BUILD_ERROR

)

if "!BUILD_OVERLAY_LINUX!"=="1" (

call :BUILD_PROJECT ^
    "OSL-Overlay" ^
    "..\OSL-Overlay\OSL-Overlay.csproj" ^
    "linux-x64" ^
    "..\OSL-Publish\OSL-Overlay\linux-x64" ^
    "!OVERLAY_VERSION!"

if errorlevel 1 goto BUILD_ERROR

)

REM ==================================================
REM BUILD SUCCESS
REM ==================================================

:BUILD_SUCCESS

cls

echo.
echo ========================================================
echo.
echo               🎉 BUILD COMPLETED SUCCESSFULLY
echo.
echo ========================================================
echo.

echo 📁 Output directory:
echo.
echo    ..\OSL-Publish
echo.

pause

goto MAIN_MENU

REM ==================================================
REM BUILD ERROR
REM ==================================================

:BUILD_ERROR

color 0C

echo.
echo ========================================================
echo.
echo                    ❌ BUILD FAILED
echo.
echo ========================================================
echo.

echo An error occurred during the build.
echo Check the output above for more information.
echo.

pause

color 0B

goto MAIN_MENU

REM ==================================================
REM FUNCTIONS
REM ==================================================

REM ------------------------------
REM FIND 7-ZIP
REM ------------------------------
REM Locates 7z.exe once and stores its path (or command name) in SEVENZIP.
REM Tries, in order: PATH, then the two standard install locations.

:FIND_7ZIP

set "SEVENZIP="

where 7z.exe >nul 2>nul
if not errorlevel 1 (
set "SEVENZIP=7z.exe"
exit /b 0
)

if exist "%ProgramFiles%\7-Zip\7z.exe" (
set "SEVENZIP=%ProgramFiles%\7-Zip\7z.exe"
exit /b 0
)

if exist "%ProgramFiles(x86)%\7-Zip\7z.exe" (
set "SEVENZIP=%ProgramFiles(x86)%\7-Zip\7z.exe"
exit /b 0
)

exit /b 1

REM ------------------------------
REM CREATE ZIP
REM ------------------------------
REM %1 = source folder whose CONTENT must be zipped (not the folder itself)
REM %2 = destination .zip path (relative or absolute)
REM Returns errorlevel 1 if 7-Zip is missing or the archive could not be created.

:CREATE_ZIP

set "CZ_SOURCE_DIR=%~1"
set "CZ_ARCHIVE_PATH=%~2"

if "!SEVENZIP!"=="" (
echo    ⚠️ 7-Zip ^(7z.exe^) introuvable. Installe 7-Zip ou ajoute-le au PATH.
exit /b 1
)

REM Resolve the archive path to an absolute path BEFORE changing directory,
REM so it still points to the right place once we pushd into the source folder.
for %%F in ("!CZ_ARCHIVE_PATH!") do set "CZ_ARCHIVE_PATH_ABS=%%~fF"

if exist "!CZ_ARCHIVE_PATH_ABS!" (
del /F /Q "!CZ_ARCHIVE_PATH_ABS!"
)

pushd "!CZ_SOURCE_DIR!"

"!SEVENZIP!" a -tzip -r -bd -bb0 "!CZ_ARCHIVE_PATH_ABS!" "*" > nul

set "CZ_RESULT=!errorlevel!"

popd

exit /b !CZ_RESULT!

REM ------------------------------
REM ZIP PROJECT (existing publish folder only, no build)
REM ------------------------------

:ZIP_PROJECT

set "ZIP_PROJECT_NAME=%~1"
set "ZIP_OUTPUT_DIRECTORY=%~2"
set "ZIP_RUNTIME=%~3"
set "ZIP_VERSION_ROOT=%~4"

echo 🔎 !ZIP_PROJECT_NAME! ^(!ZIP_RUNTIME!^)

if not exist "!ZIP_OUTPUT_DIRECTORY!" (
echo    ⚠️ Folder not found, skipped: !ZIP_OUTPUT_DIRECTORY!
echo.
exit /b 0
)

REM Prefer the version recorded at build time (build-info.json).
REM Fall back to the project's version.json if it is missing.
set "ZIP_VERSION="

if exist "!ZIP_OUTPUT_DIRECTORY!\build-info.json" (
call :READ_CURRENT_VERSION "!ZIP_OUTPUT_DIRECTORY!\build-info.json" ZIP_VERSION
)

if "!ZIP_VERSION!"=="" (
call :READ_CURRENT_VERSION "!ZIP_VERSION_ROOT!\version.json" ZIP_VERSION
)

if "!ZIP_VERSION!"=="" (
set "ZIP_VERSION=unknown"
)

set "SAFE_ZIP_PROJECT_NAME=!ZIP_PROJECT_NAME: =-!"
set "ZIP_ARCHIVE_NAME=!SAFE_ZIP_PROJECT_NAME!-!ZIP_VERSION!-!ZIP_RUNTIME!.zip"

echo    📦 Creating !ZIP_ARCHIVE_NAME! ...

call :CREATE_ZIP "!ZIP_OUTPUT_DIRECTORY!" "..\OSL-Publish\!ZIP_ARCHIVE_NAME!"

if errorlevel 1 (
echo    ⚠️ Unable to create ZIP archive.
) else (
echo    ✔ ZIP archive created: !ZIP_ARCHIVE_NAME!
)

echo.

exit /b 0

REM ------------------------------
REM BUILD PROJECT
REM ------------------------------

:BUILD_PROJECT

set "PROJECT_NAME=%~1"
set "PROJECT_FILE=%~2"
set "RUNTIME=%~3"
set "OUTPUT_DIRECTORY=%~4"
set "PROJECT_VERSION=%~5"

cls

echo.
echo ========================================================
echo.
echo                  🔨 BUILDING !PROJECT_NAME!
echo.
echo ========================================================
echo.

echo 🧹 Cleaning previous build...

if exist "!OUTPUT_DIRECTORY!" (
rmdir /S /Q "!OUTPUT_DIRECTORY!"
)

echo.
echo 🚀 Publishing...
echo.

dotnet publish "!PROJECT_FILE!" ^
-c "!BUILD_CONFIGURATION!" ^
-r "!RUNTIME!" ^
-o "!OUTPUT_DIRECTORY!"

if errorlevel 1 (
exit /b 1
)

echo.
echo 📝 Creating build information...

(
echo {
echo   "version": "!PROJECT_VERSION!",
echo   "releaseType": "!RELEASE_TYPE!",
echo   "configuration": "!BUILD_CONFIGURATION!",
echo   "runtime": "!RUNTIME!",
echo   "buildDate": "!BUILD_DATE!",
echo   "buildTime": "!BUILD_TIME!"
echo }
) > "!OUTPUT_DIRECTORY!\build-info.json"

echo ✔ Build information created.

echo.
echo 📦 Creating ZIP archive...

REM PROJECT_NAME may already be hyphen-safe (see calls above), but strip
REM any remaining spaces defensively since spaces cause issues in
REM file names / paths.
set "SAFE_PROJECT_NAME=!PROJECT_NAME: =-!"

set "ARCHIVE_NAME=!SAFE_PROJECT_NAME!-!PROJECT_VERSION!-!RUNTIME!.zip"

call :CREATE_ZIP "!OUTPUT_DIRECTORY!" "..\OSL-Publish\!ARCHIVE_NAME!"

if errorlevel 1 (
echo.
echo ⚠️ Unable to create ZIP archive.
) else (
echo ✔ ZIP archive created: !ARCHIVE_NAME!
)

echo.
echo ✔ !PROJECT_NAME! build completed successfully.

exit /b 0

REM ------------------------------
REM READ CURRENT VERSION
REM ------------------------------

:READ_CURRENT_VERSION

set "%~2="

if not exist "%~1" (
exit /b 0
)

for /f "tokens=2 delims=:" %%A in ('findstr /I /C:""version"" "%~1"') do (

set "VERSION_VALUE=%%A"

REM Remove quotes, commas and spaces.
set "VERSION_VALUE=!VERSION_VALUE:"=!"
set "VERSION_VALUE=!VERSION_VALUE:,=!"
set "VERSION_VALUE=!VERSION_VALUE: =!"

set "%~2=!VERSION_VALUE!"

)

exit /b 0

REM ------------------------------
REM VALIDATE VERSION
REM ------------------------------

:VALIDATE_VERSION

set "VERSION_TO_VALIDATE=%~1"

REM Reject empty values.
if "!VERSION_TO_VALIDATE!"=="" (
exit /b 1
)

REM Validate strict X.Y.Z format.
REM Examples accepted:
REM 1.0.0
REM 2.1.4
REM 10.25.100
REM
REM Examples rejected:
REM 1.0
REM 1.0.0.1
REM v1.0.0
REM 1.a.0
REM
REM NOTE: the dot is escaped with \. so it matches a literal "."
REM instead of "any character" in the findstr regex engine.

echo(!VERSION_TO_VALIDATE!| findstr /R /X "[0-9][0-9]*\.[0-9][0-9]*\.[0-9][0-9]*" > nul

if errorlevel 1 (
exit /b 1
)

exit /b 0

REM ==================================================
REM EXIT
REM ==================================================

:EXIT

cls

echo.
echo ========================================================
echo.
echo                    👋 I'll be back
echo.
echo ========================================================
echo.

endlocal

exit /b 0