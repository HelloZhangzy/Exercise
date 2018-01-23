unit main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, dxExEdtr, dxEdLib, dxCntner, dxEditor,ImgList, cxControls,
  cxContainer, cxEdit, cxTextEdit, cxMemo, StdCtrls, ExtCtrls,gut,
  cxListView, dxNavBarCollns, dxNavBarBase, dxNavBar, dxMasterView;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    ActiveStyleController: TdxEditStyleController;
    dxMasterView1: TdxMasterView;

    procedure FormCreate(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure ShowPanel(APanel: TPanel);
  private
    { Private declarations }
  public
    { Public declarations }
 end;
var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.ShowPanel(APanel: TPanel);

var
  I: Integer;
  AControl: TControl;
begin
  APanel.Parent := Panel2;
  APanel.Left := 0;
  APanel.Top := 0;
  //SetButtonsParent;
  APanel.Visible := True;
  for I := 0 to Panel2.ControlCount - 1 do
  begin
    AControl := Panel2.Controls[I];
    if (AControl is TPanel) and (AControl <> APanel) then
      AControl.Visible := False;
  end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
//edit1.Text:='dddddddddddddddddddddddddddddddddddddddddddddd';
//label1.Caption:='中国中国中国中国中国中国中国中国中国中国中国中国中国中国';
end;

procedure TForm1.FormShow(Sender: TObject);
begin
  ShowPanel(Form2.Panel1);
  ActiveStyleController:= Form2.StyleController;
end;

end.
