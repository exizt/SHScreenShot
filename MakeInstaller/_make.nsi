#################################################
#
# 배포 스크립트
# @ 스크립트 베이스 : NSIS 3.0 Simpe example
# @ 작성자 : e2xist 
# 
#################################################

###
# Setting Part 1
# 프로그램별 설정 부분
#
!define S_APP_VER_MAJOR 1             ;주 버전코드 입니다. 프로젝트를 전부 뜯어고친 경우에 카운트업 시킵니다.
!define S_APP_VER_MINOR 0             ;마이너 업데이트 시에 증가시킵니다.
!define S_APP_VER_BUILD 8             ;카운트를 계속 증가시킵니다. 
!define S_APP_NAME_DISPLAY "SH Color Picker" ;프로그램명칭
!define S_APP_NAME_CODE "SHColorPicker"      ;프로그램명칭 (주로 디렉토리명으로 쓰일 것이므로 빈칸없이 영문으로)
!define S_APP_COMPANY_DISPLAY "SH Software"  ;배포자
!define S_APP_COMPANY_CODE "SHSoft"          ;업체명 또는 구분명 (주로 디렉토리명으로 쓰일 것이므로 빈칸없이 영문으로)
!define S_APP_DESCRIPTION "Choices and pick up color code"     ;프로그램 설명
!define S_APP_VER "1.0"                                 ;프로그램 버전정보
!define S_APP_EXE "SHColorPickup.exe"                  ;실행될 exe 파일
!define S_UNINST_SIZE 990 ;설치 크기 입니다. 언인스톨시에 참고 정보로 나옵니다.
!define S_APP_HELP_URL "http://..." # "Support Information" link
!define S_APP_UPDATE_URL "http://..." # "Product Updates" link
!define S_APP_ABOUT_URL "http://..." # "Publisher" link
#!define S_APP_INSTALLER "SHColorPicker_1.0.0.exe"   ;생성될 인스톨러 파일명

#######
# Setting Part 2
# 특별하지 않을 경우에는 변경안해도 되는 부분
#
!define S_UNINST_DISPLAY "${S_APP_COMPANY_CODE} ${S_APP_NAME_DISPLAY} ${S_APP_VER}" ;언인스톨러에 표시될 이름
!define S_UNINST_REGDIR "${S_APP_COMPANY_CODE} ${S_APP_NAME_CODE}" ;레지스트리에서 구분자. 가능하면 변경하지 말 것.
# 생성될 인스톨러 파일명
!define S_APP_INSTALLER "SHColorPicker_${S_APP_VER_MAJOR}.${S_APP_VER_MINOR}.${S_APP_VER_BUILD}.exe"   ;생성될 인스톨러 파일명

# install
!define S_INSTALL_DIR "$PROGRAMFILES64\${S_APP_COMPANY_CODE}\${S_APP_NAME_CODE}" ;인스톨될 경로

# start menu
!define S_SM_DIR "$SMPROGRAMS\${S_APP_COMPANY_CODE}" ;시작메뉴. 생성될 폴더 경로
!define S_SM_LNK "${S_SM_DIR}\${S_APP_NAME_DISPLAY}.lnk" ;시작메뉴. 생성될 바로가기 경로


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