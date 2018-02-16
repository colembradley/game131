REM @ECHO OFF

git add -A

set /P confirmation= Enter a message for this commit and push: 

git commit -m "%confirmation%"

git push

echo Successful

pause