unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Timer1: TTimer;
    Button4: TButton;
    Button5: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
    procedure GroupBox1MouseUp(Sender: TObject; Button: TMouseButton;
      Shift: TShiftState; X, Y: Integer);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

threadvar num1: Integer; {支持多线程的全局变量}

var
  hThread: THandle; {线程句柄}
  num: Integer;     {全局变量, 用于记录随机数}
  
  pt: TPoint; {这个坐标点将会已指针的方式传递给线程, 它应该是全局的}



{线程入口函数}
function MyThreadFun(p: Pointer): Integer; stdcall;
begin
  while True do {假如线程不挂起, 这个循环将一直循环下去}
  begin
    num := Random(100);
  end;
  Result := 0;
end;

function MyThreadFun2(p: Pointer): Integer; stdcall;
var
  i: Integer;
  pt2: TPoint;       {因为指针参数给的点随时都在变, 需用线程的局部变量存起来}
begin
  pt2 := PPoint(p)^; {转换}
  for i := 0 to 1000000 do
  begin
    with Form1.Canvas do begin
      Lock;
      TextOut(pt2.X, pt2.Y, IntToStr(i));
      Unlock;
    end;
  end;
  Result := 0;
end;

function MyThreadFun3(p: Pointer): DWORD; stdcall;
var
  py: Integer;
begin
  py := Integer(p);
  while True do
  begin
    Inc(num);
    with Form1.Canvas do begin
      Lock;
      TextOut(20, py, IntToStr(num));
      Unlock;
    end;
    Sleep(1000); {然线程挂起 1 秒钟再继续}
  end;
end;

function MyThreadFun4(p: Pointer): DWORD; stdcall;
var
  py: Integer;
begin
  py := Integer(p);
  while True do
  begin
    Inc(num);
    with Form1.Canvas do begin
      Lock;
      TextOut(20, py, IntToStr(num1));
      Unlock;
    end;
    Sleep(1000); {然线程挂起 1 秒钟再继续}
  end;
end;

{建立并挂起线程}
procedure TForm1.Button1Click(Sender: TObject);
var
  ID: DWORD;
begin
  hThread := CreateThread(nil, 0, @MyThreadFun, nil, CREATE_SUSPENDED, ID);
  Button1.Enabled := False;
end;

{唤醒线程}
procedure TForm1.Button2Click(Sender: TObject);
begin
   ResumeThread(hThread); 
end;

{挂起线程}
procedure TForm1.Button3Click(Sender: TObject);
begin
  SuspendThread(hThread);
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  ID: DWORD;
begin
  {借入口函数的参数传递了一个坐标点中的 Y 值, 以让各线程把结果输出在不同位置}
  CreateThread(nil, 0, @MyThreadFun3, Ptr(40), 0, ID);
  CreateThread(nil, 0, @MyThreadFun3, Ptr(60), 0, ID);
  CreateThread(nil, 0, @MyThreadFun3, Ptr(80), 0, ID);
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  ID: DWORD;
begin
  {借入口函数的参数传递了一个坐标点中的 Y 值, 以让各线程把结果输出在不同位置}
  CreateThread(nil, 0, @MyThreadFun4, Ptr(48), 0, ID);
  CreateThread(nil, 0, @MyThreadFun4, Ptr(68), 0, ID);
  CreateThread(nil, 0, @MyThreadFun4, Ptr(88), 0, ID);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  Timer1.Interval := 10;
end;

procedure TForm1.GroupBox1MouseUp(Sender: TObject; Button: TMouseButton;
  Shift: TShiftState; X, Y: Integer);
var
  ID: DWORD;
begin
  pt := Point(X, Y);
  CreateThread(nil, 0, @MyThreadFun2, @pt, 0, ID);
  {下面这种写法更好理解, 其实不必, 因为 PPoint 会自动转换为 Pointer 的}
  //CreateThread(nil, 0, @MyThreadFun, Pointer(@pt), 0, ID);


end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
  Text := IntToStr(num);
end;


end.
