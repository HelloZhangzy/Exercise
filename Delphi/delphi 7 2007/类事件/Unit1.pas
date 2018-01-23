unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;



type
  TEnvet=procedure (str:string) of object;

type
  TmyClass=Class
    private
      FCount:Integer;
      FonEnvet:TEnvet;
      procedure SetCount(value:Integer);
    public
      constructor Cteate;       
    published
     property count:Integer read FCount write SetCount;
     property onenvet:TEnvet read FonEnvet write FonEnvet;
  End;

type
  TForm1 = class(TForm)
    Button1: TButton;

    procedure showStr(str:string);
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
    myclass:TmyClass;
  public
    { Public declarations }

  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}
constructor TmyClass.Cteate;
begin
    Fcount:=1;
end;

procedure TmyClass.SetCount(value:Integer);
begin
  Fcount:=FCount+1;
  if Assigned(FonEnvet) then
      FonEnvet(IntToStr(FCount));
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  myclass.count:=1;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
  myclass:=TmyClass.Cteate;
  myclass.onenvet:=showStr;
end;

procedure TForm1.showStr(str: string);
begin
  ShowMessage(str);

end;
end.

