unit RWCard;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,HardWare;

type
  TRWCard_fr = class(TForm)
    GroupBox1: TGroupBox;
    edCom: TEdit;
    edBound: TEdit;
    Label1: TLabel;
    Label2: TLabel;
    btnOpen: TButton;
    GroupBox2: TGroupBox;
    Label3: TLabel;
    Edit1: TEdit;
    Button1: TButton;
    GroupBox3: TGroupBox;
    Panel2: TPanel;
    mmCardData: TMemo;
    Button2: TButton;
    Button3: TButton;
    Memo2: TMemo;
    Panel1: TPanel;
    Memo1: TMemo;
    procedure btnOpenClick(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
    procedure ShowData(Data:string);
  public
    { Public declarations }
    niHandle:Integer;
  end;

var
  RWCard_fr: TRWCard_fr;

implementation

{$R *.dfm}

procedure TRWCard_fr.btnOpenClick(Sender: TObject);
begin
  if btnOpen.Caption='OpenCom' then
  begin
  niHandle:=ic_init(StrToInt(edCom.Text),StrToInt(edBound.Text));
  if niHandle>0 then
  begin
    btnOpen.Caption:='CloseCom';
  end;
  end
  else
  begin
    if ic_exit(niHandle)=0 then
    begin
      btnOpen.Caption:='OpenCom';
    end;
  end;
  
end;

procedure TRWCard_fr.Button2Click(Sender: TObject);
var
mi:integer;
cardDataHex:array[0..255] of char;
cardDataDec:array[0..511] of char;
begin

  niHandle:=ic_init(StrToInt(edCom.Text),StrToInt(edBound.Text));
  if niHandle>0 then
  begin
    btnOpen.Caption:='CloseCom';
  end;
  try
   mi:=chk_card(niHandle);
   if mi<0 then
   begin
     ShowMessage('Check Card Error');
     exit;
   end;

   case mi of
    51:
    begin
      exit;
    end;
    21:
    begin
      mi:=srd_4442(niHandle,0,256,cardDataHex);
      if mi<>0 then
      begin  
        ShowMessage('Read Card Error');
        exit;
      end;
      hex_asc(cardDataHex,cardDataDec,256);

      ShowData(string(cardDataDec));
    end;
   else
//    ShowMessage(IntToStr(mi));
    exit;
   end;
  finally
    if ic_exit(niHandle)=0 then
    begin
      btnOpen.Caption:='OpenCom';
    end;
  end;

   
end;

procedure TRWCard_fr.FormCreate(Sender: TObject);
begin
Memo2.Lines.Add('00');
Memo2.Lines.Add('');
Memo2.Lines.Add('01');
Memo2.Lines.Add('');
Memo2.Lines.Add('02');
Memo2.Lines.Add('');
Memo2.Lines.Add('03');
Memo2.Lines.Add('');
Memo2.Lines.Add('04');
Memo2.Lines.Add('');
Memo2.Lines.Add('05');
Memo2.Lines.Add('');
Memo2.Lines.Add('06');
Memo2.Lines.Add('');
Memo2.Lines.Add('07');
Memo2.Lines.Add('');
Memo2.Lines.Add('08');
Memo2.Lines.Add('');
Memo2.Lines.Add('09');
Memo2.Lines.Add('');
Memo2.Lines.Add('0A');
Memo2.Lines.Add('');
Memo2.Lines.Add('0B');
Memo2.Lines.Add('');
Memo2.Lines.Add('0C');
Memo2.Lines.Add('');
Memo2.Lines.Add('0D');
Memo2.Lines.Add('');
Memo2.Lines.Add('0E');
Memo2.Lines.Add('');
Memo2.Lines.Add('0F');

end;

procedure TRWCard_fr.ShowData(Data: string);
var
 i:Integer;
 msTempData:string;
begin
  msTempData:='';
  mmCardData.Clear;
  for I := 0 to 255 do
  begin
    msTempData:=msTempData+copy(Data,i*2+1,2)+'    ';
    if (i+1) mod 16 =0 then
    begin
      mmCardData.Lines.Add(Trim(msTempData));
      mmCardData.Lines.Add('');
      msTempData:='';
    end;
  end;
  //mmCardData.Lines.Add(msTempData);
end;
end.
