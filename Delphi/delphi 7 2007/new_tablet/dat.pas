unit dat;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls,sticker;

type
  TabletRecord=
  packed
  record
     TabletTxt:string[20000];   //��ǩ����
     TabletDate:TDateTime;    //����ʱ��
     TabletDay:integer;       //��������
     TabletBool:Boolean;      //�Ƿ���ʾ
     Tabletrank:Integer;      //����
     tabletcrdate:TDateTime;  //����޸�ʱ��
     tabletupdate:TDateTime;  //����ʱ��
     tabletAccessories:string[200]; //����
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
      function datadd(data:TabletRecord):Boolean;overload;//��������
      function datadd(data:TabletRecord;position:Integer):Boolean;overload;//��������
      function datread(var data:Trecord):Boolean; //��ȡȫ������
      function datnonceread(var data:TabletRecord;position:Integer):Boolean;//��ȡָ������
      function GetRecordCount():Integer; //������ʾ¼����
      function DeleteRecord(Position:Integer):Boolean;   //ɾ��ָ������
      function getx():integer;//����X
      function gety():integer;//����Y
      procedure xszm(data:TabletRecord);//��ʾ����
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

{ try//�жϲ����Ƿ�ɹ������ڷ��غ���ֵ
    AssignFile(F,AppPath+DataFileName);
    try//Ϊ��ȷ���ͷ��ļ�
      Reset(F);
      //�ƶ��ļ�ָ�뵽�ļ�ĩβ
      Seek(F,GetRecordCount);
      Write(F,data);
    finally
      CloseFile(F);
    end;
  except
    Result:=False;
    //�˳�����
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

try//�жϲ����Ƿ�ɹ������ڷ��غ���ֵ
  coun:=GetRecordCount;
    AssignFile(F,AppPath+DataFileName);
    try//Ϊ��ȷ���ͷ��ļ�
      Reset(F);
      if Position>coun-2  then
      begin
         seek(F,coun -1);
      end
      else
      begin
        for i:=Position to coun -2 do
        begin
          //��ȡ��һ����¼
          seek(F,i+1);
          read(F,PersonRec);
          //���ǵ�ǰ��¼��¼
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
    //�˳�����
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
    //�ƶ��ļ�ָ�뵽ָ��λ��
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
  scX := GetSystemMetrics(SM_CXSCREEN); //�ֱ��ʿ�
  Randomize;
  Result:=Random(200)+scX-400;
end;

function TDat.gety: integer;
begin
  //scx := GetSystemMetrics(SM_CYSCREEN); //�ֱ��ʸ�
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
    //�ƶ��ļ�ָ�뵽ָ��λ��
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
  try//�жϲ����Ƿ�ɹ������ڷ��غ���ֵ
    AssignFile(F,AppPath+DataFileName);
    try//Ϊ��ȷ���ͷ��ļ�
      Reset(F);
      //�ƶ��ļ�ָ�뵽�ļ�ĩβ
      Seek(F,position);
      Write(F,data);
    finally
      CloseFile(F);
    end;
  except
    Result:=False;
    //�˳�����
    exit;
  end;
  Result:=True;    
end;

end.
