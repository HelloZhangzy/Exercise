unit Ps_Label;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }

  public
    { Public declarations }
  end;


var
  Form1: TForm1;

implementation

{$R *.dfm}

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
var
  TmpHandle:THandle;
begin
  //AlphaBlend:=true;
 TmpHandle:=FindWindow('Progman',Nil);
  If TmpHandle<>0 Then
  Begin
    TmpHandle:=GetWindow(TmpHandle,GW_CHILD);
    Self.ParentWindow:=TmpHandle;
    BringWindowToTop(Self.Handle);
  End
  Else
    ShowMessage('找不到桌面,可能是Explorer已结束!');
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Self.ParentWindow:=0;
end;

end.
