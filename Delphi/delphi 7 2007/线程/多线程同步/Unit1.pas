unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    ListBox1: TListBox;
    Button2: TButton;
    Button3: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  CS: TRTLCriticalSection;
  hProcess: THandle; {���̾��}
  f: Integer;      {���������Э��һ�¸��߳������λ��}
  hMutex: THandle; {�������ľ��}


    

implementation

{$R *.dfm}

function MyThreadFun(p: Pointer): DWORD; stdcall;
var
  i: Integer;
begin
  EnterCriticalSection(CS);
  for i := 0 to 99 do Form1.ListBox1.Items.Add(IntToStr(i));
  LeaveCriticalSection(CS);
  Result := 0;
end;   

function MyThread1Fun1(p: Pointer): DWORD; stdcall;
begin
  if WaitForSingleObject(hProcess, INFINITE) = WAIT_OBJECT_0 then
    Form1.Text := Format('���� %d �ѹر�', [hProcess]);
  Result := 0;
end;

function MyThreadFun2(p: Pointer): DWORD; stdcall;
var
  i,y: Integer;
begin
  Inc(f);
  y := 20 * (f+5);
  for i := 0 to 1000 do
  begin
    if WaitForSingleObject(hMutex, INFINITE) = WAIT_OBJECT_0 then
    begin
      Form1.Canvas.Lock;
      Form1.Canvas.TextOut(140, y, IntToStr(i));
      Form1.Canvas.Unlock;
      Sleep(0); {���Ե���һ��, ��Ȼ��ʱ Canvas ��Э��������}
      ReleaseMutex(hMutex);
    end;
  end;
  Result := 0;
end;


procedure TForm1.Button1Click(Sender: TObject);
var
  ID: DWORD;
begin
  CreateThread(nil, 0, @MyThreadFun, nil, 0, ID);
  CreateThread(nil, 0, @MyThreadFun, nil, 0, ID);
  CreateThread(nil, 0, @MyThreadFun, nil, 0, ID);
end;
procedure TForm1.Button2Click(Sender: TObject);
var
  pInfo: TProcessInformation;
  sInfo: TStartupInfo;
  Path: array[0..MAX_PATH-1] of Char;
  ThreadID: DWORD;
begin
  {�Ȼ�ȡ���±���·��}
  GetSystemDirectory(Path, MAX_PATH);
  StrCat(Path, '\notepad.exe');

  {�� CreateProcess �򿪼��±�����ȡ����̾��, Ȼ�����̼߳���}
  FillChar(sInfo, SizeOf(sInfo), 0);
  if CreateProcess(Path, nil, nil, nil, False, 0, nil, nil, sInfo, pInfo) then
  begin
    hProcess := pInfo.hProcess;                           {��ȡ���̾��}
    Text := Format('���� %d ������', [hProcess]); 
    CreateThread(nil, 0, @MyThread1Fun1, nil, 0, ThreadID); {�����̼߳���}
  end;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  ThreadID: DWORD;
begin
  Repaint;
  f := 0;
  CreateThread(nil, 0, @MyThreadFun2, nil, 0, ThreadID);
  CreateThread(nil, 0, @MyThreadFun2, nil, 0, ThreadID);
  CreateThread(nil, 0, @MyThreadFun2, nil, 0, ThreadID);
  CreateThread(nil, 0, @MyThreadFun2, nil, 0, ThreadID);
  CreateThread(nil, 0, @MyThreadFun2, nil, 0, ThreadID);

end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  InitializeCriticalSection(CS);
  hMutex := CreateMutex(nil, False, nil);
end;

procedure TForm1.FormDestroy(Sender: TObject);
begin
  DeleteCriticalSection(CS);
  CloseHandle(hMutex);
end;

end.
