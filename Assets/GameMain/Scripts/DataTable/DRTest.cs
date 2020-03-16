//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------
// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2020-03-15 20:20:13.763
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace Project
{
    /// <summary>
    /// 测试表格生成。
    /// </summary>
    public class DRTest : DataRowBase
    {
        private int m_Id = 0;

        /// <summary>
        /// 获取编号。
        /// </summary>
        public override int Id
        {
            get
            {
                return m_Id;
            }
        }

        /// <summary>
        /// 获取Int值。
        /// </summary>
        public int IntValue
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取int数组。
        /// </summary>
        public List<int> IntList
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取Vector2。
        /// </summary>
        public Vector2 Vector2Value
        {
            get;
            private set;
        }

        /// <summary>
        /// 获取Vector2数组。
        /// </summary>
        public List<Vector2> Vector2List
        {
            get;
            private set;
        }

        public override bool ParseDataRow(GameFrameworkSegment<string> dataRowSegment)
        {
            // Star Force 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
            string[] columnTexts = dataRowSegment.Source.Substring(dataRowSegment.Offset, dataRowSegment.Length).Split(DataTableExtension.DataSplitSeparators);
            for (int i = 0; i < columnTexts.Length; i++)
            {
                columnTexts[i] = columnTexts[i].Trim(DataTableExtension.DataTrimSeparators);
            }

            int index = 0;
            index++;
            m_Id = int.Parse(columnTexts[index++]);
            index++;
            IntValue = int.Parse(columnTexts[index++]);
            IntList = DataTableExtension.ParseList<int>(columnTexts[index++], int.Parse);
            Vector2Value = DataTableExtension.ParseVector2(columnTexts[index++]);
            Vector2List = DataTableExtension.ParseList<Vector2>(columnTexts[index++], DataTableExtension.ParseVector2);

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(GameFrameworkSegment<byte[]> dataRowSegment)
        {
            // Star Force 示例代码，正式项目使用时请调整此处的生成代码，以处理 GCAlloc 问题！
            using (MemoryStream memoryStream = new MemoryStream(dataRowSegment.Source, dataRowSegment.Offset, dataRowSegment.Length, false))
            {
                using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
                {
                    m_Id = binaryReader.ReadInt32();
                    IntValue = binaryReader.ReadInt32();
                    IntList = binaryReader.ReadList<int>(binaryReader.ReadInt32);
                    Vector2Value = binaryReader.ReadVector2();
                    Vector2List = binaryReader.ReadList<Vector2>(binaryReader.ReadVector2);
                }
            }

            GeneratePropertyArray();
            return true;
        }

        public override bool ParseDataRow(GameFrameworkSegment<Stream> dataRowSegment)
        {
            Log.Warning("Not implemented ParseDataRow(GameFrameworkSegment<Stream>)");
            return false;
        }

        private void GeneratePropertyArray()
        {

        }
    }
}
