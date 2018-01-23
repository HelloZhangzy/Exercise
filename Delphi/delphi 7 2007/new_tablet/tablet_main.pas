unit tablet_main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ExtCtrls, dxCntner, cxControls, cxContainer, cxListBox, StdCtrls,
  cxGraphics, cxCustomData, cxStyles, cxTL, cxTextEdit, cxInplaceContainer,
  dxBar, cxEdit, DB, ADODB, cxFilter, cxData,
  cxDataStorage, cxDBData, cxGridCustomTableView, cxGridTableView,
  cxGridDBTableView, cxGridLevel, cxClasses, cxGridCustomView, cxGrid,
  cxMaskEdit, cxDBTL, cxTLData, cxCheckBox, cxCalendar,dat, Menus, ActnList,sticker,ShellAPI,
  AppEvnts,SConnect,copyfilename, cxTLdxBarBuiltInMenu;

const
mousemsg = wm_user + 1;
iid = 100;
type
  Tteblet_fr = class(TForm)
    Panel1: TPanel;
    dxBarDockControl1: TdxBarDockControl;
    dxBarManager1: TdxBarManager;
    dxBarSubItem1: TdxBarSubItem;
    dxBarSubItem2: TdxBarSubItem;
    dxBarButton1: TdxBarButton;
    dxBarButton2: TdxBarButton;
    dxBarButton3: TdxBarButton;
    cx_tablet: TcxTreeList;
    cx_text: TcxTreeListColumn;
    cx_date: TcxTreeListColumn;
    cx_day: TcxTreeListColumn;
    cx_xs: TcxTreeListColumn;
    cx_jb: TcxTreeListColumn;
    cx_crdate: TcxTreeListColumn;
    cx_update: TcxTreeListColumn;
    dxBarButton4: TdxBarButton;
    ActiveStyleController: TdxEditStyleController;
    PopupMenu1: TPopupMenu;
    N1: TMenuItem;
    ActionList1: TActionList;
    del_tablet: TAction;
    cx_num: TcxTreeListColumn;
    add_tablet: TAction;
    ApplicationEvents1: TApplicationEvents;
    PopupMenu2: TPopupMenu;
    N2: TMenuItem;
    N3: TMenuItem;
    back: TAction;
    dxBarButton5: TdxBarButton;
    dxBarSubItem3: TdxBarSubItem;
    dxBarButton6: TdxBarButton;
    procedure cx_tabletClick(Sender: TObject);
    procedure del_tabletExecute(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure add_tabletExecute(Sender: TObject);
    procedure ApplicationEvents1Minimize(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
    procedure FormDestroy(Sender: TObject);
    procedure N3Click(Sender: TObject);
    procedure N2Click(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure backExecute(Sender: TObject);
   private
    { Private declarations }
    sum:Integer;
    ntida:TNotifyIcondataA;
    procedure ShowPanel(APanel: TPanel);
    procedure recordload();

  //  procedure WMSysCommand(var Message: TMessage); message WM_SYSCOMMAND;
  //  procedure WMBarIcon(var Message:TMessage);message WM_BARICON;
    

  public
    { Public declarations }
   // scx,scy:integer;
    temptablenum:array[0..300] of integer;
    cou:Integer;
    function getsum():Integer;
    procedure addsum();
    procedure listadd(data:TabletRecord;num:Integer);
    procedure clostablet(position:integer);
    procedure mousemessage(var message: tmessage); message mousemsg;
  end;

var
  teblet_fr: Tteblet_fr;


implementation

uses gut;

{$R *.dfm}

procedure Tteblet_fr.ShowPanel(APanel: TPanel);
var
  I: Integer;
  AControl: TControl;
begin
  APanel.Parent := Panel1;
  APanel.Left := 0;
  APanel.Top := 0;
  APanel.Visible := True;
  for I := 0 to Panel1.ControlCount - 1 do
  begin
    AControl := Panel1.Controls[I];
    if (AControl is TPanel) and (AControl <> APanel) then
      AControl.Visible := False;
  end;
end;

procedure Tteblet_fr.recordload;
var
  temprecord:Trecord;
  i:Integer;
begin
  temprecord:=gut_fr.getrecord;
  sum:=High(temprecord);
  for i:=0 to sum do
  begin
        listadd(temprecord[i],i); 
  end;
end;

procedure Tteblet_fr.listadd(data: TabletRecord;num:Integer);
var
 temp:TcxTreeListNode;
begin
    temp :=cx_tablet.Add(nil,Pointer(1));
    temp.texts[0]:=data.TabletTxt;
    temp.texts[1]:=DateTimeToStr(data.TabletDate);
    temp.texts[2]:=IntToStr(data.TabletDay);
    temp.texts[3]:=BoolToStr(data.TabletBool);
    temp.texts[4]:=IntToStr(data.Tabletrank);
    temp.texts[5]:=DateTimeToStr(data.tabletcrdate);
    temp.texts[6]:=DateTimeToStr(data.tabletupdate);
    temp.Texts[7]:=IntToStr(num);
    gut_fr.xszm(data,num);
end;

procedure Tteblet_fr.cx_tabletClick(Sender: TObject);
begin     
   if cx_tablet.Nodes.Count>0 then
      gut_fr.xsoldlr(cx_tablet.FocusedNode);
end;

procedure Tteblet_fr.del_tabletExecute(Sender: TObject);
var
  DatRecord:TDat;
  flag:Boolean;
  position:integer;  
begin
 DatRecord:=TDat.Create(flag);
 if flag then
 begin
     position:=StrToInt(cx_tablet.FocusedNode.Texts[7]);
     if position>teblet_fr.cx_tablet.Nodes.Count-1 then
                position:=teblet_fr.cx_tablet.Nodes.Count-1;
    if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])<>position then
      begin
        while position>=0 do
        begin
           if StrToInt(teblet_fr.cx_tablet.Nodes[position].Texts[7])=position then
              Break;
           position:=position-1;
        end;
      end;
     if DatRecord.DeleteRecord(position)then
     begin
         cx_tablet.FocusedNode.Delete;
          clostablet(position);
         application.MessageBox('ɾ���ɹ���','��ʾ',MB_ICONWARNING+mb_ok);
     end
     else
         application.MessageBox('ɾ��ʧ�ܣ�','��ʾ',MB_ICONERROR+mb_ok);
 end
 else
   application.MessageBox('ɾ��ʧ�ܣ�','��ʾ',MB_ICONERROR+mb_ok);
 DatRecord.Free;

end;


procedure Tteblet_fr.mousemessage(var message: tmessage);
var
mousept: TPoint; //�����λ��
begin
inherited;
if message.LParam = wm_rbuttonup then begin //������Ҽ����ͼ��
getcursorpos(mousept); //��ȡ���λ��
popupmenu2.popup(mousept.x, mousept.y);
//�ڹ��λ�õ���ѡ��
end;
if message.LParam = wm_lbuttonup then begin //�����������ͼ��
//��ʾӦ�ó��򴰿�
ShowWindow(Handle, SW_RESTORE);
//������������ʾӦ�ó��򴰿�
ShowWindow(Application.handle, SW_RESTORE);
SetWindowLong(Application.Handle, GWL_EXSTYLE,
not (GetWindowLong(Application.handle, GWL_EXSTYLE)
or WS_EX_TOOLWINDOW and not WS_EX_APPWINDOW));
end;
message.Result := 0;
end;


procedure Tteblet_fr.FormCreate(Sender: TObject);
begin
inherited;
ntida.cbSize := sizeof(tnotifyicondataa); //ָ��ntida�ĳ���
ntida.Wnd := handle; //ȡӦ�ó���������ľ��
ntida.uID := iid; //�û��Զ����һ����ֵ����uCallbackMessage����ָ������Ϣ��ʹ
ntida.uFlags := nif_icon + nif_tip +nif_message; //ָ���ڸýṹ��uCallbackMessage��hIcon��szTip��������Ч
ntida.uCallbackMessage := mousemsg;  
//ָ���Ĵ�����Ϣ
ntida.hIcon := Application.Icon.handle;
//ָ��ϵͳ״̬����ʾӦ�ó����ͼ����
ntida.szTip := '��ǩϵͳ';
//�����ͣ����ϵͳ״̬����ͼ����ʱ�����ָ���ʾ��Ϣ
shell_notifyicona(NIM_ADD, @ntida); 
end;

procedure Tteblet_fr.addsum;
begin
   sum:=sum+1;
end;

function Tteblet_fr.getsum: Integer;
begin
  Result:=sum;
end;

procedure Tteblet_fr.clostablet(position: integer);
var
hdntmp:THandle;
WinControl: TWinControl;
begin
  hdntmp:=FindWindow('Tsticker_fr',PChar('tablet'+inttostr(position)));
 if hdntmp<>0 then
 begin
   WinControl:=FindControl(hdntmp);
   if (WinControl <> nil) then
        if (WinControl is TForm) then
           (WinControl as TForm).Close;
 end;
end;

procedure Tteblet_fr.add_tabletExecute(Sender: TObject);
begin
    gut_fr.clearExecute(Sender);
    gut_fr.cxButton1.Caption:='����';
    gut_fr.cxButton2.Caption:='ȡ��';
end;
 
procedure Tteblet_fr.ApplicationEvents1Minimize(Sender: TObject);
begin
ShowWindow(Handle, SW_HIDE); //����������
//����Ӧ�ó��򴰿����������ϵ���ʾ
ShowWindow(Application.Handle, SW_HIDE);
SetWindowLong(Application.Handle, GWL_EXSTYLE,
not (GetWindowLong(Application.handle, GWL_EXSTYLE)
or WS_EX_TOOLWINDOW and not WS_EX_APPWINDOW));

end;

procedure Tteblet_fr.FormCloseQuery(Sender: TObject;
  var CanClose: Boolean);
begin
canclose:=False;
if Application.MessageBox('�Ƿ�Y/N���˳���ǩϵͳ!','��ʾ',MB_ICONWARNING+mb_yesno)=idyes then
begin
    CanClose:=True; 
end;
end;

procedure Tteblet_fr.FormDestroy(Sender: TObject);
begin
shell_notifyicona(NIM_DELETE, @ntida);
end;

procedure Tteblet_fr.N3Click(Sender: TObject);
begin
if Application.MessageBox('�Ƿ�Y/N���˳���ǩϵͳ!','��ʾ',MB_ICONWARNING+mb_yesno)=idyes then
begin
   Application.Terminate;
end;
end;

procedure Tteblet_fr.N2Click(Sender: TObject);
begin
ShowWindow(Handle, SW_RESTORE);
//������������ʾӦ�ó��򴰿�
ShowWindow(Application.handle, SW_RESTORE);
SetWindowLong(Application.Handle, GWL_EXSTYLE,
not (GetWindowLong(Application.handle, GWL_EXSTYLE)
or WS_EX_TOOLWINDOW and not WS_EX_APPWINDOW));
end;

procedure Tteblet_fr.FormShow(Sender: TObject);
begin 
ShowPanel(gut_fr.Panel1);
ActiveStyleController:= gut_fr.StyleController;
recordload;
PostMessage(teblet_fr.Handle,WM_SYSCOMMAND, SC_MINIMIZE,0);
end;

procedure Tteblet_fr.backExecute(Sender: TObject);
var
  copyfr:Tback_fr;
begin
  copyfr:=Tback_fr.Create(Application);
  copyfr.ShowModal;
  copyfr.Free;
end;

end.
