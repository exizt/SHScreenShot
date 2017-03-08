copy ..\application\bin\Release\SHColorPickup.exe .
mkdir installer
"C:\Program Files (x86)\NSIS\makensis.exe" _make.nsi
pause
