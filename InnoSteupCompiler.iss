; -- Example1.iss --
; Demonstrates copying 3 files and creating an icon.

; SEE THE DOCUMENTATION FOR DETAILS ON CREATING .ISS SCRIPT FILES!

[Setup]
AppName=ClearFolder
AppVersion=1.0.0.0
DefaultDirName={sd}\ProgramData\Keahnignen\ClearFolder
DefaultGroupName=ClearFolder
UninstallDisplayIcon={app}\ClearFolder.exe
Compression=lzma2
SolidCompression=yes
OutputDir=.
AppPublisher=Keahnignen Software
OutputBaseFilename=ClearFolder_Installation

[Dirs]
Name: "{app}"; Permissions: users-full

[Files]
Source: "ClearFolder\bin\Debug\*"; DestDir: "{app}"

[Icons]
Name: "{group}\ClearFolder"; Filename: "{app}\ClearFolder.exe"
Name: "{userstartup}\ClearFolder"; Filename: "{app}\ClearFolder.exe";
;[Run]                                                                                                                                                                                   
; Filename: "{app}\NorN2N2DB.Configuration.exe";