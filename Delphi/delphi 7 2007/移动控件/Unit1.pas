unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,UMove, ExtCtrls, StdCtrls;

type
  TForm1 = class(TForm)
    Label1: TLabel;
    Label2: TLabel;
    Label3: TLabel;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private

    { Private declarations }
  public
    { Public declarations }
  end;



var
  Form1: TForm1;
  tc:TComponeMove;
  MainControl : TWinControl ;

implementation

{$R *.dfm}


procedure TForm1.FormCreate(Sender: TObject);
begin
  tc:=TComponeMove.create(Self);
  tc.setModel;
  Form1.ParentWindow:=HWND_DESKTOP;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  p:TPanel;
begin
  p:=TPanel.Create(self);
  p.Width:=100;
  p.Height:=50;
  p.Parent:=Form1;
  p.ParentWindow:=HWND_DESKTOP;
  //tc:=TComponeMove.create(Self);
  tc.Free;
  tc:=TComponeMove.Create(Self);
  tc.setModel;
end;

end.
