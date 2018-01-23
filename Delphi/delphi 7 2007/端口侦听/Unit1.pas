unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, Sockets, ExtCtrls, Menus,WinSock;

const
  WM_SOCK = WM_USER + 82;     {自定义windows消息}
    //在tcp 服务器方式下,WM_SOCK为监听消息
    // WM_SOCK+1到  WM_SOCK+MAX_ACCEPT 为与连接客户端进行通讯时的消息

  MAX_ACCEPT=100;
  FD_SET= MAX_ACCEPT;

type
  TForm1 = class(TForm)
    TcpServer1: TTcpServer;
    Button1: TButton;
    Button2: TButton;
    Label1: TLabel;
    Edit1: TEdit;
    Edit2: TEdit;
    Label2: TLabel;
    Memo1: TMemo;
    Label3: TLabel;
    Label4: TLabel;
    clientIP: TEdit;
    clientport: TEdit;
    Button3: TButton;
    Label5: TLabel;
    Edit3: TEdit;
    Bevel1: TBevel;
    Bevel2: TBevel;
    TcpClient1: TTcpClient;
    PopupMenu1: TPopupMenu;
    N1: TMenuItem;
    procedure TcpServer1Accept(Sender: TObject;
      ClientSocket: TCustomIpClient);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure N1Click(Sender: TObject);

  private
    { Private declarations }
    flag:BOOL;
    cliseSockets:array[0..99] of TCustomIpClient;
     procedure ReadData(var Message: TMessage);
  protected
        { Protected declarations }
        { other fields and methods}
         procedure  wndproc(var message:Tmessage);override;
  public
    { Public declarations }
  end;
  TClientDataThread = class(TThread)
  private
  public
    ListBuffer :TStringList;
    TargetList :TStrings;
    procedure synchAddDataToControl;
    constructor Create(CreateSuspended: Boolean);
    procedure Execute; override;
    procedure Terminate;
  end;
  function WinSockInital(Handle: HWnd):bool;
  Procedure WinSockClose();  


var
  Form1: TForm1;


  FSockLocal: TSockAddrIn;
  AcceptSock:Array[0..MAX_ACCEPT] OF Tsocket;
  FSockAccept : Array[0..MAX_ACCEPT] OF TSockAddrIn;
  AcceptSockFlag: Array[0..MAX_ACCEPT] OF boolean;

implementation

{$R *.dfm}

{始化SOCKET}
function WinSockInital(Handle: HWnd):bool;
var  TempWSAData: TWSAData;
     i:integer;
begin
     result := false;
     { 1 初始化SOCKET}
     if WSAStartup(2, TempWSAData)=1 then  //2表示启用winsock2
       exit;
     {若是用UDP通信，则用}
     if False then
       AcceptSock[0]:=Socket(AF_INET,SOCK_STREAM,0)
     else
       AcceptSock[0]:=Socket(AF_INET,SOCK_DGRAM,0);

     if AcceptSock[0]=SOCKET_ERROR then
       exit;

     if bind(AcceptSock[0],FSockLocal,sizeof(FSockLocal))<>0 then
     begin
       WinSockClose();
       exit;
     end;
//     if Listen(AcceptSock[0],1)<>0 then  //等待连接队列的最大长度为1
//     begin
//       WinSockClose();
//       exit;
//     end;
     WSAAsyncSelect(AcceptSock[0], Handle , WM_SOCK, FD_READ or FD_ACCEPT or FD_CLOSE);

     Result:=true;
end;
{关闭SOCKET}
Procedure WinSockClose();
var i:integer;
begin
  for i:=1 to MAX_ACCEPT DO
    if AcceptSockFlag[i] then
    begin
      CloseSocket(AcceptSock[i]);
      AcceptSockFlag[i]:=false;
    end;
  CloseSocket(AcceptSock[0]); {closesocket函数用来关闭一个描述符为AcceptSock[0]套接字}
  WSACleanup;
end;


constructor TClientDataThread.Create(CreateSuspended: Boolean);
begin
  inherited Create(CreateSuspended);
  FreeOnTerminate := true;
  ListBuffer := TStringList.Create;
