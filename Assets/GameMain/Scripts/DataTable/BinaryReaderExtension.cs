//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Project
{
    public static class BinaryReaderExtension
    {
        public static Color32 ReadColor32(this BinaryReader binaryReader)
        {
            return new Color32(binaryReader.ReadByte(), binaryReader.ReadByte(), binaryReader.ReadByte(), binaryReader.ReadByte());
        }

        public static Color ReadColor(this BinaryReader binaryReader)
        {
            return new Color(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static DateTime ReadDateTime(this BinaryReader binaryReader)
        {
            return new DateTime(binaryReader.ReadInt64());
        }

        public static Quaternion ReadQuaternion(this BinaryReader binaryReader)
        {
            return new Quaternion(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static Rect ReadRect(this BinaryReader binaryReader)
        {
            return new Rect(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static Vector2 ReadVector2(this BinaryReader binaryReader)
        {
            return new Vector2(binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static Vector3 ReadVector3(this BinaryReader binaryReader)
        {
            return new Vector3(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static Vector4 ReadVector4(this BinaryReader binaryReader)
        {
            return new Vector4(binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle(), binaryReader.ReadSingle());
        }

        public static List<T> ReadList<T>(this BinaryReader binaryReader, Func<T> parse)
        {
            List<T> valueList = new List<T>();

            int count = binaryReader.ReadInt32();

            for (int i = 0; i < count; i++) {

                valueList.Add(parse());
            }

            return valueList;


        }

        public static Goods ReadGoods(this BinaryReader binaryReader)
        {
            return new Goods(binaryReader.ReadInt32(), binaryReader.ReadInt32(), binaryReader.ReadInt32());
        }

        //public static List<T> ReadEnumList<T>(this BinaryReader binaryReader) where T: Enum
        //{

        //    List<int> valueList = new List<int>();

        //    int count = binaryReader.ReadInt32();

        //    for (int i = 0; i < count; i++)
        //    {

        //        valueList.Add(binaryReader.ReadInt32());
        //    }

        //    return (List<T>)valueList;

        //}


        public static T ReadEnum<T>(this BinaryReader binaryReader) where T : Enum
        {
            //T enumInstance;
            //Enum.TryParse<T>(binaryReader.ReadInt32() + "", out enumInstance);

            //return enumInstance;

            return (T)Enum.Parse(typeof(T), binaryReader.ReadInt32() + "");
        }


    }

}
