{********************************************************
***                                                   ***
***                        破天惊工作室
***  名称:嵌入窗体之桌面嵌入
***  日期:12.9.2004
***  环境:Delphi6+WinXP
***  作者:破天惊
***  E-Mail:Tresss@sohu.com
***  HomePage:http://tresss.com
***
***  说明:
***                                                   ***
*********************************************************}
unit main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TFrmMain = class(TForm)
    Btn1: TButton;
    Timer1: TTimer;
    Edt1: TEdit;
    BtnOwner: TButton;
    Label1: TLabel;
    Btn2: TButton;
    Edt2: TEdit;
    Label2: TLabel;
    Btn3: TButton;
    Edt3: TEdit;
    Label3: TLabel;
    BtnRnd: TButton;
    procedure Timer1Timer(Sender: TObject);
    procedure BtnOwnerClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Btn1Click(Sender: TObject);
    procedure Btn2Click(Sender: TObject);
    procedure Btn3Click(Sender: TObject);
    procedure BtnRndClick(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FrmMain: TFrmMain;
  TmpHandle:THandle;

implementation

{$R *.dfm}

procedure TFrmMain.Timer1Timer(Sender: TObject);
begin
  FrmMain.ParentWindow:=0;
end;

procedure TFrmMain.BtnOwnerClick(Sender: TObject);
begin
  FrmMain.ParentWindow:=0;
end;

procedure TFrmMain.FormCreate(Sender: TObject);
begin
  TmpHandle:=FindWindow('Progman',Nil);
  If TmpHandle<>0 Then
  Begin
    Edt3.Text:=IntToStr(TmpHandle);
    TmpHandle:=GetWindow(TmpHandle,GW_CHILD);
    Edt2.Text:=IntToStr(TmpHandle);
    TmpHandle:=GetWindow(TmpHandle,GW_CHILD);
    Edt1.Text:=IntToStr(TmpHandle);
  End
  Else
    ShowMessage('找不到桌面,可能是Explorer已结束!');
end;

procedure TFrmMain.Btn1Click(Sender: TObject);
begin
  If Edt1.Text<>'' Then
  Begin
    FrmMain.ParentWindow:=StrToInt(Edt1.Text);
    BringWindowToTop(FrmMain.Handle);
  End;
end;

procedure TFrmMain.Btn2Click(Sender: TObject);
begin
  If Edt2.Text<>'' Then
  Begin
    FrmMain.ParentWindow:=StrToInt(Edt2.Text);
    BringWindowToTop(FrmMain.Handle);
  End;
end;

procedure TFrmMain.Btn3Click(Sender: TObject);
begin
  If Edt3.Text<>'' Then
  Begin
    FrmMain.ParentWindow:=StrToInt(Edt3.Text);
    BringWindowToTop(FrmMain.Handle);
  End;
end;

procedure TFrmMain.BtnRndClick(Sender: TObject);
begin
  If (Edt3.Text<>'') and (Edt2.Text<>'') Then
  Begin
    FrmMain.ParentWindow:=StrToInt(Edt3.Text);
    BringWindowToTop(FrmMain.Handle);
    FrmMain.Left:=0;
    MoveWindow(StrToInt(Edt2.Text),170,0,screen.Width-170,screen.Height,False);
  End; 
end;

end.