end;

procedure TClientDataThread.Terminate;
begin
  ListBuffer.Free;
  inherited;
end;

procedure TClientDataThread.Execute;
begin
  Synchronize(synchAddDataToControl);
end;

procedure TClientDataThread.synchAddDataToControl;
begin
 TargetList.AddStrings(ListBuffer);
end;


procedure TForm1.TcpServer1Accept(Sender: TObject;
  ClientSocket: TCustomIpClient);
  var
  s: string;
  DataThread: TClientDataThread;
  redata:array[0..99] of char;
begin
//Memo1.Lines.Add(Format('%s(%s)',[ClientSocket.LookupHostName(ClientSocket.RemoteHost),ClientSocket.RemoteHost]));

  if not ClientSocket.Connected then   ShowMessage('1');
//  s:=ClientSocket.Receiveln(); //接收数据

  try
    ClientSocket.ReceiveBuf(redata,99,0);
//    ShowMessage(string(redata));
  except
     ShowMessage('2');
  end;

//  ShowMessage(s);
  while string(redata)<>SysUtils.EmptyStr do
  begin
    clientIP.Text:=ClientSocket.RemoteHost;
    clientport.Text:=ClientSocket.RemotePort;
    Memo1.Lines.Add(DateTimeToStr(Now())+'__'+ClientSocket.RemoteHost+'__'+string(redata));
    cliseSockets[0]:=TCustomIpClient.Create(nil);
    cliseSockets[0]:=ClientSocket;
//    s:=ClientSocket.Receiveln; //Receiveln和Sendln是一对的
    ClientSocket.ReceiveBuf(redata,99,0);
//    ShowMessage(string(redata));
  end;
  
end;

procedure TForm1.Button1Click(Sender: TObject);
begin
  try
   TcpServer1.Active:=False;
   TcpServer1.LocalHost:=string(Trim(Edit1.Text));
   TcpServer1.LocalPort:=string(Trim(Edit2.Text));
   TcpServer1.Active:=true;
   //TcpServer1.Open;
   flag:=True;
  except
    Application.MessageBox('启动侦听失败，请重新启动！','侦口端口',MB_OK+ MB_ICONERROR);
    exit;
  end;
  Memo1.Lines.Add(DateTimeToStr(Now())+':开始侦听"'+edit1.Text+'"');
  edit1.ReadOnly:=true;
  Edit2.ReadOnly:=true;
  Button1.Enabled:=false;
  Button2.Enabled:=True;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
 try
   TcpServer1.Active:=false;
   TcpServer1.Close;
   flag:=False;
 except
    Application.MessageBox('停止侦听失败，请重新停止！','侦口端口',MB_OK+ MB_ICONERROR);
    exit;
 end;
 Memo1.Lines.Add(DateTimeToStr(Now())+':停止侦听"'+edit1.Text+'"');
 edit1.ReadOnly:=False;
 Edit2.ReadOnly:=False;
 Button2.Enabled:=False;
 Button1.Enabled:=true;
end;

procedure TForm1.Button3Click(Sender: TObject);
var
  senddata:string;
  sendchar:array[0..99] of char;
  i:Integer;
begin
  if not cliseSockets[0].Connected then
  begin
      showmessage('连接已断！');
      exit;
  end;
//  if Length(Trim(Edit3.Text)) mod 2 <>0 then
//  begin
//     showmessage('数据库长为2的倍数！');
//     exit;
//  end;
//  for i:=0 to (Length(Trim(Edit3.Text)) div 2)-1 do
//  begin
//    try
//    sendchar[i]:=Char(StrToInt('$'+copy(Trim(edit3.Text),i*2+1,2)));
//    except
//      ShowMessage('数据不是十六进制数！');
//      exit;
//    end;
//  end;
//  sendchar[i]:=#0;
//   cliseSockets[0].SendBuf(sendchar,i,0);
//  sendchar[i+1]:=Char(StrToInt('$'+copy(Trim(edit3.Text),i*2+1,2)));



   cliseSockets[0].Sendln(Edit3.Text);
   //cliseSockets[0].Disconnect;

