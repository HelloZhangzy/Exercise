unit copyfilename;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, cxLookAndFeelPainters, StdCtrls, cxButtons, cxControls,
  cxContainer, cxEdit, cxGroupBox, cxTextEdit, cxListBox;

type
  Tback_fr = class(TForm)
    cxGroupBox1: TcxGroupBox;
    cxButton1: TcxButton;
    cxButton2: TcxButton;
    cxButton3: TcxButton;
    cxButton4: TcxButton;
    cxfilename: TcxTextEdit;
    Label1: TLabel;
    cxListBox1: TcxListBox;
    procedure FormCreate(Sender: TObject);
    procedure cxButton1Click(Sender: TObject);
    procedure cxButton4Click(Sender: TObject);
  private
    { Private declarations }
    procedure backfile(filename:string);
    procedure revertfile(filename:string);
    procedure Copyfilename(filename,cap:string;fl:Integer);
  public
    { Public declarations }
  end;

var
  back_fr: Tback_fr;

implementation

{$R *.dfm}

{ Tback_fr }

procedure Tback_fr.backfile(filename: string);
begin
  Copyfilename(filename,'备份',1);
end;


procedure Tback_fr.Copyfilename(filename,cap: string;fl:Integer);
var
  dir,bfilename,rfilename:string;
begin
  dir:=ExtractFilePath(application.ExeName);
  case fl of
    1: begin
        bfilename:=dir+'tablet.dat';rfilename:=dir+'back\'+filename;
       end;
    2: begin
        rfilename:=dir+'tablet.dat';bfilename:=dir+'back\'+filename;
       end;
  end;  
  if CopyFile(PChar(bfilename),PChar(rfilename),False) then
        Application.MessageBox(PChar(cap+'成功'),PChar('提示'),MB_ICONWARNING+mb_ok)
  else
        Application.MessageBox(PChar(cap+'失败'),PChar('提示'),MB_ICONERROR+mb_ok);
end;

procedure Tback_fr.revertfile(filename: string);
begin
Copyfilename(filename,'还原',2);
end;

procedure Tback_fr.FormCreate(Sender: TObject);
begin
   cxfilename.Text:=datetimetostr(now);
end;

procedure Tback_fr.cxButton1Click(Sender: TObject);
var
  filename:string;
begin
   filename:=FormatDateTime('yyyyMMddhhmmss',Now)+'.bak';     //DateTimeToStr(Now)
   backfile(filename);
   cxfilename.Text:=datetimetostr(now);
end;

procedure Tback_fr.cxButton4Click(Sender: TObject);
var
  filename:string;
begin
   filename:=FormatDateTime('yyyyMMddhhmmss',Now)+'.bak'; 
   revertfile(filename);
end;

end.
