unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Button1: TButton;
    Label2: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    function NumToChar(const n: Real): string;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
begin
  Label2.Caption:=NumToChar(StrToFloat(Edit1.Text));
end;

function TForm1.NumToChar(const n: Real): string;
const cNum: WideString = '��Ҽ��������½��ƾ�--��Ǫ��ʰ��Ǫ��ʰ��Ǫ��ʰԪ�Ƿ�';
     cCha:array[0..1, 0..12]of string =
     (( '��Ԫ','��ʰ','���','��Ǫ','����','����','����','������','����','����','����','����','��Ԫ'),
      ( 'Ԫ','��','��','��','��','��','��','��','��','��','��','��','Ԫ'));
var i : Integer;
   sNum,sTemp : WideString;
begin
   result :='';
   sNum := format('%15d',[round(n * 100)]);
   for i := 0 to 14 do
   begin
     stemp := copy(snum,i+1,1);
     if stemp=' ' then continue
     else result := result + cNum[strtoint(stemp)+1] + cNum[i+13];
   end;
   for i:= 0 to 12 do
   Result := StringReplace(Result, cCha[0,i], cCha[1,i], [rfReplaceAll]);
   if pos('���',result)=0
     then Result := StringReplace(Result, '���', '��', [rfReplaceAll])
     else Result := StringReplace(Result, '���','��', [rfReplaceAll]);
   Result := StringReplace(Result, '���','', [rfReplaceAll]);
end;

end.