//  if Trim(Edit3.Text)='' then exit;
//    TcpClient1.Active:=False;
//    tcpclient1.RemoteHost:=string(Trim(clientIP.Text));
//    tcpclient1.RemotePort:=string(Trim(clientport.Text));
//    TcpClient1.Connect;
//    try
//      if TcpClient1.Connected then //表示连接成功
//       begin
//         TcpClient1.Sendln(Edit3.Text); //会触发TcpClient的OnSend事件和TcpServer的OnAccept事件
//         Caption:='发送成功！';
//       end
//       else
//        Caption:='未能连接服务器！';
//    finally
//      TcpClient1.Disconnect; //断开连接,会触发TcpClient的OnDisConnect事件
//    end;
end;

procedure TForm1.N1Click(Sender: TObject);
begin
  Memo1.Clear;
end;

procedure TForm1.wndproc(var message: Tmessage);
begin
   if (Message.Msg>=WM_SOCK) and (Message.Msg<=WM_SOCK+MAX_ACCEPT) then
    ReadData(Message)
  else
    inherited wndproc(message)

end;

procedure TForm1.ReadData(var Message: TMessage);
var
   // Receive_PACKAGE : TUDPaction;  //数据发送
   mdata:array[0..(120-1)] of char;
   flen,len,i,index: integer;
   Event: word;
begin
  Index:=(Message.Msg-WM_SOCK);
  flen:=sizeof(FSockAccept[Index]);
  Event := WSAGetSelectEvent(Message.LParam);
  if Event = FD_READ then
  begin
    len := recvfrom(AcceptSock[Index], mdata, sizeof(mdata), 0, FSockAccept[Index], Flen);
    if len> 0 then
    begin
        // StatusBar1.Panels[0].Text:='收到来自ip地址:'+inet_ntoa(FSockAccept[Index].sin_addr)+'   端口:'+inttostr(ntohs(FSockAccept[Index].sin_port))+'的数据';
//         StOpCode.Caption:= format('%.2d',[Receive_PACKAGE.opCode]);
//         StIndex.Caption:= format('%d',[Receive_PACKAGE.Index]);
//         StCommand.Caption:= format('%.2d',[Receive_PACKAGE.Command]);
         Memo1.Lines.Add(StrPas(mdata))
       end;
     end
     else if Event=FD_ACCEPT then
     begin
//       for i:=1 to MAX_ACCEPT DO
//         if not AcceptSockFlag[i] then
//         begin
//           flen:=Sizeof(FSockAccept[i]);
//           AcceptSock[i]:=accept(AcceptSock[0],@FSockAccept[i],@flen);
//           WSAAsyncSelect(AcceptSock[i], Handle , WM_SOCK+i, FD_READ or FD_CLOSE);
//           AcceptSockFlag[i]:=true;
//           AcceptNum:=AcceptNum+1;
//           CmbSendto.Items.Add('套接口:'+inttostr(i)+'   地址:'+inet_ntoa(FSockAccept[i].sin_addr)+'   端口:'+inttostr(ntohs(FSockAccept[i].sin_port)));
//            break;
//         end;
       //  StatusBar1.Panels[2].Text:='共有：'+inttostr(AcceptNum)+'个连接';
     end
     else if Event=FD_CLOSE then
     begin
//       WSAAsyncSelect(AcceptSock[index], FormTCPUDP.Handle, 0, 0);
//       if index<>0 then
//       begin
//         for i:=0 to CmbSendto.Items.Count-1 do
//           if CmbSendto.Items.Strings[i]= '套接口:'+inttostr(index)+'   地址:'+inet_ntoa(FSockAccept[index].sin_addr)+'   端口:'+inttostr(ntohs(FSockAccept[index].sin_port)) then
//           begin
//             CmbSendto.Items.Delete(i);
//             break;
//           end;
//         CloseSocket(AcceptSock[index]);
//         AcceptSockFlag[index]:=false;
//         AcceptNum:=AcceptNum-1;
//         //StatusBar1.Panels[2].Text:='共有：'+inttostr(AcceptNum)+'个连接';
//       end;
     end;

end;

end.
