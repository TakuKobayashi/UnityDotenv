using UnityEngine;

public class EnvPreloader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoadRuntimeMethod()
    {
        Debug.Log("Before first Scene loaded");
    }
}
