unit Unit2;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Grids, DBGrids, DB, ADODB, StdCtrls;

type
  TForm2 = class(TForm)
    ADOConnection1: TADOConnection;
    DBGrid1: TDBGrid;
    ADOTable1: TADOTable;
    DataSource1: TDataSource;
    Button1: TButton;
    ADOQuery1: TADOQuery;
    Button2: TButton;
    Button3: TButton;
    procedure FormShow(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form2: TForm2;

implementation

{$R *.dfm}

procedure TForm2.Button1Click(Sender: TObject);
begin
ADOQuery1.sql.Clear;
ADOQuery1.SQL.Add('insert into sample18 values(9999,''中华人民共和国'',''中华人民共和国'',''中华人民共和国'',''中华人民共和国'',''中华人民共和国'',''中华人民共和国'',''028-84865537'',''2009-12-15'');');
ADOQuery1.ExecSQL;
ADOTable1.Active:=false;
ADOTable1.active:=true;
end;

procedure TForm2.Button2Click(Sender: TObject);
var
sql:string;
begin
  sql:='CREATE TABLE temp(a char(6)) ';
  ADOQuery1.SQL.Clear;
  ADOQuery1.SQL.Add(sql);
  ADOQuery1.ExecSQL;  
end;

procedure TForm2.Button3Click(Sender: TObject);
begin
  ADOQuery1.SQL.Clear;
  ADOQuery1.SQL.Add('insert into temp values(''1'');');
  ADOQuery1.ExecSQL;
  ADOQuery1.SQL.Clear;
  adoquery1.sql.add('select * from temp;');
  ADOQuery1.Open;
  DataSource1.DataSet:=ADOQuery1;
end;

procedure TForm2.FormShow(Sender: TObject);
 var   vfpdbfpath,sql:string;
  begin   
        vfpdbfpath:='F:\Exercise\操作DBF\sample18.dbf'   ;
      try
        ADOConnection1.Close;
        adoconnection1.ConnectionString:='Provider=MSDASQL.1;Persist Security Info=False;Extended Properties="DSN=dbff;'
                                         +'DBQ=F:\EXERCISE\操作DBF;DefaultDir=F:\EXERCISE\操作DBF;DriverId=533;FIL=dBase 5.0;MaxBufferSize=2048;'
                                          +'PageTimeout=5;";Initial Catalog=F:\EXERCISE\操作DBF';
//        Provider=MSDASQL.1;Persist Security Info=False;Data Source=dbff;Extended Properties="DSN=dbff;DBQ=F:\EXERCISE\操作DBF;DefaultDir=F:\EXERCISE\操作DBF;DriverId=533;FIL=dBase 5.0;MaxBufferSize=2048;PageTimeout=5;";Initial Catalog=F:\EXERCISE\操作DBF
        ADOConnection1.Open;
        if   ADOConnection1.Connected     then
            begin
                  Form2.Caption:='数据库连接成功！';
                  ADOTable1.Open;
            end;
      except
         Form2.Caption:='数据库连接失败！';
      end;

end;

end.
