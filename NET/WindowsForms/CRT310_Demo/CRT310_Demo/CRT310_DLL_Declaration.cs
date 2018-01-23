using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace CRT310_Demo
{
    static class CRT310_DLL_Objects
    {

        const string CRT_310_DllName = "CRT_310.dll";

        #region 读卡器相关
        [DllImport(CRT_310_DllName)]
        public extern static int GetSysVerion(int ComHandle, ref string strVerion);

        [DllImport(CRT_310_DllName)]
        public extern static int CommOpen(string Port);

        [DllImport(CRT_310_DllName)]
        public extern static int  CommOpenWithBaut(string Port, uint _data);

        [DllImport(CRT_310_DllName)]
        public extern static int CommClose(int ComHandle);

        [DllImport(CRT_310_DllName)]
        public extern static int CommSetting(int ComHandle, string ComSeting);

        [DllImport(CRT_310_DllName)]
        public extern static int CRT_R_SetComm(int ComHandle, uint _data);

        /// <summary>
        /// 卡机初始化
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Eject">弹卡选择。 0x30=不弹卡 0x31=弹卡到前端 0x32=弹卡到后端。</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_Reset(int ComHandle, byte _Eject);

        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_ReadSnr(int ComHandle, ref byte[] _SNData,ref byte _dataLen);

        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_WriteSnr(int ComHandle, byte[] _SNData, byte _dataLen);


        /// <summary>
        /// 卡机进卡设置
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_CardIn"> 
        /// 前端进卡设置：
        /// 0x31 不允许；
        /// 0x32 磁卡方式（磁信号+开关同时有效）进卡使能, 只允许磁卡从前端开闸门进卡；
        /// 0x33 开关信号方式进卡使能，允许磁卡，IC 卡，M1 射频卡，双界面卡从前端开闸门进卡。 
        /// 0x34 磁信号方式进卡使能, 针对薄磁卡等一些纸卡进卡； 
        /// <param name="_EnableBackIn">是否允许后端进卡。 0x30=允许；0x31=不允许。</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]     
        public extern static int CRT310_CardSetting(int ComHandle, byte _CardIn, byte _EnableBackIn);


        /// <summary>
        /// 停卡位置设置
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Position"> 
        /// 0x30 进卡后停卡在前端位置，不持卡。
        /// 0x31 进卡后停卡在前端位置，并持卡。
        /// 0x32 进卡后停卡在卡机内位置，但是IC 卡触点没有与卡接触，M1 射频卡可以进行读写操作。
        /// 0x33 进卡后停卡在卡机内位置，同时将IC 卡座触点与卡接触，直接可进行IC 卡操作。
        /// 0x34 进卡后停卡在后端位置，并持卡。
        /// 0x35 进卡后将卡从后端弹出，不持卡。
        /// </param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_CardPosition(int ComHandle, byte _Position);


        /// <summary>
        /// 取卡机状态
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_atPosition">
        /// 0X46 卡机内有长卡(卡的长度长于标准卡长度)
        /// 0X47 卡机内有短卡(卡的长度短于标准卡长度)
        /// 0X48 卡机前端,不持卡位置有卡。
        /// 0X49 卡机前端持卡位置有卡。
        /// 0X4A 卡机内停卡位置有卡。
        /// 0X4B 卡机内IC 卡操作位置有卡，并且IC 卡触点已下落。
        /// 0X4C 卡机后端持卡位置有卡。
        /// 0X4D 卡机后端不持卡位置有卡。
        /// 0X4E 卡机内无卡。
        /// </param>
        /// <param name="_frontSetting">
        /// 0X49 卡机允许磁信号方式进卡,只允许磁卡开闸门进卡。
        /// 0X4A 卡机允许开关信号方式进卡，允许磁卡，IC 卡，M1 射频卡，双界面卡进卡。
        /// 0X4B 卡机允许磁信号方式进卡，允许纸磁卡，薄卡进卡。0X4E 卡机禁止进卡。</param>
        /// <param name="_rearSetting">
        /// 0X4A 卡机允许后端进卡，允许磁卡，IC 卡，M1 射频卡，双面卡进卡。
        /// 0X4E 卡机禁止后端进卡。</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_GetStatus(int ComHandle, ref byte _atPosition, ref byte _frontSetting, ref byte _rearSetting);


        /// <summary>
        /// 读 CRT310 感应器状态(V2专用)
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PSS1">
        /// _PSS1—_PSS5： 红外传感器状态： 
        /// PSSx=0X30 表示此传感器位置上未探测到卡片；
        /// PSSx=0X31 表示探测到有卡片。</param>
        /// <param name="_PSS2"></param>
        /// <param name="_PSS3"></param>
        /// <param name="_PSS4"></param>
        /// <param name="_PSS5"></param>
        /// <param name="_CTSW">
        /// 闸门状态信息 CTSW=0X30 表示闸门已关闭；
        /// CTSW=0X31 表示闸门已打开。</param>
        /// <param name="_KSW">
        /// 开关进卡传感受器状态 
        /// KSW=0X30 表示开关没有检测到卡片插入闸门信号；
        /// KSW=0X31 表示开关检测到有卡片插入闸门。
        /// </param>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_SensorStatusV2(int ComHandle, ref byte _PSS1, ref byte _PSS2, ref byte _PSS3, ref byte _PSS4, ref byte _PSS5, ref byte _CTSW, ref byte _KSW);

        /// <summary>
        /// 读 CRT310 感应器状态（V3 专用）。
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PSS0">
        /// _PSS0—_PSS5： 红外传感器状态： 
        /// PSSx=0X30 表示此传感器位置上未探测到卡片；
        /// PSSx=0X31 表示探测到有卡片。</param>
        /// <param name="_PSS1"></param>
        /// <param name="_PSS2"></param>
        /// <param name="_PSS3"></param>
        /// <param name="_PSS4"></param>
        /// <param name="_PSS5"></param>
        /// <param name="_CTSW">
        /// 闸门状态信息 CTSW=0X30 表示闸门已关闭；CTSW=0X31 表示闸门已打开。
        /// </param>
        /// <param name="_KSW">
        /// 开关进卡传感受器状态 KSW=0X30 表示开关没有检测到卡片插入闸门信号；KSW=0X31 表示开关检测到有卡片插入闸门。
        /// </param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_SensorStatusV3(int ComHandle, ref byte _PSS0, ref byte _PSS1, ref byte _PSS2, ref byte _PSS3, ref byte _PSS4, ref byte _PSS5, ref byte _CTSW, ref byte _KSW);


        /// <summary>
        /// 走卡位置设置
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Position">
        /// 0x2E 将卡重新走位到卡机内位置,操作成功后可进行M1 射频卡操作。
        /// 0x2F 将卡重新走位到卡机内位置，并将IC 卡触点落下，操作成功后可进行接触式IC 卡操作。
        /// 0x30 将卡重新走位到前端位置，不持卡。
        /// 0x31 将卡重新走位到前端位置，并持卡。
        /// 0x32 将卡重新走位到后端位置，并持卡。
        /// 0x33 将卡重新走位后端位置，不持卡。
        /// 0x34 将异常长度卡（短卡，长卡）清出卡机内，将卡向后端弹卡，对于短卡还需人工在卡口插正常卡辅助操作.
        /// 0x37 启动清洁卡操作
        /// </param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_MovePosition(int ComHandle, byte _Position);


        /// <summary>
        /// 指示灯亮/灭设置
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_ONOFF">=0x30 亮指示灯 0x31 灭指示灯</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_LEDSet(int ComHandle, byte _ONOFF);


        /// <summary>
        /// 指示灯亮/灭时间设置
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_T1">亮指示灯时间值（_T1 值为0x00-0xFF，时间值为0.25 秒 X _T1）</param>
        /// <param name="_T2">灭指示灯时间值（_T2 值为0x00-0xFF，时间值为0.25 秒 X _T2）</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT310_LEDTime(int ComHandle, byte _T1, byte _T2);
        #endregion

        #region IC卡相关
        /// <summary>
        /// 卡片上电
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT_IC_CardOpen(int ComHandle);

        /// <summary>
        /// 卡片下电
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT_IC_CloseCard(int ComHandle);


        /// <summary>
        /// 自动测试读卡机中的卡片类型
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_CardType"></param>
        /// <param name="_CardInfor"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int CRT_R_DetectCard(int ComHandle, ref byte _CardType, ref byte _CardInfor);

        #endregion

        #region SEL4442卡

        /// <summary>
        /// SEL4442 复位
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_Reset(int ComHandle);

        /// <summary>
        /// SEL4442 读卡
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Address">起始地址</param>
        /// <param name="_dataLen">读取数据长度</param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_Read(int ComHandle, byte _Address, byte _dataLen, IntPtr _BlockData);

        /// <summary>
        /// SEL4442 读保护数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_ReadP(int ComHandle, byte[] _BlockData);

        /// <summary>
        /// SEL4442 读安全数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_ReadS(int ComHandle, byte[] _BlockData);

        /// <summary>
        /// SEL4442 验证密码
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PWData">密码（3个字节）</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_VerifyPWD(int ComHandle, byte[] _PWData);

        /// <summary>
        /// SEL4442 写数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Address">起始地址</param>
        /// <param name="_dataLen">数据长度</param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_Write(int ComHandle, byte _Address, byte _dataLen, byte[] _BlockData);

        /// <summary>
        /// SEL4442 写保护数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_BlockData"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_WriteP(int ComHandle, byte[] _BlockData);


        /// <summary>
        /// SEL4442 改写密码
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PWData">密码（3个字节）</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int SLE4442_WritePWD(int ComHandle, byte[] _PWData);

        #endregion

        #region AT88SC102卡
        /// <summary>
        /// AT88SC102 复位
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int  AT88SC102_Reset(int ComHandle);
        

        /// <summary>
        /// AT88SC102 验证主密码
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PWData">密码（2个字节）</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int AT88SC102_VerifyPWD(int ComHandle, byte[] _PWData);

        /// <summary>
        /// AT88SC102 写密码
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_PWIndex">密码类型选择。0=主密码；1=擦除密码一；2=擦除密码二</param>
        /// <param name="_PWData">密码</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int AT88SC102_WritePWD(int ComHandle, byte _PWIndex, byte[] _PWData);

        /// <summary>
        /// AT88SC102 读数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Index">数据区选择。0=控制区；1=应用区一；2=应用区二</param>
        /// <param name="_Address">起始地址</param>
        /// <param name="_dataLen">数据长度</param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int AT88SC102_Read(int ComHandle, byte _Index, byte _Address, byte _dataLen,IntPtr _BlockData);

        /// <summary>
        /// AT88SC102 擦除数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Index">数据区选择。0=控制区；1=应用区一；2=应用区二</param>
        /// <param name="_Address">起始地址</param>
        /// <param name="_dataLen">数据长度</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int AT88SC102_Security1Clear(int ComHandle, byte _Index, byte _Address, byte _dataLen);

        /// <summary>
        /// AT88SC102 写数据
        /// </summary>
        /// <param name="ComHandle"></param>
        /// <param name="_Index">数据区选择。0=控制区；1=应用区一；2=应用区二</param>
        /// <param name="_Address">起始地址</param>
        /// <param name="_dataLen">数据长度</param>
        /// <param name="_BlockData">数据</param>
        /// <returns></returns>
        [DllImport(CRT_310_DllName)]
        public extern static int AT88SC102_Write(int ComHandle, byte _Index, byte _Address, byte _dataLen, byte[] _BlockData);
        #endregion

        public static string GetErrorMsg(int err_i)
        {
            switch (err_i)
            {
                case 0x00:return "未定义的命令";
                case 0x01: return "未定义的命令参数";
                case 0x02: return "命令不能执行";
                case 0x04: return "命令数据错误";
                case 0x05: return "输入电源电压不在卡机工作范围内";
                case 0x06: return "卡机内有非标准长度的异常长度卡（短卡或长卡）";
                case 0x07: return "当前卡机处于掉电状态，命令不能执行";
                default:
                    return "未知错误" + err_i.ToString("X") ;
            }
        }
    }
}
