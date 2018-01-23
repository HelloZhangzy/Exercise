unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  PMyEvent=procedure(time:Integer);     
  TForm1 = class(TForm)
    Memo1: TMemo;
    Button1: TButton;
    Edit1: TEdit;
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }

  public
    { Public declarations }
  end;
  
  TMyClass=class
  private
    FOnMyEvent:PMyEvent;
    procedure DoMyEvent(time:Integer);
  public    
    property OnMyEvent:PMyEvent read FOnMyEvent write FOnMyEvent;
    procedure MyPro(count:Integer);
  end;
   procedure OnMyEvent(time:Integer);
var
  Form1: TForm1;
  my: TMyClass;

implementation

{$R *.dfm}

{ TForm1 }

procedure TForm1.Button1Click(Sender: TObject);
var
  count:Integer;
begin
  count:=StrToInt(Edit1.Text) ;
  my.MyPro(count);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  my:=TMyClass.Create;
  my.OnMyEvent:=OnMyEvent;
end;

procedure OnMyEvent(time: Integer);
begin
  Form1.Memo1.Lines.Append(inttostr(time)+'=>state');
  Sleep(time*10);
  Form1.Memo1.Lines.Append('   '+inttostr(time)+'=>End');
end;

{ TMyClass }

procedure TMyClass.DoMyEvent(time: Integer);
begin
  FOnMyEvent(time);
end;

procedure TMyClass.MyPro(count:Integer);
var
  i:integer;
begin
  for i:=count downto 1  do  
  begin
    DoMyEvent(i);
  end;
end;

end.
