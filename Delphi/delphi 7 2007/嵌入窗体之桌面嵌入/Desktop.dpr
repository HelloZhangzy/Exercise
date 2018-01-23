program Desktop;

uses
  Forms,
  main in 'main.pas' {FrmMain};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TFrmMain, FrmMain);
  Application.Run;
end.
