unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TMyThread = class(TThread)
  protected
    procedure Execute; override;
  end; 

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    ScrollBar1: TScrollBar;
    Button5: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  MyThread: TMyThread;
  public
    { Public declarations }
  end;





var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TMyThread.Execute;
var
  i: Integer;
begin
  FreeOnTerminate := True; {这可以让线程执行完毕后随即释放}
  i:=0;
//
//  for i := 0 to 500000 do
//  begin
  while not Terminated  do
  begin
    i:=i+1;
    Form1.Canvas.Lock;
    Form1.Canvas.TextOut(10, 10, IntToStr(i));
    Form1.Canvas.Unlock;
  end;
end;


procedure TForm1.Button1Click(Sender: TObject);
var
  i: Integer;
begin
  for i := 0 to 500000 do
  begin
    Canvas.TextOut(10, 10, IntToStr(i));
  end;
end;

function MyFun: Integer;
var
  i: Integer;
begin
  for i := 0 to 500000 do
  begin
    Form1.Canvas.Lock;
    Form1.Canvas.TextOut(10, 10, IntToStr(i));
    Form1.Canvas.Unlock;
  end;
  Result := 0;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
    MyFun;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  ID: THandle;
begin
  CreateThread(nil, 0, @MyFun, nil, 0, ID);
end;

procedure TForm1.Button4Click(Sender: TObject);
begin
  MyThread := TMyThread.Create(True);
  MyThread.Resume;
//   TMyThread.Create(False);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
MyThread.Terminate;
end;

end.
