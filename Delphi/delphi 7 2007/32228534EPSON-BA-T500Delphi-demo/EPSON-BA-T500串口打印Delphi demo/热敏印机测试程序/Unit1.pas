unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, SPComm, ExtCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Label1: TLabel;
    Memo1: TMemo;
    Edit1: TEdit;
    Memo2: TMemo;
    Label2: TLabel;
    Label3: TLabel;
    Button3: TButton;
    CheckBox1: TCheckBox;
    Button4: TButton;
    Button5: TButton;
    Button6: TButton;
    Button7: TButton;
    CheckBox2: TCheckBox;
    Button8: TButton;
    Button9: TButton;
    Button10: TButton;
    Button11: TButton;
    Button12: TButton;
    Button13: TButton;
    Timer1: TTimer;
    Comm1: TComm;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button8Click(Sender: TObject);
    function SendStr(str:string):string;
    function SendStrln(str:string):string;
    function SendComm(str:string):string;
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
    procedure Button7Click(Sender: TObject);
    procedure Comm1ReceiveData(Sender: TObject; Buffer: Pointer;
      BufferLength: Word);
    procedure Button4Click(Sender: TObject);
    procedure Button10Click(Sender: TObject);
    procedure Button11Click(Sender: TObject);
    procedure Button12Click(Sender: TObject);
    procedure Button13Click(Sender: TObject);
    procedure Button9Click(Sender: TObject);
    procedure Timer1Timer(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

function StrToHexStr(const S:string):string;
//�ַ���ת����16�����ַ���
var
  I:Integer;
begin
  for I:=1 to Length(S) do
  begin
    if I=1 then
      Result:=IntToHex(Ord(S[1]),2)
    else Result:=Result+' '+IntToHex(Ord(S[I]),2);
  end;
end;

function HexStrToStr(const S:string):string;
//16�����ַ���ת�����ַ���
var
  t:Integer;
  ts:string;
  M,Code:Integer;
begin
  t:=1;
  Result:='';
  while t<=Length(S) do
  begin   //xlh 2006.10.21
    while (t<=Length(S)) and (not (S[t] in ['0'..'9','A'..'F','a'..'f'])) do
      inc(t);
    if (t+1>Length(S))or(not (S[t+1] in ['0'..'9','A'..'F','a'..'f'])) then
      ts:='$'+S[t]
    else
      ts:='$'+S[t]+S[t+1];

    Val(ts,M,Code);
    if Code=0 then
      Result:=Result+Chr(M);
    inc(t,2);
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  try
    Comm1.StartComm;
    sleep(100);
    Button9.Click;
    Button1.Enabled   := false;
    Button2.Enabled   := true;
  except
      On   E:Exception   do
          begin
              Showmessage(E.Message);//�쳣��Ϣ
              ///����������������
          end;
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
    Comm1.StopComm;
    Edit1.Text:='';
    Button1.Enabled   := true;
    Button2.Enabled   := false;
end;

function TForm1.SendStr(str: string): string;
begin
    Comm1.WriteCommData(Pchar(str),Length(str));
end;

function TForm1.SendStrln(str: string): string;
begin
    Comm1.WriteCommData(Pchar(str),Length(str));
    SendComm('oa');
end;

function TForm1.SendComm(str: string): string;
begin
    SendStr(HexStrToStr(str));
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
    if CheckBox1.Checked then
    SendComm(Memo2.Text)
    else
    SendStr(Memo2.Text);
end;

procedure TForm1.Button5Click(Sender: TObject);
begin
     SendComm('1b40');
end;

procedure TForm1.Button6Click(Sender: TObject);
begin
     SendComm('oa');
end;

procedure TForm1.Button7Click(Sender: TObject);
begin
    SendComm('1b69');
end;

procedure TForm1.Button8Click(Sender: TObject);
begin
Close;
end;





procedure TForm1.Button4Click(Sender: TObject);
begin
Memo1.Clear;
end;

procedure TForm1.Button10Click(Sender: TObject);
begin
  sendStrln('-******************-');
  sendStrln('----������ӡ����ҳ��----');
  sendComm('1b2d1');
  sendStrln('fdsakfkldsajklfjlkdsa');
  sendComm('1b2d2');
  sendStrln('fdsakfkldsajklfjlkdsa');
  sendComm('1b2d0');
  sendComm('1b451');
  sendStrln('fdsakfkldsajklfjlkdsa');
  sendComm('1b450');
  sendComm('1b471');
  sendStrln('fdsakfkldsajklfjlkdsa');
  sendComm('1b470');
  sendComm('1b610');
  sendStrln('�����');
  sendComm('1b611');
  sendStrln('����');
  sendComm('1b612');
  sendStrln('�Ҷ���');
  sendComm('1b610');
  sendComm('1d2110');
  sendStrln('double w');
  sendComm('1d2100');
  sendComm('1d2101');
  sendStrln('double H');
  sendComm('1d2100');
  sendComm('1d2111');
  sendStrln('double W H');
  sendComm('1d2100');
  sendComm('1d421');
  sendStrln('�ڵװ���');
  sendComm('1d2111');
  sendStrln('�ڵװ���');
  sendStrln('�ڵװ���');
  sendComm('1d420');
  sendComm('1d2100');
  sendComm('1c2d1');
  sendStrln('һ�㺺���»���');
  sendComm('1c2d2');
  sendStrln('���㺺���»���');
  sendComm('1c2d0');
  sendComm('1c571');
    sendComm('18');
  sendStrln('�ı��Ǻ���');
  sendComm('1c570');

  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  //sendComm('1b69');

end;

procedure TForm1.Button11Click(Sender: TObject);
begin
  //sendComm('1c571');
  sendComm('1b611');//���д�ӡ
  sendStrln('�ش��Ƽ�');
  sendComm('1b610'); //�����
  sendComm('1c570');
  sendComm('oa');
  sendComm('1b205');  //����ҳ���
  sendStrln('���ױ�ţ�201603150000001');
  sendStrln('�ͻ���ţ�QC9568545127');
  sendStrln('�ͻ����ƣ�����');
  sendStrln('��    �ţ�12345678');
  sendStrln('��ֵ��100');
  sendStrln('��ֵ������50');
  sendStrln('�������ã�80');
  sendStrln('�������ͣ�IC����ֵ');
  sendStrln('����ʱ�䣺'+datetimetostr(now()));
  sendStrln('----------------------------');
  sendStrln('֧����230');

  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  sendComm('oa');
  //sendComm('1b69');

end;
procedure TForm1.Button12Click(Sender: TObject);
begin
  sendComm('1B3f0a00');
end;

procedure TForm1.Button13Click(Sender: TObject);
begin
   sendComm('18');
end;

procedure TForm1.Button9Click(Sender: TObject);
begin
   sendComm('10041');
   sendComm('10042');
   sendComm('10043');
   sendComm('10044');

end;

procedure TForm1.Comm1ReceiveData(Sender: TObject; Buffer: Pointer;
  BufferLength: Word);
  var str :string;
begin
  SetLength(Str,BufferLength);
  move(buffer^,pchar(@Str[1])^,bufferlength);
    if CheckBox2.Checked then
      Memo1.Text:=Memo1.Text+StrToHexStr(Str)+' '
    else
      Memo1.Text := Memo1.Text + Str;
      if StrToHexStr(Str)='72' then
         Edit1.Text:='��ӡ��ȱֽ';
      if StrToHexStr(Str)='12' then
         Edit1.Text:='��ӡ������';
  Memo1.SelStart :=Length(Memo1.Text);
  Memo1.SelLength:= 0;
  Memo1.Perform(EM_SCROLLCARET,0,0);

end;

procedure TForm1.Timer1Timer(Sender: TObject);
begin
   Button9.Click;
end;

end.

