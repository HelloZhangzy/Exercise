Unit settings;

Interface

Uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  ExtCtrls, StdCtrls;

Type
  TSettingsForm = Class(TForm)
    Procedure Timer1Timer(Sender: TObject);
  Private
    { Private declarations }
  Public
    { Public declarations }
  End;

Var
  SettingsForm      : TSettingsForm;

Implementation

Uses unit1;

{$R *.DFM}

Procedure TSettingsForm.Timer1Timer(Sender: TObject);
Var w               : twincontrol;
Begin
  w := FindVCLWindow(Point(mouse.cursorpos.x, mouse.cursorpos.y));
  If w <> Nil Then caption := w.Name Else caption := 'nil';


End;

End.

