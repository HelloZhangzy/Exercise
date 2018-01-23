using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using System.Threading.Tasks;

namespace ConsoleApp2
{
    // [StructLayoutAttribute(LayoutKind.Auto, CharSet = CharSet.Ansi, Pack = 1)]
    //[StructLayout(LayoutKind.Auto, CharSet = CharSet.Auto, Size = 18)]
    struct test_21
    {        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] Flag;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Name;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public char[] YZCode;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public char[] UserCode;

        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Marshal.SizeOf(typeof(test_21));
            string str = "21张张220000000012";            
            byte[] Bstr = Encoding.Default.GetBytes(str);
            test_21 B =(test_21)BytesToStuct(Bstr, typeof(test_21));
            Console.WriteLine(B.Flag);
            Console.WriteLine(B.YZCode);
            Console.WriteLine(B.UserCode);
            Console.WriteLine(Encoding.Default.GetString(B.Name));
           // Console.WriteLine(B.UserCoded);
            byte[] Sstr = StructToBytes(B);
            Console.WriteLine(Encoding.Default.GetString(Sstr));
            Console.Read();
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }        

        /// <summary>
        /// 字节数组转16进制字符串
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 字符串转16进制字节数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static byte[] strToToHexByte2(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length ) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i, 1), 10);
            return returnBytes;
        }


        /// <summary>
        /// 结构体转byte数组
        /// </summary>
        /// <param name="structObj">要转换的结构体</param>
        /// <returns>转换后的byte数组</returns>
        public static byte[] StructToBytes(object structObj)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回byte数组
            return bytes;
        }


        /// <summary>
        /// byte数组转结构体
        /// </summary>
        /// <param name="bytes">byte数组</param>
        /// <param name="type">结构体类型</param>
        /// <returns>转换后的结构体</returns>
        public static object BytesToStuct(byte[] bytes, Type type)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            //byte数组长度小于结构体的大小
            if (size > bytes.Length)
            {
                //返回空
                return null;
            }
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将byte数组拷到分配好的内存空间
            Marshal.Copy(bytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

    }
}
