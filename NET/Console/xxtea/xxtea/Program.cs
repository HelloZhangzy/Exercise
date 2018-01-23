using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace xxtea
{
    

    class Program
    {
        
        static void Main(string[] args)
        {
        }


        /*************************************************************************
        v is the n word data vector
        k is the 4 word key,128bits
        n is negative for decoding
        if n is zero result is 1 and no coding or decoding takes place, 
        otherwise the result is zero
        assumes 32 bit 'long' and same endian coding and decoding
        **************************************************************************/
        void btea(uint32_t* v, int16_t n, uint32_t* key)
        {
            const DELTA= ;
            const MX= ;

            uint32_t y, z, sum;
            uint32_t p, rounds, e;
            if (n > 1)
            { // dencrypt        
                rounds = 6 + 52 / n;
                sum = 0;
                z = v[n - 1];
                do
                {
                    sum += 0x9e3779b9;
                    e = (sum >> 2) & 3;
                    for (p = 0; p < n - 1; p++)
                    {
                        y = v[p + 1];
                        z = v[p] += (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                    }
                    y = v[0];
                    z = v[n - 1] += (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                } while (--rounds);
            }
            else if (n < -1)
            { //dencrypt
                n = -n;
                rounds = 6 + 52 / n;
                sum = rounds * 0x9e3779b9;
                y = v[0];
                do
                {
                    e = (sum >> 2) & 3;
                    for (p = n - 1; p > 0; p--)
                    {
                        z = v[p - 1];
                        y = v[p] -= (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                    }
                    z = v[n - 1];
                    y = v[0] -= (((z >> 5 ^ y << 2) + (y >> 3 ^ z << 4)) ^ ((sum ^ y) + (key[(p & 3) ^ e] ^ z)));
                    sum -= 0x9e3779b9;
                } while (--rounds);
            }
        }
    }
}
