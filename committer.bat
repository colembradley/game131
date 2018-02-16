@ECHO OFF

git add -A

set /P message= Enter a message for this commit and push: 

git commit -m "%message%" --quiet

git push --quiet

echo Successful.

pause