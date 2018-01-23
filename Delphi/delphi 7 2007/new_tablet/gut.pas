unit gut;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls, cxControls, cxContainer, cxEdit, cxTextEdit,
  cxMaskEdit, cxDropDownEdit, cxCalendar, dxCntner, dxEditor, dxExEdtr,
  dxEdLib, cxMemo, cxCheckBox, cxLookAndFeelPainters, cxButtons,
  cxRadioGroup, ActnList,dat, cxGroupBox,tablet_main,sticker, cxGraphics,
  cxCustomData, cxStyles, cxTL, cxInplaceContainer, Menus;

type
  Tgut_fr = class(TForm)
    Panel1: TPanel;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    cxcb_xs: TcxCheckBox;
    cxr_1: TcxRadioButton;
    cxr_2: TcxRadioButton;
    cxr_3: TcxRadioButton;
    cxButton1: TcxButton;
    cxButton2: TcxButton;
    cxed_day: TcxTextEdit;
    cxed_date: TcxDateEdit;
    Label6: TLabel;
    ActionList1: TActionList;
    add_teblet: TAction;
    clear: TAction;
    cxButton4: TcxButton;
    cxButton5: TcxButton;
    create: TAction;
    delete_tablet: TAction;
    read_tablet: TAction;
    Bevel1: TBevel;
    cxGroupBox1: TcxGroupBox;
    cxm_txt: TcxMemo;
    close: TAction;
    off: TAction;
    CloseAndOff: TAction;
    StyleController: TdxEditStyleController;
    procedure add_tebletExecute(Sender: TObject);
    procedure clearExecute(Sender: TObject);
    procedure delete_tabletExecute(Sender: TObject);
    procedure read_tabletExecute(Sender: TObject);
    function getrecord():Trecord;
    procedure closeExecute(Sender: TObject);
    procedure offExecute(Sender: TObject);
    procedure CloseAndOffExecute(Sender: TObject);
  private
    { Private declarations }
    datarec:Trecord;
    procedure saveadd;
    procedure updaterecord;
  public
    { Public declarations }
    procedure xszm(data:TabletRecord;num:Integer);
    procedure xsoldlr(temp:TcxTreeListNode);
  end;

var
  gut_fr: Tgut_fr;



implementation

{$R *.dfm}

procedure Tgut_fr.add_tebletExecute(Sender: TObject);
begin
  if (cxButton1.Caption='保存')  then
  begin
    saveadd;
  end
  else
  if cxButton1.Caption='修改' then
  begin
    updaterecord;
  end else
  begin
    clearExecute(Sender);
    cxButton1.Caption:='保存';
    cxButton2.Caption:='取消';
  end;
end;

procedure Tgut_fr.clearExecute(Sender: TObject);
begin
  cxm_txt.Visible:=True;
  cxm_txt.Text:='';
  cxcb_xs.Checked:=true;
  cxr_3.Checked:=true;
  cxed_day.Text:='7';
  cxed_date.Date:=Now;
  cxm_txt.SetFocus;
end;

procedure Tgut_fr.delete_tabletExecute(Sender: TObject);  
var
  DatRecord:TDat;
  flag:Boolean;
begin
  datrecord:=tdat.Create(flag);
  if flag then
  begin
    flag:=DatRecord.DeleteRecord(1);
    if flag then
       Application.MessageBox('删除成功！','提示',MB_ICONWARNING+mb_ok)
    else
       Application.MessageBox('删除失败！','提示',MB_ICONERROR+mb_ok)
  end;
   DatRecord.Free;

end;

procedure Tgut_fr.read_tabletExecute(Sender: TObject);
var
  DatRecord:TDat;
  flag:Boolean;
  i:integer;
begin
  DatRecord:=tdat.Create(flag);
  if flag then
  begin
    DatRecord.datread(datarec);
    //i:=DatRecord.GetRecordCount;
    cxm_txt.Clear;
    for i:=0 to  DatRecord.GetRecordCount-1 do
    begin
      cxm_txt.Lines.Add(datarec[i].TabletTxt);
      cxm_txt.Lines.Add(DateTimeToText(datarec[i].TabletDate));
      cxm_txt.Lines.Add(IntToStr(datarec[i].TabletDay));
      cxm_txt.Lines.Add(BoolToStr(datarec[i].TabletBool));
      cxm_txt.Lines.Add(IntToStr(datarec[i].Tabletrank));
      cxm_txt.Lines.Add(DateTimeToText(datarec[i].tabletcrdate));
      cxm_txt.Lines.Add(DateTimeToText(datarec[i].tabletupdate));
      cxm_txt.Lines.Add(IntToStr(datarec[i].x));
      cxm_txt.Lines.Add(IntToStr(datarec[i].y));
    end;
  end;
  DatRecord.Free;  
end;

function Tgut_fr.getrecord: Trecord;
var
  DatRecord:TDat;
  flag:Boolean;
begin
  DatRecord:=tdat.Create(flag);
  if flag then
  begin
    DatRecord.datread(datarec); 
    Result:=datarec;
  end;
  DatRecord.free;
end;

procedure Tgut_fr.closeExecute(Sender: TObject);
begin
if Application.MessageBox('是否（Y/N）退出标签系统!','提示',MB_ICONWARNING+mb_yesno)=idyes then
begin
   Application.Terminate;
end;
end;

procedure Tgut_fr.offExecute(Sender: TObject);
begin
  cxButton2.Caption:='关闭';
  cxButton1.Caption:='增加';
  cxm_txt.Visible:=false;
end;

