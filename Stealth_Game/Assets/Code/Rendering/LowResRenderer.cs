using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowResRenderer : MonoBehaviour
{

    public Camera[] allCameras;
    private RenderTexture[] allRendTexs;
    private int yRes = 200;


    // Start is called before the first frame update
    void Start()
    {
        SetupRenderTextures();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), allRendTexs[0], ScaleMode.StretchToFill);
    }

    void SetupRenderTextures()
    {
        allRendTexs = new RenderTexture[allCameras.Length];
        //
        int ratio = Screen.height / yRes;
        int newScreenWidth = Screen.width / ratio;
        int newScreenHeight = Screen.height / ratio;
        //
        for (int i = 0; i < allRendTexs.Length; i++)
        {
            allRendTexs[i] = new RenderTexture(newScreenWidth, newScreenHeight, 0, RenderTextureFormat.ARGB32);

            allRendTexs[i].antiAliasing = 1;
            allRendTexs[i].filterMode = FilterMode.Point;
            allRendTexs[i].isPowerOfTwo = false;
            //
            allCameras[i].targetTexture = allRendTexs[i];

        }
    }


}
