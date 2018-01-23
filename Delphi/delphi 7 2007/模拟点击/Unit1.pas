unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Buttons, ExtCtrls, OleCtrls, SHDocVw, StdCtrls;

type
  TForm1 = class(TForm)
    SpeedButton1: TSpeedButton;
    SpeedButton2: TSpeedButton;
    Edit1: TEdit;
    Button1: TButton;
    Edit2: TEdit;
    Edit3: TEdit;
    Button2: TButton;
    Label1: TLabel;
    Timer1: TTimer;
    Timer2: TTimer;
    Timer3: TTimer;
    Button3: TButton;
    Button4: TButton;
    Label2: TLabel;
    Label3: TLabel;
    WebBrowser1: TWebBrowser;
    Label4: TLabel;
    Button5: TButton;
    Label5: TLabel;
    Label6: TLabel;
    procedure SpeedButton1Click(Sender: TObject);
    procedure SpeedButton2Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure Timer2Timer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Timer3Timer(Sender: TObject);
    procedure WebBrowser1Enter(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure WebBrowser1DocumentComplete(ASender: TObject;
      const pDisp: IDispatch; var URL: OleVariant);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure FormKeyDown(Sender: TObject; var Key: Word; Shift: TShiftState);
    procedure WebBrowser1NewWindow2(ASender: TObject; var ppDisp: IDispatch;
      var Cancel: WordBool);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  //Timer3.Enabled:=True;
  WebBrowser1.Navigate(Edit1.Text);
end;

procedure TForm1.Button2Click(Sender: TObject);
var
mhandle:HWND;
begin
   mhandle:=WebBrowser1.Handle;
   mhandle:=GetWindow(WebBrowser1.Handle,5); //获得webbrowse1的窗口句柄
   mhandle:=findWindowEx(mhandle,0,'Internet Explorer_Server',nil);    //获得webbrowser1的坐标
   SendMessage(mhandle,Messages.WM_LBUTTONDOWN,0,MAKELPARAM(StrToInt(Edit2.Text),StrToInt(Edit3.Text)));//按下
   SendMessage(mhandle,Messages.WM_LBUTTONUP,0, MAKELPARAM(StrToInt(Edit2.Text),StrToInt(Edit3.Text)));//抬起
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
Timer3.Enabled:=false;
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  Application.Terminate;
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  Timer3.Enabled:=True;
end;

procedure TForm1.FormKeyDown(Sender: TObject; var Key: Word;
  Shift: TShiftState);
begin
if Key=VK_CONTROL then
  begin
    Timer3.Enabled:=false;
  end;
end;

procedure TForm1.SpeedButton1Click(Sender: TObject);
begin
 SendMessage(Handle,Messages.WM_LBUTTONDOWN,0,MAKELPARAM(SpeedButton2.Left+5,SpeedButton2.top+5));//按下
 SendMessage(Handle,Messages.WM_LBUTTONUP,0, MAKELPARAM(SpeedButton2.Left+5,SpeedButton2.top+5));//抬起
end;

procedure TForm1.SpeedButton2Click(Sender: TObject);
begin
  ShowMessage('测试点击成功');
end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
 Timer1.Enabled:=False;
 SpeedButton1Click(sender);
end;

procedure TForm1.Timer2Timer(Sender: TObject);
begin
   Hide;
   Timer2.Enabled:=False;
   Timer1.Enabled:=true;
end;

procedure TForm1.Timer3Timer(Sender: TObject);
begin
  Edit2.Text:=IntToStr(Mouse.CursorPos.X);
  Edit3.Text:=IntToStr(Mouse.CursorPos.Y);
end;

procedure TForm1.WebBrowser1DocumentComplete(ASender: TObject;
  const pDisp: IDispatch; var URL: OleVariant);
begin
  //if WebBrowser1.Application = pDisp then
  //begin
    //timer3.Enabled:=False;
    //Edit2.Text:='326' ;
    //Edit3.Text:='166';
   // Button2Click(nil);
    //Show;
  //end;
end;

procedure TForm1.WebBrowser1Enter(Sender: TObject);
begin
  Timer3.Enabled:=false;
end;

procedure TForm1.WebBrowser1NewWindow2(ASender: TObject; var ppDisp: IDispatch;
  var Cancel: WordBool);
var
  NewWindow: TForm1;
begin
  NewWindow:= TForm1.Create(nil);
  NewWindow.Show;
  ppDisp:= NewWindow.Webbrowser1.DefaultDispatch;
end;

end.
