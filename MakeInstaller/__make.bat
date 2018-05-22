copy ..\application\bin\Release\SHScreenCapture.exe .
@echo off
if not exist installer (mkdir installer)
"C:\Program Files (x86)\NSIS\makensis.exe" /INPUTCHARSET UTF8 _make.nsi
pause
