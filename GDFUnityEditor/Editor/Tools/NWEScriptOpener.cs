using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GDFUnityEditor
{
    public class NWEScriptOpener : Editor
    {
        static public void OpenScript(Type tType)
        {
            string[] assetPaths = AssetDatabase.GetAllAssetPaths();
            string assetPathFinal = null;
            foreach (string assetPath in assetPaths)
            {
                if (assetPath.Contains(tType.Name)) // or .js if you want
                {
                    string tFileName = Path.GetFileName(assetPath);
                    string tExtension = Path.GetExtension(tFileName);
                    if (tExtension == ".cs")
                    {
                        if (tFileName == tType.Name + ".cs")
                        {
                            assetPathFinal = assetPath;
                            break;
                        }
                        else if (tFileName == tType.Name + "_Workflow.cs")
                        {
                            assetPathFinal = assetPath;
                        }
                        else
                        {
                            // do nothing
                        }
                    }
                }
            }

            if (string.IsNullOrEmpty(assetPathFinal) == false)
            {
                UnityEngine.Object tFile = AssetDatabase.LoadMainAssetAtPath(assetPathFinal);
                AssetDatabase.OpenAsset(tFile);
                EditorGUIUtility.PingObject(tFile);
                Selection.activeGameObject = tFile as GameObject;
            }
        }
    }
}
