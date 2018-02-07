@ECHO OFF

set /P url= Enter Git Repository URL:

git clone %url%

git checkout development

REM > NUL