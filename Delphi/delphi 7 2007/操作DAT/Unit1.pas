unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TPersonRecord=packed record
                       Name:string[20];
                       Sex:string[2];
                       Address:string[50];
                       Age:integer;
               end;


type
  TForm1 = class(TForm)
    Memo1: TMemo;
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

procedure TForm1.Button1Click(Sender: TObject);
var
  F:file of TPersonRecord;
  Count:Integer;
  PersonRec:TPersonRecord;
  i:integer;
begin
  AssignFile(F,ExtractFilePath(ParamStr(0))+'temp.dat');

  try
    Reset(F);
    Count:=FileSize(F);
   // Reset(F);
    //移动文件指针到指定位置
    for i:=0 to Count-1 do
    begin
      Seek(F,i);
      Read(F,PersonRec);
      Memo1.Lines.Add(PersonRec.Name);
      memo1.Lines.Add(PersonRec.Sex);
      memo1.Lines.Add(PersonRec.Address);
      Memo1.Lines.Add(IntToStr(PersonRec.Age))
    end;
  finally
    CloseFile(F);
  end;

end;

procedure TForm1.Button2Click(Sender: TObject);
var
  F:file of TPersonRecord;
begin
 AssignFile(F,ExtractFilePath(ParamStr(0))+'temp.dat');
  try

    Reset(F); 
    Seek(F,GetRecordCount);
    Write(F,PersonRec);
  finally
  
  end;
end;

end.
