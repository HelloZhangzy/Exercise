unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,StrUtils;
  
const
  myArray:array[1..6,0..15] of Char=(('5','D','1','9','7','F','3','B','4','C','0','8','6','E','2','A'),
                                     ('2','A','6','E','0','8','4','C','3','B','7','F','1','9','5','D'),
                                     ('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B'),
                                     ('1','9','5','D','3','B','7','F','0','8','4','C','2','A','6','E'),
                                     ('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B'),
                                     ('F','7','B','3','D','5','9','1','E','6','A','2','C','4','8','0'));

  myCardNO:array[1..9,0..15] of Char=(('5','D','1','9','7','F','3','B','4','C','0','8','6','E','2','A'),
                                     ('2','A','6','E','0','8','4','C','3','B','7','F','1','9','5','D'),
                                     ('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B'),
                                     ('1','9','5','D','3','B','7','F','0','8','4','C','2','A','6','E'),
                                     ('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B'),
                                     ('F','7','B','3','D','5','9','1','E','6','A','2','C','4','8','0'),
                                     ('5','D','1','9','7','F','3','B','4','C','0','8','6','E','2','A'),
                                     ('2','A','6','E','0','8','4','C','3','B','7','F','1','9','5','D'),
                                     ('4','C','0','8','6','E','2','A','5','D','1','9','7','F','3','B'));

type
  TForm1 = class(TForm)
    GroupBox1: TGroupBox;
    Label1: TLabel;
    Memo1: TMemo;
    Button1: TButton;
    Edit1: TEdit;
    Button2: TButton;
    GroupBox2: TGroupBox;
    Label2: TLabel;
    Memo2: TMemo;
    Button3: TButton;
    Edit2: TEdit;
    Button4: TButton;
    GroupBox3: TGroupBox;
    Label3: TLabel;
    Memo3: TMemo;
    Button5: TButton;
    Edit3: TEdit;
    GroupBox4: TGroupBox;
    Label4: TLabel;
    Memo4: TMemo;
    Button7: TButton;
    Edit4: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure Edit1KeyPress(Sender: TObject; var Key: Char);
    procedure Button2Click(Sender: TObject);
    procedure Edit2KeyPress(Sender: TObject; var Key: Char);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Edit3KeyPress(Sender: TObject; var Key: Char);
    procedure Button7Click(Sender: TObject);
    procedure Edit4KeyPress(Sender: TObject; var Key: Char);
  private
    { Private declarations }
    function myPower(nT:Integer):Int64;
    procedure GetBase(niFalg,niCardNo:integer;var reiBase,reiDecPass:integer);
    function GetPassWordOrKey(niFlag:Integer;nsCardNo:string):string;
    function GetTwoPassOrKey(niFlag,niTwoCardNo,niBase:integer):integer;
    //function GetKey(nsCardNo:string):string;
   // function GetTwokey(niTwoCardNo,niBase:integer):integer;
  public
    { Public declarations }
  end;



var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
mi:integer;
i:integer;
nBase: Double;
msGas:string;
begin
  msGas:='';
  nBase := StrToFloat(Edit1.Text)*100;
//nBase:=1111.11*100;
  for i:=1 to 6 do
  begin
     mi := trunc(nBase/mypower(i)) mod 16;

     msGas := msGas + myarray[i,mi];
  end;
  Memo1.Lines.Add(Edit1.Text+'  '+msGas);
end;

function TForm1.myPower(nT:Integer):Int64;
var
  i:Integer;
  myV:Int64;
begin
  myV := 1;
  for i:=2 to nT do
  begin
     myV := myV *16;
  end;
  Result := myV;
end;
         
procedure TForm1.Button2Click(Sender: TObject);
var
mfGas:Double;
msGas:string;
myValue,i,j: Integer;
begin
  msGas:=Trim(edit1.Text);
  myValue:=0;
  for I := 1 to Length(msGas) do
  begin
      for j := 0 to 15 do
      begin
         if myArray[i][j]=msgas[i] then
         begin
           myValue:=myValue+j*myPower(i) ;//power(16,i);
         end;
      end;
  end;
  mfGas:=myValue/100;

  Memo1.Lines.Add(Edit1.Text+'->'+floattostr(mfgas));

