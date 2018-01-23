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

threadvar num1: Integer; {֧�ֶ��̵߳�ȫ�ֱ���}

var
  hThread: THandle; {�߳̾��}
  num: Integer;     {ȫ�ֱ���, ���ڼ�¼�����}
  
  pt: TPoint; {�������㽫����ָ��ķ�ʽ���ݸ��߳�, ��Ӧ����ȫ�ֵ�}



{�߳���ں���}
function MyThreadFun(p: Pointer): Integer; stdcall;
begin
  while True do {�����̲߳�����, ���ѭ����һֱѭ����ȥ}
  begin
    num := Random(100);
  end;
  Result := 0;
end;

function MyThreadFun2(p: Pointer): Integer; stdcall;
var
  i: Integer;
  pt2: TPoint;       {��Ϊָ��������ĵ���ʱ���ڱ�, �����̵߳ľֲ�����������}
begin
  pt2 := PPoint(p)^; {ת��}
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
    Sleep(1000); {Ȼ�̹߳��� 1 �����ټ���}
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
    Sleep(1000); {Ȼ�̹߳��� 1 �����ټ���}
  end;
end;

{�����������߳�}
procedure TForm1.Button1Click(Sender: TObject);
var
  ID: DWORD;
begin
  hThread := CreateThread(nil, 0, @MyThreadFun, nil, CREATE_SUSPENDED, ID);
  Button1.Enabled := False;
end;

{�����߳�}
procedure TForm1.Button2Click(Sender: TObject);
begin
   ResumeThread(hThread); 
end;

{�����߳�}
procedure TForm1.Button3Click(Sender: TObject);
begin
  SuspendThread(hThread);
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  ID: DWORD;
begin
  {����ں����Ĳ���������һ��������е� Y ֵ, ���ø��̰߳ѽ������ڲ�ͬλ��}
  CreateThread(nil, 0, @MyThreadFun3, Ptr(40), 0, ID);
  CreateThread(nil, 0, @MyThreadFun3, Ptr(60), 0, ID);
  CreateThread(nil, 0, @MyThreadFun3, Ptr(80), 0, ID);
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  ID: DWORD;
begin
  {����ں����Ĳ���������һ��������е� Y ֵ, ���ø��̰߳ѽ������ڲ�ͬλ��}
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
  {��������д���������, ��ʵ����, ��Ϊ PPoint ���Զ�ת��Ϊ Pointer ��}
  //CreateThread(nil, 0, @MyThreadFun, Pointer(@pt), 0, ID);


end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
  Text := IntToStr(num);
end;


end.
