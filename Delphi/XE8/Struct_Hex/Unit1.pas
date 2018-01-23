unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls,DBXJSON, DBXJSONReflect,system.JSON,system.JSONConsts,superobject;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

  type
  CommandData=record
    CmdCode:byte;
    meterID_0:byte;
    Price:word;
    RechargeAmount:Word;
    Reserve:byte;
    meterID_1:byte;
    Keys:array[0..5] of byte;
    temp_1:array[0..4] of boolean;
    temp_2:array[0..4] of AnsiChar;
  end;

  HeadData=record
    headInfo:byte;
    CmdInfo:byte;
    meterID:array[0..3] of Byte;
    KeyNum:byte;
    Ser:byte;
  end;
var
  Form1: TForm1;

implementation

{$R *.dfm}


function hex_asc(HexStr: PAnsiChar;var AscStr: array of AnsiChar;lengths: smallint):smallint;
var
  msAscStr,msHexStr:AnsiString;
  i:integer;
  tempar:array of AnsiChar;
begin
   result:=-1;
   try
      msHexStr:=HexStr;
      msAscStr:='';
      SetLength(tempar,lengths*2+10);
      i:=0;
      while i<lengths do
      begin
          msAscStr:=inttohex(ord(HexStr[i]),2);
          tempar[i*2]:=msAscStr[1];
          tempar[i*2+1]:=msAscStr[2];
          Inc(i);
      end;
      for i:=0 to lengths*2 do
      begin
         AscStr[i]:=tempar[i];
      end;
      result:=0;
   except
   end;
end;

function asc_hex(ascStr: PAnsiChar;var HexStr: array of byte;lengths: smallint):smallint;
var
  msAscStr,msHexStr,mstemp:AnsiString;
  i,j,temp:integer;
  tempchar:array of Byte;
begin
   result:=-1;
   msAscStr:=Trim(StrPas(ascStr));
   msHexStr:='';
   SetLength(tempchar,lengths+10);
   i:=1;
   j:=0;
   try
      while i<=lengths*2 do
      begin
         mstemp:=copy(msAscStr,i,2);
         temp:=strtoint('0x'+mstemp);
         tempchar[j]:=temp;
         inc(i,2);
         if j<Lengths then   Inc(j);
      end;
      Move(tempchar,HexStr,Lengths);
//      for i:=0 to lengths-1 do
//      begin
//         HexStr[i]:=tempchar[i];
//      end;
      result:=0;
   except
    result:=1;
   end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  pro:CommandData;
  pro2:CommandData;
  Data:array[0..SizeOf(pro)] of byte;
  reData:array[0..SizeOf(pro)*2] of AnsiChar;
  HexData :array[0..SizeOf(pro)] of byte;
  temp_s:AnsiString;
  lMarshal: TJSONMarshal;
  lJSONValue: TJSONValue;
  json:ISuperObject;
  temp:Word;
  temp_b: array[0..1] of Byte;
begin
  pro.CmdCode:=$81;
  pro.RechargeAmount:=1000;
  pro.Reserve:=255;
  pro.meterID_0:=1;
  pro.meterID_1:=1;
  pro.Price:=100;
  pro.Keys[0]:=$10;
  pro.Keys[1]:=$20;
  pro.Keys[2]:=$30;
  pro.Keys[3]:=$40;
  pro.Keys[4]:=$50;
  pro.Keys[5]:=$60;
  Memo1.Lines.Add(IntToStr(SizeOf(pro)));
  move(pro,Data[0],length(Data));
  hex_asc(@Data[0],reData,SizeOf(pro));
  temp_s:=AnsiString(reData);
  Memo1.Lines.Add(temp_s);


  asc_hex(PAnsiChar(AnsiString(temp_s)),HexData,SizeOf(CommandData));
  move(HexData[0], pro2, sizeof(pro2));
  Memo1.Lines.Add(IntToHex(pro2.CmdCode,2));

  Memo1.Lines.Add(IntToStr(SizeOf(LongWord)));

  temp:=1;
  Move(temp,temp_b,2);
  Memo1.Lines.Add(IntToStr(temp_b[0]));
  Memo1.Lines.Add(IntToStr(temp_b[1]));

//  lMarshal:=TJSONMarshal.Create(TJSONConverter.Create);
//  lJSONValue:=lMarshal.Marshal(pro2);  //ÐòÁÐ»¯
//  json:=SO(lJSONValue.tostring);
//  lJSONValue.Free;
////  json.S[JSCmd]:=cmd;
//  //CmdData:=json['fields'].AsString;
//    Memo1.Lines.Add(json['fields'].AsString);
end;

end.
