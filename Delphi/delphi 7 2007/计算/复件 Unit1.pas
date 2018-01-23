unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Memo1: TMemo;
    Button1: TButton;
    Edit1: TEdit;
    Label1: TLabel;
    Button2: TButton;
    procedure Button1Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
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
mi,i:integer;
msGas:string;
const
one:array[0..15] of char=('5','D','1','9','7','F','3','B','4','C','0','8','6','E','2','A');
two:array[0..15] of char=('2','A','6','E','0','8','4','C','3','B','7','F','1','9','5','D');
three:array[0..15] of char=('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B');
//four:array[0..15] of char=('1','9','5','D','2','A','6','E','0','8','4','C','3','B','7','F');
four:array[0..15] of char=('1','9','5','D','3','B','7','F','0','8','4','C','2','A','6','E');
five:array[0..15] of char=('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B');
//six :array[0..15] of char=('F','7','B','3','C','4','8','0','E','6','A','2','D','5','9','1');
SIX:array[0..15] OF Char=('F','7','B','3','D','5','9','1','E','6','A','2','C','4','8','0');

begin
msgas:='';
  mi:=trunc(StrToFloat(Edit1.Text)*100) mod 16;
  msgas:=msgas+one[mi];
  mi:=trunc(trunc(StrToFloat(Edit1.Text)*100)/16) mod 16;
  msgas:=msgas+two[mi];
  mi:=trunc(trunc(StrToFloat(Edit1.Text)*100)/256) mod 16;
  msgas:=msgas+three[mi];
  mi:=trunc(trunc(StrToFloat(Edit1.Text)*100)/4096) mod 16;
  msgas:=msgas+four[mi];
   mi:=trunc(trunc(StrToFloat(Edit1.Text)*100)/65536) mod 16;
  msgas:=msgas+five[mi];
  mi:=trunc(trunc(StrToFloat(Edit1.Text)*100)/1048576) mod 16;
  msgas:=msgas+six[mi];
 Memo1.Lines.Add(Edit1.Text+'  '+msgas);

 
end;

procedure TForm1.Button2Click(Sender: TObject);
var
mi,j,i,mi1,mi2,mi3,mi4,mi5,mi6,migas:integer;
mfGas:Double;
msGas:string;
const
one:array[0..15] of char=('5','D','1','9','7','F','3','B','4','C','0','8','6','E','2','A');
two:array[0..15] of char=('2','A','6','E','0','8','4','C','3','B','7','F','1','9','5','D');
three:array[0..15] of char=('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B');
four:array[0..15] of char=('1','9','5','D','3','B','7','F','0','8','4','C','2','A','6','E');
five:array[0..15] of char=('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B');
SIX:array[0..15] OF Char=('F','7','B','3','D','5','9','1','E','6','A','2','C','4','8','0'); 
begin
  msGas:=Trim(edit1.Text);
  for I := 1 to Length(msGas) do
  begin
    case i of
    1:
    begin
      for j := 0 to 15 do
      begin
         if one[j]=msgas[i] then
         begin
           mi1:=j;
           break;
         end;
      end;
    end;
    2:
    begin
       for j := 0 to 15 do
      begin
         if two[j]=msgas[i] then
         begin
           mi2:=j;
           break;
         end;
      end;
    end;
    3:
    begin
      for j := 0 to 15 do
      begin
         if three[j]=msgas[i] then
         begin
           mi3:=j;
           break;
         end;
      end;
    end;
    4:
    begin
      for j := 0 to 15 do
      begin
         if four[j]=msgas[i] then
         begin
           mi4:=j;
           break;
         end;
      end;
    end;
    5:
    begin
       for j := 0 to 15 do
      begin
         if five[j]=msgas[i] then
         begin
           mi5:=j;
           break;
         end;
      end;
    end;
    6:
    begin
      for j := 0 to 15 do
      begin
         if SIX[j]=msgas[i] then
         begin
           mi6:=j;
           break;
         end;
      end;
    end;
    end;
  end;
  migas:=mi1+mi2*16+mi3*256+mi4*4096+mi5*65536+mi6*1048576;
  mfGas:=migas/100;

  Memo1.Lines.Add(Edit1.Text+'->'+floattostr(mfgas));   

end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if Key=#13 then
  begin
    Button1.Click;
  end;
end;

end.
