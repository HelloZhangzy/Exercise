unit gut2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, gut, cxLookAndFeelPainters, dxCntner, ActnList, cxMemo,
  cxGroupBox, cxMaskEdit, cxDropDownEdit, cxCalendar, cxTextEdit, StdCtrls,
  cxButtons, cxRadioGroup, cxControls, cxContainer, cxEdit, cxCheckBox,
  ExtCtrls,tablet_main;

type
  Tgut_fr1 = class(Tgut_fr)
    procedure CloseAndOffExecute(Sender: TObject);
    procedure FormShow(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  gut_fr1: Tgut_fr1;

implementation

{$R *.dfm}

procedure Tgut_fr1.CloseAndOffExecute(Sender: TObject);
begin
  
  // gut_fr.cxButton1.Caption:='保存';
 if cxButton2.Caption='取消' then
   hide
 else
   inherited;
end;

procedure Tgut_fr1.FormShow(Sender: TObject);
begin
  inherited;
  if Self.cxButton1.Caption='增加' then
    Self.cxButton1.Click;
  self.cxm_txt.SetFocus;
end;

end.
