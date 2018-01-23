unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TForm1 = class(TForm)
    Memo1: TMemo;
    Button1: TButton;
    CheckBox1: TCheckBox;
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
{$R StrRes.RES} 

procedure TForm1.Button1Click(Sender: TObject);
var
  i:Integer;
  iStart:integer;
begin
Memo1.Clear;

 if CheckBox1.Checked then   iStart:=20000 else iStart:=10000;
 for i:=1 to 6 do
 begin
     Memo1.Lines.Add(LoadStr(istart+i));
 end;
end;

end.
 