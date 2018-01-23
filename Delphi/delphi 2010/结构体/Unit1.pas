unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls,DBXJSON,DBXJSONReflect;

type
  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

type
    TSelectData=record

			HardWareVer:array[0..3] of Byte;			//硬件版本号
			SoftWareVer:array[0..3] of Byte;			//软件版本号
			ProtocolVer:array[0..3] of Byte;			//协议版本号
        //12
			SN:array[0..15] of Byte;					//设备序列号
        //uint8_t     VenderName[16];         //厂家名称或者代码
			DeviceName:array[0..15] of Byte;			//设备名称或者型号
		//配置信息，与设备本身参数有关
		//针对煤气表，qmax，qmin，qst(始动流量)等具有一一对应关系，见GB/T 6968
			QN:Word;						//标称流量，
			QMAX:Word;					//最大流量，
        //48
			QMIN:Word;					//最小流量，
			QS:Word;						//脉冲当量，
			MMR:Word;					//最大测量(显示)范围，
		  VavleOnTime:Word;			//开阀门需要的时间,s·
		VavleOffTime:Word;			//关阀门需要的时间,s·
			xreverse00:Word;				//预留，对齐
		//block 54
		//mode configure descriptor,工作模式配置信息
				DWM:Word;					//工作模式，普通抄表模式，气量模式等

				PS:Word;						//最小计价单位，与硬件信息无关
        //64
			ConstFlowTimeOut:Word;		//超时设置
			ConstNoFlowTimeOut:Word;		//长时间不用气设置，
			ConstSmallFlowTimeOut:Word;	//长时间小流量
			ConstNoFlowTimeOutEx:Word;				//预留，对齐
		//72
			SetpPrice:array[0..5] of integer;			//阶梯价格
			SetpVolume:array[0..5] of integer;			//阶梯价格用量
        //120
				MaxOverageVM:Integer;			//最大屯气量
		//int32_t		MaxOverageM;			//最大屯气金额
			rdPeriod:Word;			//结算周期
             xreverse001:Byte;
             xreverse002:Byte;
				ReadTime:array[0..3] of Byte;			//结算时间
        //128

			PriceCoeff:array[0..11] of Word;			//调价系数，以及调价算法
		//152
				WarnSetOverageVM:Integer;
				OffSetOverageVM:Integer;
		//int32_t		WarnSetOverageM;
		//int32_t		OffSetOverageM;
        xreverse0x:array[0..3] of Byte;
        //164

			ID:Integer;						//设备id
        userID:Integer;				//用户id
				keyIndex:Byte;			//秘钥等级，密匙索引
             xreverse0:Byte;
        	CompanyCode:Word;				//用户id
		//140
		//uint8_t		userName[18];			//用户名称
				cardKeyCreatKey:array [0..15] of Byte;				//ic卡密码，
				DefaultKey:array [0..15] of Byte;				//厂家,	针对des 128bits
				userKey:array [0..15] of Byte;				//用户秘钥
        //188
		//device work
			YY:Byte;				//上次结算年
		 MM:Byte;              //上次结算月
			DLCS:Word;					//设备状态生命周期,可兼容S=ABCDE
        //192
				OVerageVM:Integer;			//余量
				LastBSNVM:Integer;	   			//上次充值业务流水号
		//int32_t		OVerageMoney;			//余额
		//int32_t		LastBSNM;				//上次充值业务流水号
        //200
				TotalVolume:Integer;			//总量
				VolumePerMon:array[0..5] of Integer;		//最近6月历史用量,方量
        //228

				TotalPayment:Integer;			//总金额
				MoneyPerMon:array[0..5]of Integer;			//最近6月历史用量,金额
        //256

			event:Integer;				//事件记录
			lock:Integer;				//锁定记录
		//264
		//购气信息				//金额表,复杂协议，高级加密
				PaymentVM:array[0..5] of Integer;
				PaymentVMBSNM:array[0..5] of Integer;
		//购气信息				//方量表，复杂协议，高级加密
		//int32_t		PaymentVolume[6];
		//int32_t		PaymentVolumeBSNM[6];
        //312

		//节假日信息 block	15,14,13
				HolidayInf:array[0..47]of Byte;			//节假日信息

			crc:Word;
    end;
     PSelectData =^TSelectData;

  TItemRecord = class
  private
     FID: string;
     FSubject: string;
     FADate: TDateTime;
  published
    property ID: string read FID write FID;
    property Subject: string read FSubject write FSubject;
    property ADate: TDateTime read FADate write FADate;
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

procedure TForm1.Button1Click(Sender: TObject);
var
    SelectData:PSelectData;
begin
   ShowMessage(inttostr(Integer(@SelectData.HardWareVer[0])));
   ShowMessage(inttostr(Integer(@SelectData.SoftWareVer[0])));
   ShowMessage(inttostr(Integer(@SelectData.ProtocolVer[0])));
end;

procedure TForm1.Button2Click(Sender: TObject);
var
JO:  TJSONObject;
P:TJSONPair;
A:TJSONArray;
B:TBytes;
S:string;
JM:TJSONMarshal;
JUM:TJSONUnMarshal;
Item:  TItemRecord;
V, V2:TJSONValue;
UJ: TJSONUnMarshal;
begin
  //采用 JSON
  JM:=TJSONMarshal.Create(TJSONConverter.Create);
  Item := TItemRecord.Create;

  Item.ID :=  '1';
  Item.Subject :='2';
  Item.ADate :=  now;

  V:=JM.Marshal(Item);  //序列化
  S := V.ToString;
  Item.Free;
  V.Free;
  Memo1.Lines.Text := S;

  //------------------- 反序列化-------------
  JO :=  TJSONObject.Create;
  JO.Parse(BytesOf(S), 0, Length(S));  //将字符串变回 Json  对象

  UJ := TJSONUnMarshal.Create;
  Item := UJ.Unmarshal(JO) as  TItemRecord;  //将 Json 对象变回我自己的对象。

  Memo1.Lines.Add('-----------');
  Memo1.Lines.Add('ID = ' + Item.ID);
  Memo1.Lines.Add('Subject = ' +  Item.Subject);   //问题： 对字符串里面的汉字编码没搞好，有问题。
  Memo1.Lines.Add('Date = ' +  DateTimeToStr(Item.ADate));

end;

end.
