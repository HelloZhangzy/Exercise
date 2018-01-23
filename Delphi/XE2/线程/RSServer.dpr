program RSServer;

uses
  Vcl.Forms,
  MainFr in 'MainFr.pas' {MainFrom};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TMainFrom, MainFrom);
  Application.Run;
end.
