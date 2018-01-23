using System;
using SGAI.BLLChangChun;
using SGAI.SGModal;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection; 



namespace HsSgDLL
{
    /// <summary>
    /// 接口实现类继承于接口类PInface
    /// 提供外部调用函数
    /// </summary>
   // [ComVisible(true)]
   // [Guid("EA2F140A-108F-47ae-BBD5-83EEE646CC0D")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    public class CardOP : PInface
    {
        /// <summary>
        /// 功能：读卡
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="CardNO">卡号</param>
        /// <param name="Gas">气量</param>
        /// <param name="Times">次数</param>
        /// <param name="SumGas">累计气量</param>
        /// <param name="AlarmGas1">报警气量1</param>
        /// <param name="AlarmGas2">报警气量2</param>
        /// <param name="MostGas">最多存气量</param>
        /// <param name="CardType">卡类型编码</param>
        /// <param name="DataError">卡数据正确性</param>
        /// <param name="ReturnData">有无返回数据</param>
        /// <returns></returns>
        public int ReadCard(Int32 port, out string CardNO, out string Gas,
            out string Times, out string SumGas, out string AlarmGas1,
            out string AlarmGas2, out string MostGas, out Int32 CardType, out Int32 DataError, out Int32 ReturnData)
        {
            int str = -1;
            CardNO = "";
            Gas = "";
            Times = "";
            MostGas = "";
            SumGas = "";
            AlarmGas1 = "";
            AlarmGas2 = "";
            CardType = -1;
            DataError = -1;
            ReturnData = -1;

            PortModal ComPt = ComClass.SetCom(port);
            ReadCardModal userData = new ReadCardModal();            
            ReadCardChangChun read = new ReadCardChangChun();
            SGError TemError=read.readUserCard(ComPt, out userData);
           if (TemError==SGError.OK)
            { 
                    CardNO = userData.UserNo.ToString();
                    Gas = userData.BuyGasValue.ToString();
                    Times = userData.BuyGasCount.ToString();
                    MostGas  = userData.LimitGas.ToString();
                    SumGas = userData.TotalBuyGasNum.ToString();
                    AlarmGas1 = userData.Warn1.ToString();
                    AlarmGas2 = userData.Warn2.ToString();
                    CardType = ReturnCardType(userData.CardType);
                    DataError = ReturnDataError(userData.IsUserDataFommatError);
                    ReturnData = ReturnBlData(userData.HasReWriteData);
                    str = 0;
           } else  str = ReturnErrorCode(TemError);

            return str;
         }

        /// <summary>
        /// 功能：开户
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="CardNO">卡号</param>
        /// <param name="Gas">气量</param>
        /// <param name="PresetGas">预置气量</param>
        /// <param name="AlarmGas1">报警气量1</param>
        /// <param name="AlarmGas2">报警气量2</param>
        /// <param name="MostGas">最多存气量</param>
        /// <param name="UserKey">卡密码</param>
        /// <returns></returns>
        public int OpenCard(Int32 port, string CardNO, string Gas,
             string PresetGas,  string AlarmGas1,
             string AlarmGas2,  string MostGas,out string UserKey)
        {
            int ReturnCode=-1;
            UserKey = "";
            OpenAccountChangeChun openAccountChangeChun = new OpenAccountChangeChun();
            PortModal ComPt = ComClass.SetCom(port);
            ulong userNo = ulong.Parse(CardNO.Trim());
            uint buyGasValue = uint.Parse(Gas.Trim());
            uint preGasValue = uint.Parse(PresetGas.Trim());
            if (buyGasValue > preGasValue)
            {
                buyGasValue -= preGasValue;
                uint warn1 = uint.Parse(AlarmGas1.Trim());
                uint warn2 = uint.Parse(AlarmGas2.Trim());
                uint limitMaxGas = uint.Parse(MostGas.Trim());
                OpenAccountModal modal = new OpenAccountModal(userNo, buyGasValue, warn1, warn2, limitMaxGas, false);
                SGError TemError = openAccountChangeChun.OpenAccount(ComPt, modal);
                if (TemError==SGError.OK)
                {                   
                        ReturnCode = 0;
                        UserKey = modal.Password;
                }else                     
                        ReturnCode = ReturnErrorCode(TemError);
              
            } else  ReturnCode = 33;

            return ReturnCode;
        }

        /// <summary>
        /// 功能：购气
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="CardNO">卡号</param>
        /// <param name="Gas">气量</param>
        /// <param name="Times">次数</param>
        /// <param name="AlarmGas1">报警气量1</param>
        /// <param name="AlarmGas2">报警气量2</param>
        /// <param name="MostGas">最多存气量</param>
        /// <param name="UserKey">卡密码</param>
        /// <returns></returns>
        public int BuyGas(Int32 port, string CardNO, string Gas,
             string Times,  string AlarmGas1,
             string AlarmGas2, string MostGas, string UserKey)
        {
            int ReturnCode = -1;           
           
            BuyGasChangChun buyGas = new BuyGasChangChun();
            PortModal ComPt = ComClass.SetCom(port);
            ulong userNo = ulong.Parse(CardNO.Trim());
            uint buyGasValue = uint.Parse(Gas.Trim());
            uint warn1 = uint.Parse(AlarmGas1.Trim());
            uint warn2 = uint.Parse(AlarmGas2.Trim());
            uint limitMaxGas = uint.Parse(MostGas.Trim());
            string password = UserKey.Trim();
            uint buyGasCount = uint.Parse(Times.Trim());
            BuyGasModal buyGasData = new BuyGasModal(userNo, buyGasValue, buyGasCount, warn1, warn2, limitMaxGas, password);
            SGError TemError = buyGas.BuyGas(ComPt, buyGasData);
            if (TemError == SGError.OK)
                 ReturnCode = 0;
            else
                 ReturnCode = ReturnErrorCode(TemError); 
            return ReturnCode;
        }

        /// <summary>
        /// 功能：回收卡
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="Times">次数</param>
        /// <param name="UserKey">卡密码</param>
        /// <returns></returns>
        public int InitCard(Int32 port, string Times, string UserKey)
        {
            int ReturnCode = -1;
            RepairCardChangChun repair = new RepairCardChangChun();
            PortModal ComPt = ComClass.SetCom(port);
            SGError TemError = repair.RestoreCard(UserKey.Trim(), int.Parse(Times.Trim()), ComPt);
            if (TemError == SGError.OK)
                ReturnCode = 0;
            else
                ReturnCode = ReturnErrorCode(TemError);
            return ReturnCode;                   
        }

        /// <summary>
        /// 功能：补卡
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="CardNO">卡号</param>
        /// <param name="Gas">气量</param>
        /// <param name="Times">次数</param>
        /// <param name="AlarmGas1">报警气量1</param>
        /// <param name="AlarmGas2">报警气量2</param>
        /// <param name="MostGas">最多存气量</param>
        /// <param name="UserKey">卡密码</param>
        /// <returns></returns>
        public int UPCard(Int32 port, string CardNO, string Gas,
             string Times, string AlarmGas1,string AlarmGas2, string MostGas,  string UserKey)      
        {
            int ReturnCode = -1;            
            ReMakeCardChangChun reMakeCard = new ReMakeCardChangChun();
             PortModal ComPt = ComClass.SetCom(port);
            ulong userNo = ulong.Parse(CardNO.Trim());
            uint buyGasValue = uint.Parse(Gas.Trim());
            uint buyGasCount = uint.Parse(Times.Trim()); 
            uint warn1 = uint.Parse(AlarmGas1.Trim());
            uint warn2 = uint.Parse(AlarmGas2.Trim());
            uint limitMaxGas = uint.Parse(MostGas.Trim());
            string password = UserKey.Trim();
              ReMakeCardModal remakeCardData = new ReMakeCardModal(userNo, buyGasValue, buyGasCount, warn1, warn2, limitMaxGas, password);
            SGError TemError = reMakeCard.ReMakeCard(ComPt, remakeCardData);
                if (TemError == SGError.OK)                
                    ReturnCode = 0;
                else
                    ReturnCode = ReturnErrorCode(TemError);            
            return ReturnCode;          

        }
        /// <summary>
        /// 功能：退气
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="UserKey">卡密码</param>
        /// <returns></returns>
         public int ReturnGas(Int32 port, string UserKey)
                             //端口号，卡密码
        {
            int ReturnCode = -1;
            //UserKey = "";
            ClearGasChangChun clearGas = new ClearGasChangChun();
            PortModal ComPt = ComClass.SetCom(port);          
            string password = UserKey.Trim();
            //MessageBox.Show(port.ToString());
            SGError TemError = clearGas.ClearGas(ComPt, password.Trim());
             
            if (TemError == SGError.OK)                
                ReturnCode = 0;
            else
                ReturnCode = ReturnErrorCode(TemError);            
            return ReturnCode; 
        }

        /// <summary>
        /// 功能：换表
        /// </summary>
         /// <param name="port">端口号</param>
         /// <param name="CardNO">卡号</param>
         /// <param name="Gas">气量</param>
         /// <param name="Times">次数</param>
         /// <param name="PresetGas">补尝气量</param>
         /// <param name="AlarmGas1">报警气量1</param>
         /// <param name="AlarmGas2">报警气量2</param>
         /// <param name="MostGas">最多存气量</param>
         /// <param name="UserKey">卡密码</param>
         /// <param name="OldNew">旧卡/新卡</param>
        /// <returns></returns>
         public int ChMeter(Int32 port, string CardNO, string Gas,
             string Times, string PresetGas, string AlarmGas1, 
             string AlarmGas2, string MostGas, string UserKey,int OldNew)             
         {
             int ReturnCode = -1;
             bool isOldCard;
             ChangeMeterChangChun changemeter = new ChangeMeterChangChun();
             PortModal ComPt = ComClass.SetCom(port);
             ulong userNo = ulong.Parse(CardNO.Trim());
             uint buyGasValue = uint.Parse(Gas.Trim());
             uint preGasValue = uint.Parse(PresetGas.Trim());
             buyGasValue += preGasValue;
             uint warn1 = uint.Parse(AlarmGas1.Trim());
             uint warn2 = uint.Parse(AlarmGas2.Trim());
             uint limitMaxGas = uint.Parse(MostGas.Trim());
             string password = UserKey.Trim();
             uint oldMeterBuyGasCount = uint.Parse(Times.Trim());
             if (OldNew==0)
             {
                 isOldCard = true;
             }
             else
             {
                 isOldCard = false;
             }
             ChangeMeterModal modal = new ChangeMeterModal(userNo, buyGasValue, warn1, warn2, limitMaxGas, password, isOldCard, oldMeterBuyGasCount);
             modal.Password = password;
             SGError TemError = changemeter.ChangeMeter(ComPt, modal);
             if (TemError == SGError.OK)
                 ReturnCode = 0;
             else
                 ReturnCode = ReturnErrorCode(TemError);
             return ReturnCode; 
         }

        /// <summary>
        /// 功能：根据SGError枚举值返回相应的错误编码
        /// </summary>
         /// <param name="Error">SGError枚举</param>
        /// <returns></returns>
        private Int32 ReturnErrorCode(SGError Error)
        {
            switch (Error)
            {
                case SGError.CheckPasswordError:
                    return 21;
                case SGError.ClearCardButHasReWriteData:
                    return 46;
                case SGError.DataInCardIsWrong:
                    return 18;
                case SGError.EraseCardError:
                    return 22;
                case SGError.GetMachineStateError:
                    return 1;
                case SGError.ModifyPasswordError:
                    return 19;
                case SGError.NoCardInMachineError:
                    return 3;
                case SGError.NotBlankCard:
                    return 4;
                case SGError.NotHasReWriteCardData:
                    return 47;
                case SGError.OpenCommError:
                    return 1;
                case SGError.PasswordTimesLittleThanZeroError:
                    return 16;
                case SGError.ReadCardDataError:
                    return 20;
                case SGError.ReadPasswordTimesError:
                    return 5;
                case SGError.TurnOnError:
                    return 44;
                case SGError.WriteCardError:
                    return 23; 
 
                default:
                    return 33;
            }
        }

        /// <summary>
        /// 功能：根据CardTypeEnum枚举值返回相应的卡类型编码
        /// </summary>
        /// <param name="CardType">CardTypeEnum枚举</param>
        /// <returns></returns>
        private Int32 ReturnCardType(CardTypeEnum CardType)
        {
            switch (CardType)
            {
                case CardTypeEnum.blankCard:
                    return 1; //"空白卡"                     
                case CardTypeEnum.openAccountCard:
                    return 2;  //"开户卡"                 
                case CardTypeEnum.userCard:
                    return 3; // "用户卡"
                case CardTypeEnum.reMakeCard:
                    return 4; // "补卡后的卡"
                case CardTypeEnum.clearCard:
                    return 5;// "退卡后的卡";
                case CardTypeEnum.checkCard:
                    return 6;// "检查卡";
                case CardTypeEnum.unKnowCard:
                    return 7;//"未知卡";
                default:
                    return 7;//"未知卡";
            }
        }

        /// <summary>
        /// 功能：返回卡数据是否错误
        /// </summary>
        /// <param name="DataError">卡数据错误标识</param>
        /// <returns></returns>
        private Int32 ReturnDataError(bool DataError)
        {
            if (DataError)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// 功能：返回卡上是否有返回数据
        /// 私有函数，仅供类内部使用
        /// </summary>
        /// <param name="blData"></param>
        /// <returns></returns>
        private Int32 ReturnBlData(bool blData)
        {
            if (blData)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }

    /// <summary>
    /// 串口设置类
    /// </summary>
    internal class ComClass
    {
        /// <summary>
        /// 功能：设置串口号
        /// 公共类供外部调用
        /// </summary>
        /// <param name="port">端口号（0：COM1、1：COM2、2:COM3）</param>
        /// <returns></returns>
        public static PortModal SetCom(Int32 port)
        {
            PortModal ComPt = new PortModal();
            ComPt.Port = port;
            ComPt.Baud = 0x2580L;
            return ComPt;
        }
    }


}
