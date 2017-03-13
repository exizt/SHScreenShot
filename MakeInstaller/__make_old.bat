copy ..\application\bin\Release\SHScreenCapture.exe .
mkdir installer
"C:\Program Files (x86)\NSIS\makensis.exe" _make.nsi
pause
