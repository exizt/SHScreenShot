copy ..\application\bin\Release\SHScreenCapture.exe .
@echo off
if not exist installer (mkdir installer)
"C:\Program Files (x86)\NSIS\makensis.exe" _make.nsi
pause
