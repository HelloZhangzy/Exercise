program RWCard_Pr;

uses
  Forms,
  RWCard in 'RWCard.pas' {RWCard_fr},
  HardWare in 'HardWare.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TRWCard_fr, RWCard_fr);
  Application.Run;
end.
