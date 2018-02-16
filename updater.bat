@ECHO OFF

for /f %%a in ('git status -s') do set lines=%%a

IF %lines% > 0 (
	git pull --quiet
) ELSE (
	echo You have uncommitted changes. You must commit or revert changes first.
)


pause