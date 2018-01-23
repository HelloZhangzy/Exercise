using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace HsSgDLL
{
    /// <summary>
    /// 虚拟接口类，提供外部调用依据
    /// </summary>
    //[Guid("694C1820-04B6-4988-928F-FD858B95C880")]
    public interface PInface
    {
        //读卡
         [DispId(1)] 
         int ReadCard(Int32 port, out string CardNO, out string Gas,
            out string Times, out string SumGas, out string AlarmGas1,
            out string AlarmGas2, out string MostGas, out Int32 CardType, out Int32 DataError, out Int32 ReturnData);
        //开户
         [DispId(2)] 
         int OpenCard(Int32 port, string CardNO, string Gas,
              string PresetGas, string AlarmGas1,
              string AlarmGas2, string MostGas, out string UserKey);
        //购气
         [DispId(3)]
         int BuyGas(Int32 port, string CardNO, string Gas,
              string Times, string AlarmGas1,
              string AlarmGas2, string MostGas, string UserKey);
        //回收卡
         [DispId(4)] 
         int InitCard(Int32 port, string Times, string UserKey);
        //补卡
         [DispId(5)] 
         int UPCard(Int32 port, string CardNO, string Gas,
              string Times, string AlarmGas1, string AlarmGas2, string MostGas, string UserKey);
        //退气
         [DispId(6)] 
         int ReturnGas(Int32 port, string UserKey);
        //换表
         [DispId(7)]
         int ChMeter(Int32 port, string CardNO, string Gas,
              string Times, string PresetGas, string AlarmGas1,
              string AlarmGas2, string MostGas, string UserKey, int OldNew);
    }
}
