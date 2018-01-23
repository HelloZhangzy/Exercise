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

			HardWareVer:array[0..3] of Byte;			//Ӳ���汾��
			SoftWareVer:array[0..3] of Byte;			//����汾��
			ProtocolVer:array[0..3] of Byte;			//Э��汾��
        //12
			SN:array[0..15] of Byte;					//�豸���к�
        //uint8_t     VenderName[16];         //�������ƻ��ߴ���
			DeviceName:array[0..15] of Byte;			//�豸���ƻ����ͺ�
		//������Ϣ�����豸��������й�
		//���ú����qmax��qmin��qst(ʼ������)�Ⱦ���һһ��Ӧ��ϵ����GB/T 6968
			QN:Word;						//���������
			QMAX:Word;					//���������
        //48
			QMIN:Word;					//��С������
			QS:Word;						//���嵱����
			MMR:Word;					//������(��ʾ)��Χ��
		  VavleOnTime:Word;			//��������Ҫ��ʱ��,s��
		VavleOffTime:Word;			//�ط�����Ҫ��ʱ��,s��
			xreverse00:Word;				//Ԥ��������
		//block 54
		//mode configure descriptor,����ģʽ������Ϣ
				DWM:Word;					//����ģʽ����ͨ����ģʽ������ģʽ��

				PS:Word;						//��С�Ƽ۵�λ����Ӳ����Ϣ�޹�
        //64
			ConstFlowTimeOut:Word;		//��ʱ����
			ConstNoFlowTimeOut:Word;		//��ʱ�䲻�������ã�
			ConstSmallFlowTimeOut:Word;	//��ʱ��С����
			ConstNoFlowTimeOutEx:Word;				//Ԥ��������
		//72
			SetpPrice:array[0..5] of integer;			//���ݼ۸�
			SetpVolume:array[0..5] of integer;			//���ݼ۸�����
        //120
				MaxOverageVM:Integer;			//���������
		//int32_t		MaxOverageM;			//����������
			rdPeriod:Word;			//��������
             xreverse001:Byte;
             xreverse002:Byte;
				ReadTime:array[0..3] of Byte;			//����ʱ��
        //128

			PriceCoeff:array[0..11] of Word;			//����ϵ�����Լ������㷨
		//152
				WarnSetOverageVM:Integer;
				OffSetOverageVM:Integer;
		//int32_t		WarnSetOverageM;
		//int32_t		OffSetOverageM;
        xreverse0x:array[0..3] of Byte;
        //164

			ID:Integer;						//�豸id
        userID:Integer;				//�û�id
				keyIndex:Byte;			//��Կ�ȼ����ܳ�����
             xreverse0:Byte;
        	CompanyCode:Word;				//�û�id
		//140
		//uint8_t		userName[18];			//�û�����
				cardKeyCreatKey:array [0..15] of Byte;				//ic�����룬
				DefaultKey:array [0..15] of Byte;				//����,	���des 128bits
				userKey:array [0..15] of Byte;				//�û���Կ
        //188
		//device work
			YY:Byte;				//�ϴν�����
		 MM:Byte;              //�ϴν�����
			DLCS:Word;					//�豸״̬��������,�ɼ���S=ABCDE
        //192
				OVerageVM:Integer;			//����
				LastBSNVM:Integer;	   			//�ϴγ�ֵҵ����ˮ��
		//int32_t		OVerageMoney;			//���
		//int32_t		LastBSNM;				//�ϴγ�ֵҵ����ˮ��
        //200
				TotalVolume:Integer;			//����
				VolumePerMon:array[0..5] of Integer;		//���6����ʷ����,����
        //228

				TotalPayment:Integer;			//�ܽ��
				MoneyPerMon:array[0..5]of Integer;			//���6����ʷ����,���
        //256

			event:Integer;				//�¼���¼
			lock:Integer;				//������¼
		//264
		//������Ϣ				//����,����Э�飬�߼�����
				PaymentVM:array[0..5] of Integer;
				PaymentVMBSNM:array[0..5] of Integer;
		//������Ϣ				//����������Э�飬�߼�����
		//int32_t		PaymentVolume[6];
		//int32_t		PaymentVolumeBSNM[6];
        //312

		//�ڼ�����Ϣ block	15,14,13
				HolidayInf:array[0..47]of Byte;			//�ڼ�����Ϣ

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
  //���� JSON
  JM:=TJSONMarshal.Create(TJSONConverter.Create);
  Item := TItemRecord.Create;

  Item.ID :=  '1';
  Item.Subject :='2';
  Item.ADate :=  now;

  V:=JM.Marshal(Item);  //���л�
  S := V.ToString;
  Item.Free;
  V.Free;
  Memo1.Lines.Text := S;

  //------------------- �����л�-------------
  JO :=  TJSONObject.Create;
  JO.Parse(BytesOf(S), 0, Length(S));  //���ַ������ Json  ����

  UJ := TJSONUnMarshal.Create;
  Item := UJ.Unmarshal(JO) as  TItemRecord;  //�� Json ���������Լ��Ķ���

  Memo1.Lines.Add('-----------');
  Memo1.Lines.Add('ID = ' + Item.ID);
  Memo1.Lines.Add('Subject = ' +  Item.Subject);   //���⣺ ���ַ�������ĺ��ֱ���û��ã������⡣
  Memo1.Lines.Add('Date = ' +  DateTimeToStr(Item.ADate));

end;

end.
