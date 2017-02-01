copy ..\application\bin\Release\application.exe .
mkdir installer
"C:\Program Files (x86)\NSIS\makensis.exe" _make.nsi
pause
