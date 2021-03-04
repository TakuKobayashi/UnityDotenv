using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Collections.Generic;


namespace UnityDotenv
{
    public class DotenvConfigWindow : EditorWindow
    {
        private Vector2 scrollPos = Vector2.zero;
        private bool foldoutEnvDataSettings = true;
        private bool isPreloadDotenv = true;
        private Dictionary<string, string> envValuPair = new Dictionary<string, string>();
        private string dotenvFilePath = ".env";

        void OnEnable()
        {
            envValuPair = Env.Load(EnvPreloader.EnvFilePath).ToDictionary();
        }

        [MenuItem("Tools/Dotenv Config")]
        static void Open()
        {
            EditorWindow.GetWindow<DotenvConfigWindow>("Dotenv Config");
        }

        // Windowのクライアント領域のGUI処理を記述
        void OnGUI()
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(".env file path");
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(Application.streamingAssetsPath);
            string newDotenvFilePath = EditorGUILayout.TextField(dotenvFilePath);
            if(dotenvFilePath != newDotenvFilePath)
            {
                dotenvFilePath = newDotenvFilePath;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("preload .env file.");
            isPreloadDotenv = EditorGUILayout.Toggle(isPreloadDotenv);
            EditorGUILayout.EndHorizontal();

            WithInFoldoutBlock(".env data params", ref foldoutEnvDataSettings, () =>
            {
                EditorGUILayout.BeginHorizontal();
                for(int i = 0;i < 5; ++i)
                {
                    EditorGUILayout.Space();
                }
                if (GUILayout.Button("+"))
                {
                    if (!envValuPair.ContainsKey(""))
                    {
                        envValuPair.Add("", "");
                    }
                }
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Key Name");
                EditorGUILayout.LabelField("Value");
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.Space();
                foreach (var kv in envValuPair)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.TextField(kv.Key);
                    EditorGUILayout.TextField(kv.Value);
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space();
                }
                if (GUILayout.Button("Save"))
                {
                }
            });

            EditorGUILayout.EndScrollView();
        }

        private void WithInFoldoutBlock(string title, ref bool foldout, Action callback)
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