using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace UnityDotenv
{
    public class DotenvSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(Application.streamingAssetsPath + "/.env");
            IEnumerable<KeyValuePair<string, string>> envValuePaur = Env.Load(Application.streamingAssetsPath + "/.env");
            foreach (KeyValuePair<string, string> kvp in envValuePaur)
            {
                Debug.Log(kvp.Key + ":" + kvp.Value);
            }

            var environmentVariables = Environment.GetEnvironmentVariables();
            Debug.Log(environmentVariables);
            foreach (DictionaryEntry de in environmentVariables)
            {
                Debug.Log(de.Key + ":" + de.Value);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
