program KeyToMW;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  ElAESCrypt in 'ElAESCrypt.pas',
  AESCrypt in 'AESCrypt.pas',
  DesCrypt in 'DESCrypt.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
