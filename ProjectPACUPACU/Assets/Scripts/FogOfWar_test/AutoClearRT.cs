using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Camera))]
public class AutoClearRT : MonoBehaviour
{
    public bool noClearAfterStart = false;

    // Use this for initialization
    void Start()
    {
        GetComponent<Camera>().clearFlags = CameraClearFlags.Color;
    }

    private void OnPostRender()
    {
        if (!noClearAfterStart)
            GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
    }
}
