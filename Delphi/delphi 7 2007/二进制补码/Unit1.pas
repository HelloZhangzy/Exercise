unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Button1: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    function HexToBit(msData: string; miLen: Integer): string;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}
procedure TForm1.Button1Click(Sender: TObject);
var
  msHex:string;
  midec:Integer;
begin
  midec:= not strtoint(edit1.Text);
  Memo1.Lines.Add(IntToStr(midec));
  memo1.Lines.Add(IntToHex(midec,2));
  memo1.lines.add(inttohex(strtoint(edit1.text),2));
end;

function TForm1.HexToBit(msData: string; miLen: Integer): string;
const  msBit:array[0..15] of string=
('0000','0001','0010','0011','0100','0101','0110','0111',
'1000','1001','1010','1011','1100','1101','1110','1111');
var
  mi,i:Integer;
begin
  result:='';
  for I := 0 to miLen - 1 do
  begin
    mi:=StrToInt('$'+Copy(msData,i+1,1));
    Result:=result+msbit[mi];
  end;
end;

end.
