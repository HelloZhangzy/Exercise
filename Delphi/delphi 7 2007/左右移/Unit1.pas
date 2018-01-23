unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Edit2: TEdit;
    Memo1: TMemo;
    Button1: TButton;
    Edit3: TEdit;
    Button2: TButton;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
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
mstemp:string;
mi:Cardinal;
s:TStrings
begin
  if RadioButton1.Checked then
  begin
      mi := StrToInt64(edit1.Text) shr StrToInt64(Edit2.Text);
      Memo1.Lines.Add(edit1.text+'-->'+edit2.Text+' : '+IntToStr(mi));
      mi := StrToInt(edit1.Text) shl StrToInt(Edit2.Text);
     Memo1.Lines.Add(edit1.text+'<--'+edit2.Text+' : '+IntToStr(mi));
  end
  else
  begin
      mi := StrToInt64(edit1.Text) and StrToInt64(Edit2.Text);
      Memo1.Lines.Add(edit1.text+' and '+edit2.Text+' : '+IntToStr(mi));
  end;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
//Memo1.Lines.Add(IntToStr(Length(Edit3.Text)));
end;

procedure TForm1.Edit1KeyPress(Sender: TObject; var Key: Char);
begin
if Key=#13 then
begin
  Button1.Click;
end;
end;

end.
