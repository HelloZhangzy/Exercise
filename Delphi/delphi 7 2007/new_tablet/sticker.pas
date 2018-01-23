unit sticker;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Menus;

type
  Tsticker_fr = class(TForm)
    Label1: TLabel;
    PopupMenu1: TPopupMenu;
    N1: TMenuItem;
    procedure Label1MouseMove(Sender: TObject; Shift: TShiftState; X,
      Y: Integer);
    procedure Label1DblClick(Sender: TObject);
    procedure N1Click(Sender: TObject);
  protected
    procedure   CreateParams(var   Params:   TCreateParams);   override;
  private
    { Private declarations }
  public
    { Public declarations }
    procedure xslr(txt:string;x,y,jb:Integer);
    procedure updatelr(txt:string);
    
  end;

var
  sticker_fr: Tsticker_fr;

implementation

uses dat, gut,tablet_main, gut2;

{$R *.dfm}

procedure Tsticker_fr.CreateParams(var Params: TCreateParams);
begin
  inherited;
        Params.WndParent  :=FindWindow('Progman',nil);
end;

procedure Tsticker_fr.Label1MouseMove(Sender: TObject; Shift: TShiftState;
  X, Y: Integer);
var
  position:integer;
  reco:tabletrecord;
  datrecord:tdat;
  flag:Boolean;  
begin
  try
    if (ssleft in Shift) then
    begin
            ReleaseCapture; Perform(WM_syscommand, $F012, 0);
            datrecord:=TDat.create(flag);
            position:=StrToInt(Copy(name,7,9));
            if position>teblet_fr.cx_tablet.Nodes.Count-1 then
                    position:=teblet_fr.cx_tablet.Nodes.Count-1;
            if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])<>position then
            begin
              while position>=0 do
              begin
                 if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])=position then
                  begin
                    teblet_fr.cx_tablet.Nodes[position].Delete;
                    Break;
                  end;
                    position:=position-1;
              end;
            end;          
            datrecord.datnonceread(reco,position);
            reco.tabletupdate:=Now;
            reco.x:=Left;
            reco.y:=top;
            datrecord.datadd(reco,position);
            datrecord.Free;
    end;
  except
  
  end;

end;

procedure Tsticker_fr.xslr(txt: string; x, y,jb: Integer);
begin    
  label1.Caption:=txt;
  Top:=y;
  Left:=x;
  case jb of
  1: Label1.Color:=clRed;
  2: Label1.Color:=clSkyBlue;
  end
end;

procedure Tsticker_fr.Label1DblClick(Sender: TObject);
begin
gut_fr1.Show;
end;

procedure Tsticker_fr.N1Click(Sender: TObject);
var
  DatRecord:TDat;
  position:integer;
  flag:Boolean;
begin
  position:=-1;
  position:=strtoint(Copy(name,7,9));
  if position>teblet_fr.cx_tablet.Nodes.Count-1 then
                position:=teblet_fr.cx_tablet.Nodes.Count-1;
  DatRecord:=TDat.Create(flag);
  if flag then
  begin
    if DatRecord.DeleteRecord(position)then
    begin
        if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])<>position then
        begin
          while position>=0 do
          begin
             if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])=position then
                Break;
             position:=position-1;
          end;
        end;
       teblet_fr.cx_tablet.Nodes[position].Delete;
       Close;
       application.MessageBox('删除成功！','提示',MB_ICONWARNING+mb_ok);
    end
    else    application.MessageBox('删除失败！','提示',MB_ICONERROR+mb_ok);
  end;
  DatRecord.Free;
end ;



procedure Tsticker_fr.updatelr(txt: string);
begin
   Label1.Caption:=txt;
end;

end.
