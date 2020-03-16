//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
using UnityGameFramework.Editor.DataTableTools2;

namespace StarForce.Editor.DataTableTools2
{
    public sealed class DataTableGeneratorMenu
    {
        private static string[] DataTableNames = new string[] {
            "Test",

        };

        [MenuItem("Star Force/Generate DataTables2")]
        private static void GenerateDataTables()
        {
            //bool a = new Regex(@"^s_(?<type>.+)$").IsMatch("s_int");

            //Debug.Log(a);

            //DataTableProcessor.DataProcessorUtility.Init();

            foreach (string dataTableName in DataTableNames)
            {
                DataTableProcessor dataTableProcessor = DataTableGenerator.CreateDataTableProcessor(dataTableName);
                if (!DataTableGenerator.CheckRawData(dataTableProcessor, dataTableName))
                {
                    Debug.LogError(Utility.Text.Format("Check raw data failure. DataTableName='{0}'", dataTableName));
                    break;
                }

                DataTableGenerator.GenerateDataFile(dataTableProcessor, dataTableName);
                DataTableGenerator.GenerateCodeFile(dataTableProcessor, dataTableName);
            }

            AssetDatabase.Refresh();
        }
    }
}
