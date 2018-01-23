unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, StdCtrls,NewPanel, ImgList;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Panel1: tpanel;
    Image1: TImage;
    ImageList1: TImageList;
    procedure FormCreate(Sender: TObject);
    procedure Panel1MouseLeave(Sender: TObject);
    procedure Panel1MouseEnter(Sender: TObject);
    procedure Image1MouseEnter(Sender: TObject);
    procedure Image1MouseLeave(Sender: TObject);

  private
    { Private declarations }


  public
    { Public declarations }
    a:tnewpanel;
  end;
   procedure CMMouseLeave(Sender: TObject);
   procedure CMMouseEnter(Sender: TObject);

var
  Form1: TForm1;

implementation

{$R *.dfm}
 procedure CMMouseLeave(Sender: TObject);
 begin
    form1.a.caption:='c';
 end;
 procedure CMMouseEnter(Sender: TObject);
 begin
    form1.a.caption:='r';
 end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  a:= tnewpanel.Create(nil);
  a.Top:=1;
  a.Left:=1;
  a.Width:=100;
  a.Height:=100;
  a.Parent:=Form1;
//  a.OnMouseEnter:= CMMouseEnter(Sender);
//   a.OnMouseLeave := CMMouseLeave(Sender);
//  a.CMMouseLeave(msg);
//  a.CMMouseEnter(msg);
//showmessage();
  //a.Show;
end;

procedure TForm1.Image1MouseEnter(Sender: TObject);
begin
  ImageList1.GetIcon(1,Image1.Picture.Icon);
end;

procedure TForm1.Image1MouseLeave(Sender: TObject);
begin
ImageList1.GetIcon(0,Image1.Picture.Icon);
end;

procedure TForm1.Panel1MouseEnter(Sender: TObject);
begin
panel1.Caption:='1'
end;

procedure TForm1.Panel1MouseLeave(Sender: TObject);
begin
 panel1.Caption:='0'
end;

end.
