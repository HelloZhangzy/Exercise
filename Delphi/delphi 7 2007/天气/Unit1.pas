unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs,msxml, StdCtrls, IdBaseComponent, IdComponent, IdTCPConnection,
  IdTCPClient, IdHTTP;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Memo1: TMemo;
    IdHTTP1: TIdHTTP;
    procedure FormCreate(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    function GetWebPage(const Url :string; IsUtf8 :Boolean = False):string;
  private
    { Private declarations }
    HttpReq: IXMLHttpRequest;
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

function TForm1.GetWebPage(const Url :string; IsUtf8 :Boolean = False):string;
var
  idp :TIdHTTP;
begin
  Result := '';
  idp := TIdHTTP.Create(Application);
  try
    idp.HandleRedirects := True;
    idp.Request.UserAgent := 'Mozilla/5.0';
    Result := idp.Get(Url);
    if IsUtf8 then
      Result := Utf8ToAnsi(Result);
  finally
    FreeAndNil(idp);
  end;
end;



procedure TForm1.Button1Click(Sender: TObject);
var
  url:string;
begin
  url:='http://www.xq361.com/imtopinfo.asp?username=304722538' ;
//  HttpReq.open('Get', Url, False, EmptyParam, EmptyParam);
//  HttpReq.send(EmptyParam);
//  Url := HttpReq.responseText;
  Memo1.Lines.Add(GetWebPage(url,False));
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
   HttpReq:=CoXMLHTTPRequest.Create;
end;

end.
