program Project1;

uses
  Forms,  Windows,
  Unit1 in 'Unit1.pas' {Form1};

{$R *.res}
  var
  hMutex: THandle;
const
  NameMutex = 'MyMutex';



begin
   {主线程入口}
  if OpenMutex(MUTEX_ALL_ACCESS, False, NameMutex) <> 0 then
  begin
    MessageBox(0, '该程序已启动', '提示', MB_OK);
    Application.Terminate;
  end;
  hMutex := CreateMutex(nil, False, NameMutex);

  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
  CloseHandle(hMutex);

end.
