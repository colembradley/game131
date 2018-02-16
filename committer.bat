@ECHO OFF

git add -A

set /P message= Enter a message for this commit and push: 

git commit -m "%message%"

git push

echo Successful.

pause