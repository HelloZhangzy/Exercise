unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, RsaOpenSSL;

type
  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    GroupBox3: TGroupBox;
    GroupBox4: TGroupBox;
    Memo1: TMemo;
    Memo2: TMemo;
    Memo3: TMemo;
    Memo4: TMemo;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    Button8: TButton;
    Button9: TButton;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
  private
    { Private declarations }
    fRSAOpenSSL : TRSAOpenSSL;
  public
    { Public declarations }
  end;

  TMyThread1 = class(TThread)
  protected procedure Execute; override;
  end;

  TMyThread2 = class(TThread)
  protected procedure Execute; override;
  end;

  TMyThread3 = class(TThread)
  protected procedure Execute; override;
  end;

  TMyThread4 = class(TThread)
  protected procedure Execute; override;
  end;

var
  Form1: TForm1;
  Stop:Boolean;
  
implementation

{$R *.dfm}

procedure TForm1.FormCreate(Sender: TObject);
var
  aPathToPublickKey, aPathToPrivateKey: string;
begin
  aPathToPublickKey := 'public.pem';
  aPathToPrivateKey := 'private.pem';
  fRSAOpenSSL := TRSAOpenSSL.Create(aPathToPublickKey, aPathToPrivateKey);
  Stop:=false;
end;




procedure TForm1.Button1Click(Sender: TObject);
var
  aRSAData: TRSAData;
begin
  aRSAData.DecryptedData := Memo1.Text;
  fRSAOpenSSL.PublickEncrypt(aRSAData);
  if aRSAData.ErrorResult = 0 then
  memo2.Lines.Text := aRSAData.CryptedData;
  memo4.Lines.Add(aRSAData.ErrorMessage);

end;

procedure TForm1.Button2Click(Sender: TObject);
var
  aRSAData: TRSAData;
begin
  aRSAData.CryptedData := Memo2.Text;
  fRSAOpenSSL.PrivateDecrypt(aRSAData);
  if aRSAData.ErrorResult = 0 then
  memo3.Lines.Text := aRSAData.DecryptedData;
  memo4.Lines.Add(aRSAData.ErrorMessage);

end;

procedure TForm1.Button3Click(Sender: TObject);
var
  aRSAData: TRSAData;
begin
  aRSAData.DecryptedData := Memo1.Text;
  fRSAOpenSSL.PrivateEncrypt(aRSAData);
  if aRSAData.ErrorResult = 0 then
  memo2.Lines.Text := aRSAData.CryptedData;
  memo4.Lines.Add(aRSAData.ErrorMessage);

end;

procedure TForm1.Button4Click(Sender: TObject);
var
  aRSAData: TRSAData;
begin
  aRSAData.CryptedData := Memo2.Text;
  fRSAOpenSSL.PublicDecrypt(aRSAData);
  if aRSAData.ErrorResult = 0 then
  memo3.Lines.Text := aRSAData.DecryptedData;
  memo4.Lines.Add(aRSAData.ErrorMessage);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
  Memo3.Text := fRSAOpenSSL.SHA1(Memo1.Text);
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
  Memo3.Text := fRSAOpenSSL.SHA256(Memo1.Text);
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
  Memo3.Text := fRSAOpenSSL.SHA512(Memo1.Text);
end;

procedure TForm1.Button8Click(Sender: TObject);
var
  t1:TMyThread1;
  t2:TMyThread2;
  t3:TMyThread3;
  t4:TMyThread4;
begin
  t1:=TMyThread1.Create(True);
  t2:=TMyThread2.Create(True);
  t3:=TMyThread3.Create(True);
  t4:=TMyThread4.Create(True);
  t1.Resume;
  t2.Resume;
  t3.Resume;
  t4.Resume;
end;

procedure TForm1.Button9Click(Sender: TObject);
begin
Stop:=true;
//  t1.Terminate;
//  t2.Terminate;
//  t3.Terminate;
//  t4.Terminate;
end;

{ TMyThread }

procedure TMyThread1.Execute;
var
  aPathToPublickKey, aPathToPrivateKey: string;
  fRSAOpenSSL : TRSAOpenSSL;
  aRSAData: TRSAData;
begin
  aPathToPublickKey := 'public.pem';
  aPathToPrivateKey := 'private.pem';
  fRSAOpenSSL := TRSAOpenSSL.Create(aPathToPublickKey, aPathToPrivateKey);
  while(not Stop) do
  begin
  try
    aRSAData.DecryptedData := 'ABCDEFGHIGKLMNOPQRSTUVWXYZ';
    fRSAOpenSSL.PublickEncrypt(aRSAData);
//    if aRSAData.ErrorResult = 0 then Form1.memo2.Lines.Text := aRSAData.CryptedData;
//    Form1.memo4.Lines.Add(aRSAData.ErrorMessage);
  except  

  end;
    Sleep(1);
  end;
end;

{ TMyThread2 }

procedure TMyThread2.Execute;
var
  aPathToPublickKey, aPathToPrivateKey: string;
  fRSAOpenSSL : TRSAOpenSSL;
  aRSAData: TRSAData;
begin
  aPathToPublickKey := 'public.pem';
  aPathToPrivateKey := 'private.pem';
  fRSAOpenSSL := TRSAOpenSSL.Create(aPathToPublickKey, aPathToPrivateKey);
  while(not Stop) do
  begin
  try
    aRSAData.DecryptedData := 'ABCDEFGHIGKLMNOPQRSTUVWXYZ';
    fRSAOpenSSL.PublickEncrypt(aRSAData);
//    if aRSAData.ErrorResult = 0 then Form1.memo2.Lines.Text := aRSAData.CryptedData;
//    Form1.memo4.Lines.Add(aRSAData.ErrorMessage);
  except

  end;
    Sleep(1);
  end;

end;

{ TMyThread3 }

procedure TMyThread3.Execute;
var
  aPathToPublickKey, aPathToPrivateKey: string;
  fRSAOpenSSL : TRSAOpenSSL;
  aRSAData: TRSAData;
begin
  aPathToPublickKey := 'public.pem';
  aPathToPrivateKey := 'private.pem';
  fRSAOpenSSL := TRSAOpenSSL.Create(aPathToPublickKey, aPathToPrivateKey);
  while(not Stop) do
  begin
    try
    aRSAData.DecryptedData := 'ABCDEFGHIGKLMNOPQRSTUVWXYZ';
    fRSAOpenSSL.PublickEncrypt(aRSAData);
//    if aRSAData.ErrorResult = 0 then Form1.memo2.Lines.Text := aRSAData.CryptedData;
//    Form1.memo4.Lines.Add(aRSAData.ErrorMessage);
    except

    end;
    Sleep(1);
  end;
end;

{ TMyThread4 }

procedure TMyThread4.Execute;
var
  aPathToPublickKey, aPathToPrivateKey: string;
  fRSAOpenSSL : TRSAOpenSSL;
  aRSAData: TRSAData;
begin
  aPathToPublickKey := 'public.pem';
  aPathToPrivateKey := 'private.pem';
  fRSAOpenSSL := TRSAOpenSSL.Create(aPathToPublickKey, aPathToPrivateKey);
  while(not Stop) do
  begin
  try
    aRSAData.DecryptedData := 'ABCDEFGHIGKLMNOPQRSTUVWXYZ';
    fRSAOpenSSL.PublickEncrypt(aRSAData);
  except

  end;
//    if aRSAData.ErrorResult = 0 then Form1.memo2.Lines.Text := aRSAData.CryptedData;
//    Form1.memo4.Lines.Add(aRSAData.ErrorMessage);
    Sleep(1);
  end;
end;

end.
