unit copyfilename;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, cxLookAndFeelPainters, StdCtrls, cxButtons, cxControls,
  cxContainer, cxEdit, cxGroupBox, cxTextEdit;

type
  Tback_fr = class(TForm)
    cxGroupBox1: TcxGroupBox;
    cxButton1: TcxButton;
    cxButton2: TcxButton;
    cxButton3: TcxButton;
    cxButton4: TcxButton;
    cxfilename: TcxTextEdit;
    Label1: TLabel;
    procedure FormCreate(Sender: TObject);
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
        bfilename:=dir+'\tablet.dat';rfilename:=dir+'\'+filename;
       end;
    2: begin
        rfilename:=dir+'\tablet.dat';bfilename:=dir+'\'+filename;
       end;
  end;  
  if CopyFile(PChar(bfilename),PChar(rfilename),False) then
        Application.MessageBox(cap+'成功',PChar('提示'),MB_ICONWARNING+mb_ok)
  else
        Application.MessageBox(cap+'失败',PChar('提示'),MB_ICONERROR+mb_ok);
end;

procedure Tback_fr.revertfile(filename: string);
begin
Copyfilename(filename,'还原',2);
end;

procedure Tback_fr.FormCreate(Sender: TObject);
begin
   cxfilename.Text:=datetimetostr(now);
end;

end.
