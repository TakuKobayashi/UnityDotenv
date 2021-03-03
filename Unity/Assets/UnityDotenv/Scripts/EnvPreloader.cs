using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDotenv
{
    public class EnvPreloader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            IEnumerable<KeyValuePair<string, string>> envValuePaur = Env.Load(EnvFilePath);
            foreach (KeyValuePair<string, string> kvp in envValuePaur)
            {
                Debug.Log(kvp.Key + ":" + kvp.Value);
            }
        }

        public static string EnvFilePath {
            get
            {
                return Path.Combine(Application.streamingAssetsPath, ".env");
            }
        }
    }
}
