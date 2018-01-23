using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertTo
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bTemp = new byte[10];
            byte[] HeaderData = new byte[20];
            SmallMode(100, 2, ref bTemp);            
            Console.WriteLine(HexToStr(bTemp,2));
            Array.Copy(bTemp, 0, HeaderData, 5,2);
            Console.WriteLine(HexToStr(HeaderData, 10));
            Random r = new Random();
            Console.WriteLine(Convert.ToString(r.Next(100000000, 720575940),16));
            Console.WriteLine(Convert.ToString(r.Next(1000000, 37927935),16));

            Console.ReadKey();
        }
        protected static void SmallMode(long lData, int iLen, ref byte[] outData)
        {
            string sTemp = "00000000000000000000000000000000000000000000000000";
            sTemp += Convert.ToString(lData, 16);
            sTemp = sTemp.Substring(sTemp.Count() - iLen*2);
            for (int i = 0; i < iLen; i++)
            {
                outData[iLen - i - 1] = Convert.ToByte(sTemp.Substring(i * 2, 2),16);
            }
        }


        protected static void StrToHex(string Data, int iLen, ref byte[] OutData)
        {
            string msTemp = "";
            for (int i = 0; i < iLen; i++)
            {
                msTemp = Data.Substring(i * 2, 2);
                OutData[i] = Convert.ToByte(msTemp, 16);
            }
        }

        protected static string HexToStr(byte[] Data)
        {
            string OutData = "";
            string msTemp = "";
            for (int j = 0; j < Data.Count(); j++)
            {
                msTemp = "00" + Convert.ToString(Data[j], 16);
                msTemp = msTemp.Substring(msTemp.Count() - 2);
                OutData +="_"+msTemp;
            }
            return OutData;
        }
        protected static string HexToStr(byte[] Data,int iLen)
        {
            string OutData = "";
            string msTemp = "";
            for (int j = 0; j < iLen; j++)
            {
                msTemp = "00" + Convert.ToString(Data[j], 16);
                msTemp = msTemp.Substring(msTemp.Count() - 2);
                OutData += "_" + msTemp;
            }
            return OutData;
        }
    }
}
