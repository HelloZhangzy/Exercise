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
const cNum: WideString = '零壹贰叁肆伍陆柒捌玖--万仟佰拾亿仟佰拾万仟佰拾元角分';
     cCha:array[0..1, 0..12]of string =
     (( '零元','零拾','零佰','零仟','零万','零亿','亿万','零零零','零零','零万','零亿','亿万','零元'),
      ( '元','零','零','零','万','亿','亿','零','零','万','亿','亿','元'));
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
   if pos('零分',result)=0
     then Result := StringReplace(Result, '零角', '零', [rfReplaceAll])
     else Result := StringReplace(Result, '零角','整', [rfReplaceAll]);
   Result := StringReplace(Result, '零分','', [rfReplaceAll]);
end;

end.
