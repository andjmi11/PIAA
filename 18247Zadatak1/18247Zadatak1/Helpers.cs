﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak1
{
   
    public class BinaryWriter : System.IO.BinaryWriter
    {
        private bool[] curByte = new bool[8];
        private byte curBitIndx = 0;
        private System.Collections.BitArray ba;

        public BinaryWriter(Stream s) : base(s) { }
        public BinaryWriter(Stream s, Encoding e) : base(s, e) { }

        public override void Flush()
        {
            base.Write(ConvertToByte(curByte));
            base.Flush();
        }

        public override void Write(byte value)
        {
            ba = new BitArray(new byte[] { value });
            for (byte i = 0; i < 8; i++)
            {
                this.Write(ba[i]);
            }
            ba = null;
        }

        public override void Write(bool value)
        {
            curByte[curBitIndx] = value;
            curBitIndx++;

            if (curBitIndx == 8)
            {
                base.Write(ConvertToByte(curByte));
                this.curBitIndx = 0;
                this.curByte = new bool[8];
            }
        }

        public void WriteIntBits(uint value, uint numOfBits)
        {
            ba = new BitArray(BitConverter.GetBytes(value));
            for (sbyte i = (sbyte)(numOfBits - 1); i >= 0; i--)
            {
                //Console.WriteLine(ba[i]);
                this.Write(ba[i]);
            }
            ba = null;
        }

        private static byte ConvertToByte(bool[] bools)
        {
            byte b = 0;

            byte bitIndex = 0;
            for (int i = 0; i < 8; i++)
            {
                if (bools[i])
                {
                    b |= (byte)(((byte)1) << bitIndex);
                }
                bitIndex++;
            }

            return b;
        }
    }

    internal class BinaryReader : System.IO.BinaryReader
    {
        private bool[] curByte = new bool[8];
        private byte curBitIndx = 0;
        private BitArray ba;

        public BinaryReader(Stream s) : base(s)
        {
            ba = new BitArray(new byte[] { base.ReadByte() });
            ba.CopyTo(curByte, 0);
            ba = null;
        }

        public override byte ReadByte()
        {
            bool[] bar = new bool[8];
            byte i;
            for (i = 0; i < 8; i++)
            {
                bar[i] = this.ReadBoolean();
            }
      
            byte b = 0;
            byte bitIndex = 0;
            for (i = 0; i < 8; i++)
            {
                if (bar[i])
                {
                    b |= (byte)(((byte)1) << bitIndex);
                }
                bitIndex++;
            }
            return b;
        }

        public override bool ReadBoolean()
        {
            if (curBitIndx == 8)
            {
                ba = new BitArray(new byte[] { base.ReadByte() });
                ba.CopyTo(curByte, 0);
                ba = null;
                this.curBitIndx = 0;
            }

            bool b = curByte[curBitIndx];
            curBitIndx++;
            return b;
        }

        public uint ReadUintBits(uint numOfBits)
        {
            uint num = 0;
            for (int i = 0; i < numOfBits; i++)
            {
                num <<= 1;
                bool bit = ReadBoolean();
                if (bit) num |= 1;
            }
            return num;
        }

    }

    internal class Node<Value>
    {
        public char c;                        // character
        public Node<Value> left, mid, right;  // left, middle, and right subtries
        public Value val;                     // value associated with string
    }

    internal class TST<Value>
    {
        private int n;              // size
        private Node<Value> root;   // root of TST


        public TST()
        {
        }

        public int size()
        {
            return n;
        }

        public String longestPrefixOf(String query)
        { 
            int length = 0;
            Node<Value> x = root;
            int i = 0;
            while (x != null && i < query.Length)
            {
                char c = query[i];
                if (c < x.c) x = x.left;
                else if (c > x.c) x = x.right;
                else
                {
                    i++;
                    if (x.val != null) length = i;
                    x = x.mid;
                }
            }
            return query.Substring(0, length);
        }

        public String longestPrefixOf(String query, int startIndex)
        {
          
            int length = 0;
            Node<Value> x = root;
            int i = startIndex;
            while (x != null && i < query.Length)
            {
                char c = query[i];
              
                if (c < x.c) x = x.left;
                else if (c > x.c) x = x.right;
                else
                {
                    i++;
                    if (x.val != null) length = i - startIndex;
                    x = x.mid;
                }
            }
            return query.Substring(startIndex, length);
        }

        public void put(String key, Value val)
        {
            if (!contains(key)) n++;
            else if (val == null) n--;       // delete existing key
            root = put(root, key, val, 0);
        }

        private Node<Value> put(Node<Value> x, String key, Value val, int d)
        {
            char c = key[d];
            if (x == null)
            {
                x = new Node<Value>();
                x.c = c;
            }
            if (c < x.c) x.left = put(x.left, key, val, d);
            else if (c > x.c) x.right = put(x.right, key, val, d);
            else if (d < key.Length - 1) x.mid = put(x.mid, key, val, d + 1);
            else x.val = val;
            return x;
        }

        public bool contains(String key)
        {
            return get(key) != null;
        }

        public Value get(String key)
        {  
            Node<Value> x = get(root, key, 0);
            if (x == null) return default(Value);
            return x.val;
        }

       
        private Node<Value> get(Node<Value> x, String key, int d)
        {
            if (x == null) return null;

            char c = key[d];
            if (c < x.c) return get(x.left, key, d);
            else if (c > x.c) return get(x.right, key, d);
            else if (d < key.Length - 1) return get(x.mid, key, d + 1);
            else return x;
        }
    }
}
