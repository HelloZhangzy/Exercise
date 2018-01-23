unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    Memo1: TMemo;
    Panel1: TPanel;
    edt1: TEdit;
    btn1: TButton;
    Button1: TButton;
    procedure btn1Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

function read_from_buffer(buf:array of Byte;max_size:Integer):Integer;
var  ret,offset,i:Integer;  n:Byte;begin   ret:=0;   offset:=0;   for i:=0 to max_size-1 do   begin     offset:=offset+7;     n := buf[i];     if ((n and $80)<>$80) then
     begin
        ret :=ret or (n  shl offset);
     end
     else
     begin
      ret := ret or ((n and $7f) shl offset);
     end;
   end;
   Result:=ret;end;

function write_to_buffer(zz:Integer;var buf:array of Byte;size:Integer):Integer;
var
 ret:integer;
 i:integer;
begin
  for I := 0 to size-1 do
  begin
      if (zz and (not $7f) =0) then
      begin
          buf[i] := zz;
          ret := i +1;
      end else
      begin
        buf[i] := ((zz and $7f) or $80);
        zz := zz shr 7;
      end;
  end;
  Result:=0;
end;

function asc_hex(ascStr: PAnsiChar; var HexStr: array of Byte;
  lengths: smallint): Boolean;
var
  msAscStr,msHexStr,mstemp:AnsiString;
  i,j,temp:integer;
  tempchar:array of Byte;
begin
   try
    msAscStr:=Trim(StrPas(ascStr));
    msHexStr:='';
    SetLength(tempchar,lengths+10);
    i:=1;
    j:=0;
    while i<=lengths*2 do
    begin
      mstemp:=copy(msAscStr,i,2);
      temp:=strtoint('0x'+mstemp);
      tempchar[j]:=Byte(temp);
      inc(i,2);
      if j<Lengths then Inc(j);
    end;
    for i:=0 to lengths-1 do
    begin
    HexStr[i]:=tempchar[i];
    end;
    result:=True;
   except
    result:=False;
   end;
end;

function hex_asc(HexStr: PAnsiChar; var AscStr: array of AnsiChar;
  lengths: smallint): Boolean;
var
  msAscStr,msHexStr:AnsiString;
  i:integer;
  tempar:array of AnsiChar;
begin
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
      result:=True;
   except
      Result:=false;
   end;
end;

procedure TForm1.btn1Click(Sender: TObject);
var
  soure:Integer;
  ret:array[0..1] of Byte;
  ret_pc:array[0..3] of AnsiChar;
begin
  soure:=strtoint(edt1.text);
  write_to_buffer(soure,ret,SizeOf(ret));
  hex_asc(@ret[0],ret_pc,2);
  Memo1.lines.add(strpas(ret_pc));
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  soure_s:string;
  ascStr: PAnsiChar;
  HexStr: array[0..2] of Byte;
  ret_i:Integer;
begin
  soure_s:='';
  soure_s:=edt1.text;
  asc_hex(PAnsiChar(AnsiString(soure_s)),hexstr,2);
  ret_i:=read_from_buffer(hexstr,2);
  memo1.lines.add(inttostr(ret_i));
end;

end.
