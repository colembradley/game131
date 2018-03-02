@ECHO OFF

set game131=https://github.com/colembradley/game131.git

set /P url= Enter Git Repository name:

IF "%url%"=="game131" set repoURL=%game131%

git clone %repoURL% --quiet

cd %url%

git checkout development --quiet

echo Successful.

pause