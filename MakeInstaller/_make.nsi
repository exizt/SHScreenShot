; Script generated by the HM NIS Edit Script Wizard.
;-------------------------------------------------
; Unicode 를 지정해야, 처음에 언어선택 창이 뜬다
Unicode true


;-------------------------------------------------
; 버전 정보
; Major.Minor 사용자에게 알릴만한 변경점
; Release 단순 릴리즈 카운팅 (여태 몇번의 큰 변경이 있었는지)
; Build 테스팅 & 핫픽스 & 마이너 업데이트 & 코드 개선 등의 경우
!define S_APP_VER_MAJOR 2
!define S_APP_VER_MINOR 0
!define S_APP_VER_RELEASE 9
!define S_APP_VER_BUILD 3


;-------------------------------------------------
; 프로그램 그룹명 (폴더이름. 가급적 공백없이)
!define S_PROG_GROUP "SHSoft"

; 실행될 프로그램 exe 명
!define S_MAIN_EXE "SHScreenCapture.exe"
!define S_FILE_LOGO "_logo.ico"
!define S_PRODUCT_SIZE 4238 ;설치 크기 입니다. 언인스톨시에 참고 정보로 나옵니다.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "SH Screen Capture"
!define PRODUCT_VERSION "${S_APP_VER_MAJOR}.${S_APP_VER_MINOR}.${S_APP_VER_RELEASE}.${S_APP_VER_BUILD}"
!define PRODUCT_PUBLISHER "SH Software"
!define PRODUCT_WEB_SITE "https://chosim.asv.kr"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\${S_MAIN_EXE}"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"


; -------------------------------------------------
; 설치 경로
!define CUSTOM_INSTALL_DIR "$PROGRAMFILES64\${S_PROG_GROUP}\${PRODUCT_NAME}"
; 시작메뉴. 생성될 폴더 경로
!define CUSTOM_SM_DIR "$SMPROGRAMS\${PRODUCT_NAME}"
; 인스톨러 파일명
!define CUSTOM_INSTALLER "${PRODUCT_NAME}_${PRODUCT_VERSION}.exe"
!define CUSTOM_OUTFILE "installer/${CUSTOM_INSTALLER}"


;-------------------------------------------------
; MUI
!include "MUI2.nsh"


; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${S_FILE_LOGO}"
!define MUI_UNICON "${S_FILE_LOGO}"

; Language Selection Dialog Settings
!define MUI_LANGDLL_REGISTRY_ROOT "${PRODUCT_UNINST_ROOT_KEY}"
!define MUI_LANGDLL_REGISTRY_KEY "${PRODUCT_UNINST_KEY}"
!define MUI_LANGDLL_REGISTRY_VALUENAME "NSIS:Language"




;-------------------------------------------------
;Pages

  ; 설치 첫번째 페이지 (Welcome 페이지)
  !insertmacro MUI_PAGE_WELCOME
  ; 라이센스 페이지

  !insertmacro MUI_PAGE_LICENSE $(license)
  ; 설치 경로 페이지
  !insertmacro MUI_PAGE_DIRECTORY
  ; 설치 과정 페이지
  !insertmacro MUI_PAGE_INSTFILES
  ; 설치 완료 페이지
  !define MUI_FINISHPAGE_RUN "$INSTDIR\${S_MAIN_EXE}"
  !insertmacro MUI_PAGE_FINISH
  ; 언인스톨러 페이지
  !insertmacro MUI_UNPAGE_INSTFILES


;-------------------------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "Korean" ; 첫번째 언어가 디폴트
  !insertmacro MUI_LANGUAGE "English"

  LicenseLangString license ${LANG_ENGLISH} "license_en.txt"
  LicenseLangString license ${LANG_KOREAN} "license.txt"
;-------------------------------------------------
; 일반 변수들
Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "${CUSTOM_OUTFILE}"
InstallDir "${CUSTOM_INSTALL_DIR}"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

; 하단의 'nullsoft install system' 을 대체하는 문구
BrandingText " "
;-------------------------------------------------




; ---- Sections -----------------------------------------------------
Section "MainSection" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  File "${S_MAIN_EXE}"
  File "${S_FILE_LOGO}"
  CreateDirectory "${CUSTOM_SM_DIR}"
  CreateShortCut "${CUSTOM_SM_DIR}\${PRODUCT_NAME}.lnk" "$INSTDIR\${S_MAIN_EXE}"
  CreateShortCut "$DESKTOP\${PRODUCT_NAME}.lnk" "$INSTDIR\${S_MAIN_EXE}"
SectionEnd

Section -AdditionalIcons
  WriteIniStr "$INSTDIR\${PRODUCT_NAME}.url" "InternetShortcut" "URL" "${PRODUCT_WEB_SITE}"
  CreateShortCut "${CUSTOM_SM_DIR}\Website.lnk" "$INSTDIR\${PRODUCT_NAME}.url"
  CreateShortCut "${CUSTOM_SM_DIR}\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\${S_MAIN_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\${S_MAIN_EXE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLUpdateInfo" "${PRODUCT_WEB_SITE}"
  WriteRegDWORD ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "EstimatedSize" ${S_PRODUCT_SIZE}
SectionEnd


; Unstall Section
Section Uninstall
  Delete "$INSTDIR\${PRODUCT_NAME}.url"
  Delete "$INSTDIR\uninst.exe"
  Delete "$INSTDIR\${S_MAIN_EXE}"
  Delete "$INSTDIR\${S_FILE_LOGO}"

  Delete "${CUSTOM_SM_DIR}\Uninstall.lnk"
  Delete "${CUSTOM_SM_DIR}\Website.lnk"
  Delete "$DESKTOP\${PRODUCT_NAME}.lnk"
  Delete "${CUSTOM_SM_DIR}\${PRODUCT_NAME}.lnk"

  RMDir "${CUSTOM_SM_DIR}"
  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd
; ---- End of Sections -----------------------------------------------------



; ---- Functions -----------------------------------------------------
; 설치할 때
Function .onInit
  !insertmacro MUI_LANGDLL_DISPLAY
FunctionEnd


; uninstall question message
LangString message_Uninst ${LANG_ENGLISH} "$(^Name)을(를) 제거하시겠습니까?"
LangString message_Uninst ${LANG_KOREAN} "$(^Name)을(를) 제거하시겠습니까?"
; uninstall success message
LangString message_UninstSuccess ${LANG_ENGLISH} "$(^Name)는(은) 완전히 제거되었습니다."
LangString message_UninstSuccess ${LANG_KOREAN} "$(^Name)는(은) 완전히 제거되었습니다."


; 앱 삭제 완료된 후
Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(message_UninstSuccess)"
FunctionEnd


; 앱 삭제시 질문하는 단계
Function un.onInit
  !insertmacro MUI_UNGETLANGUAGE
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "$(message_Uninst)" IDYES +2
  Abort
FunctionEnd
; ---- End of Functions -----------------------------------------------------

