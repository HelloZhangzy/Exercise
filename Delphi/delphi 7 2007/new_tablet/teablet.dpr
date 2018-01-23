program teablet;

uses
  Forms,
  tablet_main in 'tablet_main.pas' {teblet_fr},
  gut in 'gut.pas' {gut_fr},
  dat in 'dat.pas',
  sticker in 'sticker.pas' {sticker_fr},
  gut2 in 'gut2.pas' {gut_fr1},
  copyfilename in 'copyfilename.pas' {back_fr};

{$R *.res}

begin
  Application.Initialize; 
  Application.CreateForm(Tteblet_fr, teblet_fr);
  Application.CreateForm(Tgut_fr, gut_fr);
  Application.CreateForm(Tsticker_fr, sticker_fr);
  Application.CreateForm(Tgut_fr1, gut_fr1);
  Application.Run;
end.
