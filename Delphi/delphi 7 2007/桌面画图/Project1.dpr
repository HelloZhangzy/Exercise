program Project1;

uses
  Forms,
  Unit1 in 'Unit1.pas' {Form1},
  joffa in 'joffa.pas' {JoffaForm},
  bitmapregion in 'bitmapregion.pas',
  settings in 'settings.pas' {SettingsForm};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TJoffaForm, JoffaForm);
  Application.CreateForm(TSettingsForm, SettingsForm);
  Application.Run;
end.
