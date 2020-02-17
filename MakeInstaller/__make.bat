copy ..\application\bin\Release\SHScreenCapture.exe .\source
copy ..\application\bin\Release\Microsoft.WindowsAPICodePack.dll .\source
copy ..\application\bin\Release\Microsoft.WindowsAPICodePack.Shell.dll .\source
@echo off
if not exist installer (mkdir installer)
"C:\Program Files (x86)\NSIS\makensis.exe" /INPUTCHARSET UTF8 _make.nsi
pause