end;

procedure TForm1.Button3Click(Sender: TObject);
var
mi,i:integer;
nBase: Double;
msCard:string;
begin
  msCard:='';
  nBase := StrToFloat(Edit2.Text);
  for i:=1 to 9 do
  begin
     mi := trunc(nBase/mypower(i)) mod 16;
     msCard := msCard + myCardNo[i,mi];
  end;
  Memo2.Lines.Add(Edit2.Text+'  '+msCard+'972');

end;

procedure TForm1.Button4Click(Sender: TObject);
var
myValue,mfCard:Int64;
msCard:string;
i,j: Integer;
begin
  msCard:=Trim(edit2.Text);
  myValue:=0;
  if Length(Trim(Edit2.Text))<9 then exit;

  for I := 1 to 9 do
  begin
      for j := 0 to 15 do
      begin
         if myArray[i][j]=msCard[i] then
         begin
           myValue:=myValue+j*myPower(i) ;
         end;
      end;
  end;
  Memo2.Lines.Add(Edit2.Text+'->'+inttostr(myValue));
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  i:Integer;
  msCardNo,msHexPass:string;
begin
  msCardNo:=Trim(edit3.Text);
  msHexPass:=GetPassWordOrKey(0,msCardNo);
  Memo3.Lines.Add(Edit3.Text+'——>'+mshexpass);
end;

procedure TForm1.Button7Click(Sender: TObject);
var
  i:Integer;
  msCardNo,msHexkey:string;
begin
  msCardNo:=Trim(edit4.Text);
  msHexkey:=GetPassWordOrKey(1,msCardNo);
  Memo4.Lines.Add(Edit4.Text+'——>'+msHexkey);
end;

procedure TForm1.GetBase(niFalg,niCardNo:integer;var reiBase,reiDecPass:integer);
  const
  maPassBase:array[0..100] of Integer=(163884,4423720,4423724,165928,165932,4425768,4425772,2277416,2277420,6537256,6537260,
      5476392,5476396,1218600,1218604,5478440,5478444,3330088,3330092,7589928,7589932,4260352,4260356,2560,2564,4262400,4262404,
      2114048,2114052,6373888,6373892,5313024,5313028,1055232,1055236,5315072,5315076,3166720,3166724,7426560,7426564,4260360,
      4260364,2568,2572,4262408,4262412,2114056,2114060,6373896,6373900,5313032,5313036,1055240,1055244,5315080,5315084,3166728,
      3166732,7426568,7426572,4424224,4424228,166432,166436,4426272,4426276,2277920,2277924,6537760,6537764,5476896,5476900,1219104,
      1219108,5478944,5478948,3330592,3330596,7590432,7590436,4424232,4424236,166440,166444,4426280,4426284,2277928,2277932,6537768,
      6537772,5476904,5476908,1219112,1219116,5478952,5478956,3330600,3330604,7590440,7590444);

  maKeyBase:array[0..100] of Integer=(6701071,4604045,6701197,4608015,6705167,4608141,6705293,4604427,6701579,4604553,6701705,
    4606085,6703237,4610055,6707207,4610181,6707333,4606467,6703619,4606593,6703745,5374413,7471565,5378383,7475535,5378509,7475661,
    5374795,7471947,5374921,7472073,5376453,7473605,5380423,7477575,5380549,7477701,5376835,7473987,5376961,7474113,4325837,6422989,
    4329807,6426959,4329933,6427085,4326219,6423371,4326345,6423497,4327877,6425029,4331847,6428999,4331973,6429125,4328259,6425411,
    4328385,6425537,5636237,7733389,5640207,7737359,5640333,7737485,5636619,7733771,5636745,7733897,5638277,7735429,5642247,7739399,
    5642373,7739525,5638659,7735811,5638785,7735937,4587661,6684813,4591631,6688783,4591757,6688909,4588043,6685195,4588169,6685321,
    4589701,6686853,4593671,6690823,4593797,6690949,4590083,6687235,4590209,6687361);