procedure Tgut_fr.CloseAndOffExecute(Sender: TObject);
begin
if cxButton2.Caption='关闭' then
   closeExecute(sender)
else
   offExecute(Sender);
end;     

procedure Tgut_fr.xszm(data: TabletRecord;num:Integer);
var
  ss:Tsticker_fr;
begin
  if data.TabletBool then
  begin
   ss:=Tsticker_fr.Create(Self);
   ss.Name:='tablet'+inttostr(num);
   ss.Caption:='tablet'+inttostr(num);
   ss.xslr(data.TabletTxt,data.x,data.y,data.Tabletrank);
   ss.Show;
  end;
end;

procedure Tgut_fr.xsoldlr(temp: TcxTreeListNode);
begin
   cxm_txt.Visible:=true;
   cxm_txt.Text:= temp.texts[0];
   cxed_date.Date:=StrToDateTime(temp.texts[1]);
   cxed_day.Text:=temp.texts[2];
   cxcb_xs.Checked:=StrToBool(temp.texts[3]);
   case  StrToInt(temp.texts[4]) of
     1:cxr_1.Checked:=True;
     2:cxr_2.Checked:=True;
     3:cxr_3.Checked:=True;
   end;
   cxButton1.Caption:='修改'; 
end;

procedure Tgut_fr.saveadd;
var
  DatRecord:TDat;
  flag:Boolean;
  TabletDatRecord:TabletRecord;
begin
   if Trim(cxm_txt.Text)='' then
    begin
        Application.MessageBox('内容不能为空!','提示',MB_ICONERROR+mb_ok);
        exit;
    end;
    datrecord:=tdat.Create(flag);
    if flag then
    begin
      TabletDatRecord.TabletTxt:=cxm_txt.Text;
      TabletDatRecord.TabletDate:=cxed_date.Date;
      TabletDatRecord.TabletDay:=StrToInt(cxed_day.Text);
      if cxcb_xs.Checked then
          TabletDatRecord.TabletBool:=true
      else
          TabletDatRecord.TabletBool:=False;
      if cxr_1.Checked then
          TabletDatRecord.Tabletrank:=1
      else
          if cxr_2.Checked then
               TabletDatRecord.Tabletrank:=2
          else
               TabletDatRecord.Tabletrank:=3;

     TabletDatRecord.tabletcrdate:=now;
     TabletDatRecord.tabletupdate:=now;
     TabletDatRecord.x:=DatRecord.getx;
     TabletDatRecord.y:=DatRecord.gety;

     flag:=DatRecord.datadd(TabletDatRecord);
     teblet_fr.listadd(TabletDatRecord,teblet_fr.getsum+1);
     DatRecord.Free;
     
     if flag then
     begin
        clearExecute(Self);
        
        teblet_fr.addsum;

        if Application.MessageBox('增加成功,是否继续增加？','提示',MB_YESNO)=idyes then
            Exit;
     end
     else
     begin
        Application.MessageBox('增加失败!','提示',MB_ICONERROR+mb_ok);
        exit;
     end;
    end;
    Self.offExecute(Self);
end;

procedure Tgut_fr.updaterecord;
var
  datrecord:tdat;
  flag:Boolean;
  data:TabletRecord;
  position:Integer;
  hdntmp:THandle;
  WinControl: TWinControl; 
begin
     position:=teblet_fr.cx_tablet.FocusedNode.RecordIndex;
     if position<0 then
        exit;
     datrecord:=TDat.Create(flag);
     if flag then
     begin
      if datrecord.datnonceread(data,position) then
      begin
       data.TabletTxt:=cxm_txt.Text;
       data.TabletDate:=cxed_date.Date;
       data.TabletDay:=StrToInt(cxed_day.Text);

       if cxcb_xs.Checked then
          data.TabletBool:=true
       else
           data.TabletBool:=False;
       if cxr_1.Checked then
          data.Tabletrank:=1
       else
          if cxr_2.Checked then
               data.Tabletrank:=2
          else
               data.Tabletrank:=3;

       data.tabletupdate:=now;

       if not datrecord.datadd(data,position) then
       begin
           Application.MessageBox('修改失败!','提示',MB_ICONERROR+mb_ok);
           exit;
       end;

        teblet_fr.cx_tablet.FocusedNode.texts[0]:=data.TabletTxt;
        teblet_fr.cx_tablet.FocusedNode.texts[1]:=DateTimeToStr(data.TabletDate);
        teblet_fr.cx_tablet.FocusedNode.texts[2]:=IntToStr(data.TabletDay);
        teblet_fr.cx_tablet.FocusedNode.texts[3]:=BoolToStr(data.TabletBool);
        teblet_fr.cx_tablet.FocusedNode.texts[4]:=IntToStr(data.Tabletrank);
        teblet_fr.cx_tablet.FocusedNode.texts[5]:=DateTimeToStr(data.tabletcrdate);
        teblet_fr.cx_tablet.FocusedNode.texts[6]:=DateTimeToStr(data.tabletupdate);

         hdntmp:=FindWindow('Tsticker_fr',PChar('tablet'+inttostr(position)));
         if hdntmp<>0 then
         begin
           WinControl:=FindControl(hdntmp);
           if (WinControl <> nil) then 
                if (WinControl is TForm) then
                begin
                   TLabel((WinControl as TForm).FindComponent('label1')).Caption:=data.TabletTxt;
                end;
         end;
        Application.MessageBox('修改成功!','提示',MB_ICONWARNING+mb_ok)
      end
      else
          Application.MessageBox('修改失败!','提示',MB_ICONERROR+mb_ok);
     end;
     datrecord.Free;
end;

end.
