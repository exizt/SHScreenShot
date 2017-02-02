#################################################
#
# ���� ��ũ��Ʈ
# @ ��ũ��Ʈ ���̽� : NSIS 3.0 Simpe example
# @ �ۼ��� : e2xist 
# 
#################################################

###
# Setting Part 1
# ���α׷��� ���� �κ�
#
!define S_APP_VER_MAJOR 1           ;�� �����ڵ� �Դϴ�. ������Ʈ�� ���� ����ģ ��쿡 ī��Ʈ�� ��ŵ�ϴ�.
!define S_APP_VER_MINOR 0           ;���̳� ������Ʈ �ÿ� ������ŵ�ϴ�.
!define S_APP_VER_BUILD  29             ;ī��Ʈ�� ��� ������ŵ�ϴ�. 
!define S_APP_NAME_DISPLAY "SH Screen Capture"  ;���α׷���Ī
!define S_APP_NAME_CODE "SHScreenCapture"     ;���α׷���Ī (�ַ� ���丮������ ���� ���̹Ƿ� ��ĭ���� ��������)
!define S_APP_COMPANY_DISPLAY "SH Software"  ;������
!define S_APP_COMPANY_CODE "SHSoft"             ;��ü�� �Ǵ� ���и� (�ַ� ���丮������ ���� ���̹Ƿ� ��ĭ���� ��������)
!define S_APP_DESCRIPTION "capture screen"     ;���α׷� ����
!define S_APP_VER "1.0"                                 ;���α׷� ��������
!define S_APP_EXE "application.exe"                  ;����� exe ����
!define S_UNINST_SIZE 1200 ;��ġ ũ�� �Դϴ�. ���ν���ÿ� ���� ������ ���ɴϴ�.
!define S_APP_HELP_URL "http://..." # "Support Information" link
!define S_APP_UPDATE_URL "http://..." # "Product Updates" link
!define S_APP_ABOUT_URL "http://..." # "Publisher" link
# !define S_APP_INSTALLER "SHCapture_1.0.26.exe"   ;������ �ν��緯 ���ϸ�

#######
# Setting Part 2
# Ư������ ���� ��쿡�� ������ص� �Ǵ� �κ�
#
# ���ν��緯�� ǥ�õ� �̸�
!define S_UNINST_DISPLAY "${S_APP_COMPANY_CODE} ${S_APP_NAME_DISPLAY} ${S_APP_VER}"
# ������Ʈ������ ������. �����ϸ� �������� �� ��.
!define S_UNINST_REGDIR "${S_APP_COMPANY_CODE} ${S_APP_NAME_CODE}"
# ������ �ν��緯 ���ϸ�
!define S_APP_INSTALLER "SHCapture_${S_APP_VER_MAJOR}.${S_APP_VER_MINOR}.${S_APP_VER_BUILD}.exe"   ;������ �ν��緯 ���ϸ�

# install
!define S_INSTALL_DIR "$PROGRAMFILES64\${S_APP_COMPANY_CODE}\${S_APP_NAME_CODE}" ;�ν���� ���

# start menu
!define S_SM_DIR "$SMPROGRAMS\${S_APP_COMPANY_CODE}" ;���۸޴�. ������ ���� ���
!define S_SM_LNK "${S_SM_DIR}\${S_APP_NAME_DISPLAY}.lnk" ;���۸޴�. ������ �ٷΰ��� ���


!define S_APP_ICON "_logo.ico"

RequestExecutionLevel admin ;Require admin rights on NT6+ (When UAC is turned on)
 
InstallDir "${S_INSTALL_DIR}"
 
# rtf or txt file - remember if it is txt, it must be in the DOS text format (\r\n)
LicenseData "_license.rtf"
# This will be in the installer/uninstaller's title bar
Name "${S_APP_COMPANY_DISPLAY} - ${S_APP_NAME_DISPLAY}"
Icon "_logo.ico"
outFile "installer/${S_APP_INSTALLER}"
 
!include LogicLib.nsh
 
# Just three pages - license agreement, install location, and installation
page license
page directory
Page instfiles
 
!macro VerifyUserIsAdmin
UserInfo::GetAccountType
pop $0
${If} $0 != "admin" ;Require admin rights on NT4+
        messageBox mb_iconstop "Administrator rights required!"
        setErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
        quit
${EndIf}
!macroend
 
function .onInit
	setShellVarContext all
	!insertmacro VerifyUserIsAdmin
functionEnd
 
section "install"
	# Files for the install directory - to build the installer, these should be in the same directory as the install script (this file)
	setOutPath $INSTDIR
	# Files added here should be removed by the uninstaller (see section "uninstall")
	file "${S_APP_EXE}"
	file "_logo.ico"
	# Add any other files for the install directory (license files, app data, etc) here
 
	# Uninstaller - See function un.onInit and section "uninstall" for configuration
	writeUninstaller "$INSTDIR\uninstall.exe"
 
	# Start Menu
	createDirectory "${S_SM_DIR}"
	createShortCut "${S_SM_LNK}" "$INSTDIR\${S_APP_EXE}" "" "$INSTDIR\${S_APP_ICON}"

	# desktop icon
	createShortCut "$DESKTOP\${S_APP_NAME_DISPLAY}.lnk" "$INSTDIR\${S_APP_EXE}" "" "$INSTDIR\${S_APP_ICON}"
 
	# Registry information for add/remove programs
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "DisplayName" "${S_UNINST_DISPLAY}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "UninstallString" "$\"$INSTDIR\uninstall.exe$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "QuietUninstallString" "$\"$INSTDIR\uninstall.exe$\" /S"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "InstallLocation" "$\"$INSTDIR$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "DisplayIcon" "$\"$INSTDIR\logo.ico$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "Publisher" "${S_APP_COMPANY_DISPLAY}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "HelpLink" "$\"${S_APP_HELP_URL}$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "URLUpdateInfo" "$\"${S_APP_UPDATE_URL}$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "URLInfoAbout" "$\"${S_APP_ABOUT_URL}$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "DisplayVersion" "${S_APP_VER_MAJOR}.${S_APP_VER_MINOR}.${S_APP_VER_BUILD}"
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "VersionMajor" ${S_APP_VER_MAJOR}
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "VersionMinor" ${S_APP_VER_MINOR}
	# There is no option for modifying or repairing the install
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "NoModify" 1
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "NoRepair" 1
	# Set the INSTALLSIZE constant (!defined at the top of this script) so Add/Remove Programs can accurately report the size
	WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}" "EstimatedSize" ${S_UNINST_SIZE}
sectionEnd
 
# Uninstaller
 
function un.onInit
	SetShellVarContext all
 
	#Verify the uninstaller - last chance to back out
	MessageBox MB_OKCANCEL "Permanantly remove ${S_APP_NAME_DISPLAY}?" IDOK next
		Abort
	next:
	!insertmacro VerifyUserIsAdmin
functionEnd


section "uninstall"
 
	# Remove Start Menu launcher
	delete "${S_SM_LNK}"
	# Try to remove the Start Menu folder - this will only happen if it is empty
	rmDir "${S_SM_DIR}"
 
	# Remove Desktop icon
	delete "$DESKTOP\${S_APP_NAME_DISPLAY}.lnk"

	# Remove files
	delete "$INSTDIR\${S_APP_EXE}"
	delete $INSTDIR\logo.ico
 
	# Always delete uninstaller as the last action
	delete $INSTDIR\uninstall.exe
 
	# Try to remove the install directory - this will only happen if it is empty
	rmDir $INSTDIR
 
	# Remove uninstaller information from the registry
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${S_UNINST_REGDIR}"
sectionEnd