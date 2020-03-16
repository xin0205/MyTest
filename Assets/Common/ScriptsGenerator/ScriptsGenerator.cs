using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public static class ScriptsGenerator
{
    private static string m_ScriptTemplateFile = "";
    private static string m_ScriptTemplate = "";
    private static string m_OutputFile = "";
    private static Encoding m_Encoding;

    private static Dictionary<string, string> m_CodeReplacementDict = new Dictionary<string, string>();

    public static void GenerateScript(string templateFile, string outputFile, Dictionary<string, string> codeReplaceDict, Encoding encoding) {

        m_ScriptTemplateFile = templateFile;
        m_OutputFile = outputFile;
        m_CodeReplacementDict = codeReplaceDict;
        m_Encoding = encoding;

        m_ScriptTemplate = File.ReadAllText(templateFile, Encoding.UTF8);

        GenerateScriptFile();

    }

    private static void ReplaceCode(ref StringBuilder codeContent)
    {
        foreach (KeyValuePair<string, string> codeReplace in m_CodeReplacementDict) {
            codeContent.Replace(codeReplace.Key, codeReplace.Value);
        }
    }

    private static void GenerateScriptFile() {

        StringBuilder codeContent = new StringBuilder(m_ScriptTemplate);

        ReplaceCode(ref codeContent);

        using (FileStream fileStream = new FileStream(m_OutputFile, FileMode.Create))
        {
            using (StreamWriter stream = new StreamWriter(fileStream, m_Encoding))
            {
                stream.Write(codeContent.ToString());
            }
        }

        AssetDatabase.ImportAsset(m_OutputFile);
        AssetDatabase.Refresh();

    }

    public static List<string> ReadTxtFileByRow(string fileName)
    {
        List<string> rowList = new List<string>();

        StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
        string line;
        while ((line = sr.ReadLine()) != null)
        {   
            rowList.Add(line);
        }

        sr.Close();


        return rowList;

    }
}
