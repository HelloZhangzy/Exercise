unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, jpeg, StdCtrls;

const 
  WS_EX_LAYERED = $80000;
  AC_SRC_OVER = $0;
  AC_SRC_ALPHA = $1;
  AC_SRC_NO_PREMULT_ALPHA = $1;
  AC_SRC_NO_ALPHA = $2;
  AC_DST_NO_PREMULT_ALPHA = $10;
  AC_DST_NO_ALPHA = $20;
  LWA_COLORKEY = $1;
  LWA_ALPHA = $2;
  ULW_COLORKEY = $1;
  ULW_ALPHA = $2;
  ULW_OPAQUE = $4;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    Button1: TButton;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Panel1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure Panel1MouseDown(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure a(sender:TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;
 function SetLayeredWindowAttributes(hwnd:HWND; crKey:Longint; bAlpha:byte; dwFlags:longint ):longint; stdcall; external user32;
 
var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
  P:TPanel;
  i:timage;
  l:longint;
begin
    //l:=getWindowLong(Handle, GWL_EXSTYLE);
   // l := l Or WS_EX_LAYERED;
   // SetWindowLong (handle, GWL_EXSTYLE, l);
   // SetLayeredWindowAttributes (handle, 0, 120, LWA_ALPHA);

  //Brush.Bitmap := TBitmap.Create;
 // Brush.Bitmap.LoadFromFile(ExtractFilePath(ParamStr(0)) + '02.bmp');
 // Brush.Bitmap.FreeImage;

  p:=TPanel.Create(self);
  p.Parent:=Form1;
  p.Caption:='动态创建panel2';
  p.Name:='p1';
  p.Width:=200;
  p.Height:=100;
  p.left:=100;
  p.top:=20;
  p.OnClick:=a;
 
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  Brush.Bitmap.Free;
  Brush.Bitmap := nil;
end;

procedure TForm1.Panel1MouseMove(Sender: TObject; Shift: TShiftState; X,
  Y: Integer);
const
        SC_DragMove   =   $F012;     {   a   magic   number   }
  begin
    //  ReleaseCapture;
 // (Sender as TPanel).perform(WM_SysCommand,SC_DragMove,0);
 if (x>=0)and(x<=3) then
   begin
     if (y>=0)and(y<=3) then Panel1.Cursor:=crSizeNWSE;
     if (y>3)and(y<Panel1.Height-3) then Panel1.Cursor:=crSizeWE;
     if (y>=Panel1.Height-3)and(y<=Panel1.Height) then Panel1.Cursor:=crSizeNESW;
   end
   else if (x>3)and(x<Panel1.Width-3) then
   begin
     if (y>=0)and(y<=3) then Panel1.Cursor:=crSizeNS;
     if (y>3)and(y<Panel1.Height-3) then Panel1.Cursor:=crArrow;
     if (y>=Panel1.Height-3)and(y<=Panel1.Width) then Panel1.Cursor:=crSizeNS;
   end
   else if (x>=Panel1.Width-3)and(x<=Panel1.Width) then
   begin
     if (y>=0)and(y<=3) then Panel1.Cursor:=crSizeNESW;
     if (y>3)and(y<Panel1.Height-3) then Panel1.Cursor:=crSizeWE;
     if (y>=Panel1.Height-3)and(y<=Panel1.Width) then Panel1.Cursor:=crSizeNWSE;
   end;


end;

procedure TForm1.Panel1MouseDown(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
begin
 ReleaseCapture;
   if (x>=0)and(x<=3) then
   begin
     if (y>=0)and(y<=3) then Panel1.Perform(WM_SysCommand,$F004,0);
     if (y>3)and(y<Panel1.Height-3) then Panel1.Perform(WM_SysCommand,$F001,0);
     if (y>=Panel1.Height-3)and(y<=Panel1.Height) then Panel1.Perform(WM_SysCommand,$F007,0);
   end
   else if (x>3)and(x<Panel1.Width-3) then
   begin
     if (y>=0)and(y<=3) then Panel1.Perform(WM_SysCommand,$F003,0);
     if (y>3)and(y<Panel1.Height-3) then Panel1.Perform(WM_SysCommand,$F012,0);
     if (y>=Panel1.Height-3)and(y<=Panel1.Width) then Panel1.Perform(WM_SysCommand,$F006,0);
   end
   else if (x>=Panel1.Width-3)and(x<=Panel1.Width) then
   begin
     if (y>=0)and(y<=3) then Panel1.Perform(WM_SysCommand,$F005,0);
     if (y>3)and(y<Panel1.Height-3) then Panel1.Perform(WM_SysCommand,$F002,0);
     if (y>=Panel1.Height-3)and(y<=Panel1.Width) then Panel1.Perform(WM_SysCommand,$F008,0);
   end;

end;

procedure TForm1.a(sender: TObject);
begin
Form1.Caption:=(sender as TPanel).Caption;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  P:TPanel;
begin
 p:=TPanel.Create(self);
  p.Parent:=Form1;
  p.Caption:='动态创建panel';
  p.Name:='p2';
  p.Width:=200;
  p.Height:=100;
  p.left:=500;
  p.top:=220;
  p.OnClick:=a;
end;

end.
