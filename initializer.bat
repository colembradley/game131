@ECHO OFF

set /P url= Enter Git Repository URL:

git clone %url%

REM > NUL