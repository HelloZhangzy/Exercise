unit dat;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,sticker;

type
  TabletRecord=
  packed
  record
     TabletTxt:string[20000];   //标签内容
     TabletDate:TDateTime;    //提醒时间
     TabletDay:integer;       //提醒天数
     TabletBool:Boolean;      //是否显示
     Tabletrank:Integer;      //级别
     tabletcrdate:TDateTime;  //最后修改时间
     tabletupdate:TDateTime;  //创建时间
     tabletAccessories:string[200]; //附件
     x:integer;
     y:integer;
   end;

type
  Trecord   =   array   of   TabletRecord;

type
   TDat=class
   //private
    //  Trecord   :   array   of   TabletRecord;
   public
      Constructor Create(var FileYN:Boolean);
      function datadd(data:TabletRecord):Boolean;overload;//增加数据
      function datadd(data:TabletRecord;position:Integer):Boolean;overload;//增加数据
      function datread(var data:Trecord):Boolean; //读取全部数据
      function datnonceread(var data:TabletRecord;position:Integer):Boolean;//读取指定数据
      function GetRecordCount():Integer; //返回启示录条数
      function DeleteRecord(Position:Integer):Boolean;   //删除指定数据
      function getx():integer;//返回X
      function gety():integer;//返加Y
      procedure xszm(data:TabletRecord);//显示内容
   private
       function AppPath():string;
end;

const
  DataFileName='tablet.dat';

implementation


{ TDat }


function TDat.GetRecordCount():Integer;
Var
  F:file of TabletRecord;
  Count:Integer;
begin
  AssignFile(F,AppPath+DataFileName);
  try
    Reset(F);
    Count:=FileSize(F);
  finally
    CloseFile(F);
  end;
  Result:=Count;
end;


function TDat.AppPath: string;
begin
  Result:=ExtractFilePath(ParamStr(0));
end;

function TDat.datadd(data:TabletRecord): Boolean;
begin
  if datadd(data,GetRecordCount) then
     Result:=True
  else
     Result:=false;

{ try//判断操作是否成功，用于返回函数值
    AssignFile(F,AppPath+DataFileName);
    try//为了确保释放文件
      Reset(F);
      //移动文件指针到文件末尾
      Seek(F,GetRecordCount);
      Write(F,data);
    finally
      CloseFile(F);
    end;
  except
    Result:=False;
    //退出函数
    exit;
  end;
  Result:=True; }

 { try
        AppendRecord(data);
        Result:=true;
  except
        Result:=false;
  end;  }
end;


function TDat.DeleteRecord(Position:Integer):Boolean;
Var
  PersonRec:TabletRecord;
  F:file of TabletRecord;
  i,coun:Integer;

begin

try//判断操作是否成功，用于返回函数值
  coun:=GetRecordCount;
    AssignFile(F,AppPath+DataFileName);
    try//为了确保释放文件
      Reset(F);
      if Position>coun-2  then
      begin
         seek(F,coun -1);
      end
      else
      begin
        for i:=Position to coun -2 do
        begin
          //读取下一条记录
          seek(F,i+1);
          read(F,PersonRec);
          //覆盖当前记录记录
          seek(F,i);
          Write(F,PersonRec);
        end;
      end;
      Truncate(F);
    finally
      CloseFile(F);
    end;
  except
    Result:=False;
    //退出函数
    exit;
  end;
    Result:=True;  
end;

constructor TDat.Create(var FileYN:Boolean);
var
  F:file of TabletRecord;
begin
   assignfile(F,AppPath+DataFileName);
  if fileexists(AppPath+DataFileName) then
  begin
      FileYN:=True;
  end else
  begin
     rewrite(F);
     close(F);
     fileyn:=false;
  end;
  //TabletRecord
end;

function TDat.datread(var data: Trecord): Boolean;
Var
  PersonRec:TabletRecord;
  F:File of TabletRecord;
  Position,RecordCount:integer;
begin
  RecordCount:=GetRecordCount();
    
 // SetLength(fulldata,RecordCount);
  SetLength(data,RecordCount);

  AssignFile(F,AppPath+DataFileName);
  for Position:=0 to RecordCount-1 do
  try
    Reset(F);
    //移动文件指针到指定位置
    Seek(F,Position);
    Read(F,data[Position]);
  finally
    CloseFile(F);
    result:=false;
  end;
  // data:=fulldata;
    Result:=True;
end;

function TDat.getx: integer;
var
  scX:integer;
begin
  scX := GetSystemMetrics(SM_CXSCREEN); //分辨率宽
  Randomize;
  Result:=Random(200)+scX-400;
end;

function TDat.gety: integer;
begin
  //scx := GetSystemMetrics(SM_CYSCREEN); //分辨率高
  Randomize;
  Result:=Random(200)+5;

end;

procedure TDat.xszm(data: TabletRecord);
var
  temprecord:Trecord;
  i:Integer;
  ss:Tsticker_fr;
begin
  if data.TabletBool then
  begin
   ss:=Tsticker_fr.Create(nil);
   ss.xslr(data.TabletTxt,data.x,data.y,data.Tabletrank);
   ss.Show;
  end;

end;

function tdat.datnonceread(var data:TabletRecord;position:Integer):Boolean;
Var
  F:File of TabletRecord;
begin
  AssignFile(F,AppPath+DataFileName);
  try
    Reset(F);
    //移动文件指针到指定位置
    Seek(F,Position);
    Read(F,data);
  finally
    CloseFile(F);
    result:=false;
  end;
    result:=true;
end;

function TDat.datadd(data: TabletRecord; position: Integer): Boolean;
var
  f:file of TabletRecord;
begin
  try//判断操作是否成功，用于返回函数值
    AssignFile(F,AppPath+DataFileName);
    try//为了确保释放文件
      Reset(F);
      //移动文件指针到文件末尾
      Seek(F,position);
      Write(F,data);
    finally
      CloseFile(F);
    end;
  except
    Result:=False;
    //退出函数
    exit;
  end;
  Result:=True;    
end;

end.
