using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityDotenv
{
    public class DotenvSample : MonoBehaviour
    {
        [SerializeField] private Text valueText;

        // Start is called before the first frame update
        void Start()
        {
            valueText.text = Environment.GetEnvironmentVariable("PASSWORD");
        }
    }
}
