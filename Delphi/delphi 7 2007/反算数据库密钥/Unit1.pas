unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,DESCrypt,ElAESCrypt,AESCrypt;

type
  TForm1 = class(TForm)
    Edit1: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    Edit2: TEdit;
    Memo1: TMemo;
    Button1: TButton;
    Button2: TButton;
    procedure Button1Click(Sender: TObject);
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
begin
  Memo1.Lines.Add(DecryptString(trim(Edit1.Text),Trim(Edit2.Text),kb128));
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Memo1.Lines.Add(EncryptString(trim(Edit1.Text),Trim(Edit2.Text),kb128));
end;

end.
