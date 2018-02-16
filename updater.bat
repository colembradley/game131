@ECHO OFF

echo You will lose all changes since the last pull. Are you sure? y/n

set /P confirmation= y/n:

IF %confirmation%==y (
	git reset --hard --quiet
	echo Changes have been reverted.
) ElSE (
	echo Cancelled.
)

pause