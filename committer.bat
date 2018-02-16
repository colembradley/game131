@ECHO OFF

git add -A

set /P message= Enter a message for this commit and push: 

git commit -m "%message%" > NUL

git push > NUL

echo Successful.

pause