using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak1
{
    public class LZW
    {
        string fileToDecode;
        int inputLength;
        uint R = 256;
        uint W = 16;
        int L = 65536;
        public LZW(string inputFileName, string outputFileName)
        {
            fileToDecode = outputFileName;
            using (BinaryReader br = new BinaryReader(File.Open(inputFileName, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(outputFileName, FileMode.Create)))
                {
                    TST<uint> st = new TST<uint>();
                    StringBuilder inputChars = new StringBuilder();
                    while (br.BaseStream.Position != br.BaseStream.Length)
                        inputChars.Append(Convert.ToChar(br.ReadByte()));
                    string input = inputChars.ToString();

                    uint R = 256;
                    uint W = 16;
                    int L = 65536;
                    for (uint i = 0; i < R; i++)
                        st.put("" + (char)i, i);
                    uint code = R + 1;

                    int inputStartIndex = 0;
                    inputLength = input.Length;
                    while(inputLength >inputStartIndex)
                    {
                        string s = st.longestPrefixOf(input, inputStartIndex);

                        bw.WriteIntBits(st.get(s), W);

                        if (s.Length < inputLength - inputStartIndex && code < L)
                            st.put(input.Substring(inputStartIndex, s.Length + 1), code++);
                        inputStartIndex += s.Length;
                    }
                    bw.WriteIntBits(R, W);
                }
            }
        }

        public void Decode()
        {
            using(BinaryReader br=new BinaryReader(File.Open(fileToDecode, FileMode.Open)))
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(fileToDecode.Substring(0,fileToDecode.Length-4) + "-decoded.txt", FileMode.Create), Encoding.UTF8))
                {
                    string[] st = new string[L];
                    uint i;

                    for(i=0;i<R;i++)
                        st[i]="" + (char)i;
                    st[i++] = "";

                    uint codeword = br.ReadUintBits(W);
                    if (codeword == R) return;
                    string val = st[codeword];

                    while(true)
                    {
                        foreach (char c in val)
                            bw.Write(Convert.ToByte(c));
                        codeword = br.ReadUintBits(W);
                        if(codeword == R) return;

                        string s = st[codeword];
                        if (i == codeword)
                            s = val + val[0];
                        if(i<L)
                            st[i++] = val + s[0];
                        val = s;

                        //OVAJ DEO IH SVE STAMPA NA KONZOLI
                       /* for (int j = 0; j < st.Length; j++)
                        {
                            if (j > R && string.IsNullOrEmpty(st[j]))
                                break;

                            Console.WriteLine($"[{st[j]}, {j}]");
                        }*/

                    }
                    
                }
            }
        }

        public int CompressionRatio (string file1, string file2)
        {
            long l1;
            long l2;
            
            string f1 = FileRepo.ReadAsString(file1);
            string f2 = FileRepo.ReadAsString(file2);

            l1 = f1.Length;
            l2 = f2.Length;

            var vel1 = Convert.ToDouble(l1);
            var vel2 = Convert.ToDouble(l2);

            
            return (int)((100 * (1 - (vel1 / vel2))));

        }
    }
}
