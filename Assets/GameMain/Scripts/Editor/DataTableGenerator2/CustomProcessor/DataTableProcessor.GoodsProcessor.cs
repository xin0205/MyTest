//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using Project;
using System.IO;
using UnityEngine;
using UnityGameFramework.Editor.DataTableTools2;
//using static UnityGameFramework.Editor.DataTableTools.DataTableProcessor;
using static UnityGameFramework.Editor.DataTableTools2.DataTableProcessor;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public sealed class GoodsProcessor : GenericDataProcessor<Goods>
    {
        public override string LanguageKeyword
        {
            get
            {
                return "Goods";
            }
        }

        public override DataType DataType
        {
            get
            {
                return DataType.Custom;
            }
        }

        public override Goods Parse(string value)
        {
            return Goods.Parse(value);
        }

        public override void WriteOneValueToStream(BinaryWriter stream, string value)
        {
            Goods goods = Parse(value);
            stream.Write((int)goods.Type);
            stream.Write(goods.ID);
            stream.Write(goods.Count);
        }
    }
    //public sealed partial class DataTableProcessor
    //{
        
    //}
}
