REM @ECHO OFF

set /P url= Enter Git Repository URL:

git clone %url%

git add -A

git commit -m "initial commit"

git checkout development

REM > NUL