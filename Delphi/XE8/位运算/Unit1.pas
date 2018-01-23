unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    Memo1: TMemo;
    Panel1: TPanel;
    GroupBox1: TGroupBox;
    Button1: TButton;
    Edit1: TEdit;
    Edit2: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    GroupBox2: TGroupBox;
    Label3: TLabel;
    Edit3: TEdit;
    Label4: TLabel;
    Edit4: TEdit;
    GroupBox3: TGroupBox;
    Label5: TLabel;
    Label6: TLabel;
    Edit5: TEdit;
    Edit6: TEdit;
    Button2: TButton;
    Button3: TButton;
    GroupBox4: TGroupBox;
    Label7: TLabel;
    Edit7: TEdit;
    Button4: TButton;
    Label8: TLabel;
    Edit8: TEdit;
    GroupBox5: TGroupBox;
    Label9: TLabel;
    Label10: TLabel;
    Edit9: TEdit;
    Button5: TButton;
    Edit10: TEdit;
    GroupBox6: TGroupBox;
    Label11: TLabel;
    Label12: TLabel;
    Edit11: TEdit;
    Edit12: TEdit;
    Button6: TButton;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
    procedure Button6Click(Sender: TObject);
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
  temp_s:string;
begin
 temp_s:=Format('%s and (1 shl (%s-1))',[edit1.Text,edit2.Text]);
 Memo1.Lines.Add(temp_s+'=>'+IntToStr(StrToInt(Edit1.Text) and (1 shl (StrToInt(Edit2.Text)-1))));
end;

procedure TForm1.Button2Click(Sender: TObject);
var
  temp_s:string;
begin
  temp_s:=Format('%s or (1 shl (%s-1))',[edit3.Text,edit4.Text]);
  Memo1.Lines.Add(temp_s+'=>'+IntToStr(StrToInt(Edit3.Text) or (1 shl (StrToInt(edit4.Text)-1))));
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  temp_s:string;
begin
  temp_s:=Format('%s shr (%s-1) and 1',[edit5.Text,edit6.Text]);
   Memo1.Lines.Add(temp_s+'=>'+IntToStr(StrToInt(Edit5.Text) shr (StrToInt(Edit6.Text) -1) and 1));
end;

procedure TForm1.Button4Click(Sender: TObject);
var
  temp_s:string;
begin
  temp_s:=Format(' %s shr %s',[edit7.Text,edit8.Text]);
   Memo1.Lines.Add(temp_s+'=>'+IntToStr(StrToInt(Edit7.Text) shr StrToInt(Edit8.Text)));
end;

procedure TForm1.Button5Click(Sender: TObject);
var
  temp:byte;
begin
  temp:=byte(210 shl 2 );
  temp:=byte(temp shr 4 );
  temp:=byte(byte(100 shl 2 ) shr 4);
  Memo1.Lines.Add(IntToStr(temp));
end;

procedure TForm1.Button6Click(Sender: TObject);
var
  temp_s:string;
begin
   temp_s:=Format('%s and not(1 shl %s-1)',[edit11.Text,edit12.Text]);
   Memo1.Lines.Add(temp_s+'=>'+IntToStr(StrToInt(Edit11.Text) and not(1 shl StrToInt(edit12.Text)-1)));
end;

procedure TForm1.FormShow(Sender: TObject);
begin
//  Memo1.Lines.Add('ȥ�����һλ | (101101->10110) | x shr 1 => '+
//  ������һ��0��| (101101->1011010) | x shl 1
//  ������һ��1��| (101101->1011011) | x shl 1+1
//  �����һλ���1��| (101100->101101) | x or 1
//  �����һλ���0��| (101101->101100) | x or 1-1
//  ���һλȡ�� | (101101->101100) | x xor 1
//  ��������kλ���1 | (101001->101101,k=3) | x or (1 shl (k-1))
//  ��������kλ���0 | (101101->101001,k=3) | x and not (1 shl (k-1))
//  ������kλȡ����| (101001->101101,k=3) | x xor (1 shl (k-1))
//  ȡĩ��λ | (1101101->101) | x and 7
//  ȡĩkλ��| (1101101->1101,k=5) | x and(1 shl k-1)
//  ȡ������kλ��| (1101101->1,k=4) | x shr (k-1) and 1
//  ��ĩkλ���1��| (101001->101111,k=4) | x or (1 shl k-1)
//  ĩkλȡ�� | (101001->100110,k=4) | x xor (1 shl k-1)
//  ���ұ�������1���0 | (100101111->100100000) | x and (x+1)
//  �������һ��0���1 | (100101111->100111111) | x or (x+1)
//  ���ұ�������0���1 | (11011000->11011111) | x or (x-1)
//  ȡ�ұ�������1 | (100101111->1111) | (x xor (x+1)) shr 1
//  ȥ�������һ��1����� | (100101000->1000) | x and (x xor (x-1))���� x and (-x)��
end;

end.
