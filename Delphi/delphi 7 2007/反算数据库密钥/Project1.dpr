program Project1;

uses
  Forms,
  AESCrypt in 'AESCrypt.pas',
  DESCrypt in 'DESCrypt.pas',
  ElAESCrypt in 'ElAESCrypt.pas',
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
