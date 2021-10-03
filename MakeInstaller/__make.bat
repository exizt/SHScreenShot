@ECHO OFF
if not exist source (mkdir source)
if not exist installer (mkdir installer)
copy ..\application\bin\Release\SHScreenCapture.exe .\source
copy ..\application\bin\Release\Microsoft.WindowsAPICodePack.dll .\source
copy ..\application\bin\Release\Microsoft.WindowsAPICodePack.Shell.dll .\source
"C:\Program Files (x86)\NSIS\makensis.exe" /INPUTCHARSET UTF8 _make.nsi
pause
