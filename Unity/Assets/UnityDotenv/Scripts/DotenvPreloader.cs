using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

namespace UnityDotenv
{
    public class DotenvPreloader
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            IEnumerable<KeyValuePair<string, string>> envValuePaur = Env.Load(DotenvFile.FileFullPath);
#if UNITY_EDITOR
            foreach (KeyValuePair<string, string> kvp in envValuePaur)
            {
                Debug.Log(kvp.Key + ":" + kvp.Value);
            }
#endif
        }
    }
}