var
miBase,miCardNo,mi:Integer;
begin
  miBase:=9991;
  while miBase >=0  do
  begin
    if niCardNo >= miBase then  Break;
    miBase:=miBase-100;
  end;
  //if miBase<0 then miBase=0;
  mi:=Trunc(mibase/100);

  if niCardNo>=91 then   mi:=mi+1;
  reiBase:=miBase;
  if niFalg=0 then
    reiDecPass:=maPassBase[mi]
  else
    reiDecPass:=maKeyBase[mi];
end;

function TForm1.GetTwoPassOrKey(niFlag,niTwoCardNo,niBase:integer):integer;
begin
  if niFlag=0 then
  begin
    if (niTwoCardNo>=0) and (niTwoCardNo<11) then      Result:=niBase+8651920  else
    if (niTwoCardNo>=11) and (niTwoCardNo<31) then     Result:=niBase+8448  else
    if (niTwoCardNo>=31) and (niTwoCardNo<51) then     Result:=niBase+8397056  else
    if (niTwoCardNo>=51) and (niTwoCardNo<71) then     Result:=niBase+271760 else
    if (niTwoCardNo>=71) and (niTwoCardNo<91) then     Result:=niBase+8660368 else
    if niTwoCardNo>=91 then result:=niBase ;
  end
  else
  begin
     if (niTwoCardNo>=0) and (niTwoCardNo<11) then      Result:=niBase+598047  else
     if (niTwoCardNo>=11) and (niTwoCardNo<31) then     Result:=niBase+33792  else
     if (niTwoCardNo>=31) and (niTwoCardNo<51) then     Result:=niBase+33791  else
     if (niTwoCardNo>=51) and (niTwoCardNo<71) then     Result:=niBase+631840  else
     if (niTwoCardNo>=71) and (niTwoCardNo<91) then     Result:=niBase+631839 else
     if niTwoCardNo>=91 then result:=niBase;
  end;
end;    

function TForm1.GetPassWordOrKey(niFlag:Integer;nsCardNo:string):string; 
var
  i,miBase,miCardNo,miBasePassOrKey,miTwoPassOrKey,miDecPassOrKey:Integer;
  msCardNo:string;
begin
  msCardNo:=Trim(nsCardNo);
  miCardno:=StrToInt(RightStr(msCardNo,4));//取卡号后四位
  GetBase(niFlag,miCardNo,miBase,miBasePassOrKey); //获得基数
  micardno:=StrToInt(RightStr(msCardNo,2));//取卡号后两位
  miTwoPassOrKey:=GetTwoPassOrKey(niFlag,miCardNo,miBasePassOrKey); //获得二级密码
  micardno:=StrToInt(RightStr(msCardNo,1));//取卡号后一位
  if niFlag=0 then
  begin
    case miCardNo of
      1,2,9:
        miDecPassOrKey:= miTwoPassOrKey;
      3,4:
        miDecPassOrKey:=miTwoPassOrKey+524352;
      5,6:
        miDecPassOrKey:=miTwoPassOrKey+2;
      7,8,0:
        miDecPassOrKey:=miTwoPassOrKey+524354;
    end;
  end
  else
  begin
    case miCardNo of
      1,2,9:
        miDecPassOrKey:= miTwoPassOrKey;
      3,4:
        miDecPassOrKey:=miTwoPassOrKey-131056;
      5,6:
        miDecPassOrKey:=miTwoPassOrKey-4194304;
      7,8,0:
        miDecPassOrKey:=miTwoPassOrKey-4325360;
    end;
  end;
  Result:=IntToHex(miDecPassOrKey,6);
end;   

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
  if Key=#13 then
  begin
    Button1.Click;
  end;
end;

procedure TForm1.Edit2KeyPress(Sender: TObject; var Key: Char);
begin
   if Key=#13 then
  begin
    Button3.Click;
  end;
end;

procedure TForm1.Edit3KeyPress(Sender: TObject; var Key: Char);
begin
  if Key=#13 then
  begin
    Button5.Click;
  end;
end;

procedure TForm1.Edit4KeyPress(Sender: TObject; var Key: Char);
begin
  if Key=#13 then
  begin
    Button7.Click;
  end;
end;

end.
