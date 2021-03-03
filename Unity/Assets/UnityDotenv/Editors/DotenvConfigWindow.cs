using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;


namespace UnityDotenv
{
    public class DotenvConfigWindow : EditorWindow
    {
        void OnEnable()
        {
        }

        [MenuItem("Tools/Dotenv Config")]
        static void Open()
        {
            EditorWindow.GetWindow<DotenvConfigWindow>("Dotenv Config");
        }

        // Windowのクライアント領域のGUI処理を記述
        void OnGUI()
        {
        }

        void WithInFoldoutBlock(string title, ref bool foldout, Action callback)
        {
            EditorGUI.indentLevel = 0;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            foldout = EditorGUILayout.Foldout(foldout, title);
            if (foldout)
            {
                EditorGUI.indentLevel = 1;
                EditorGUILayout.Space();
                callback();
                EditorGUILayout.Space();
            }
            EditorGUILayout.EndVertical();
            EditorGUILayout.Space();
        }
    }
}