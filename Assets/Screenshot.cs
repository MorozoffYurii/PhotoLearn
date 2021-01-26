using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screenshot : MonoBehaviour
{
    private static Screenshot instance;
    public Image image;
    Camera myCamera;
    bool takeScreenshotOnNextFrame;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;

            RenderTexture.active = myCamera.targetTexture;

            Texture2D _tex2D = new Texture2D(RenderTexture.active.width, RenderTexture.active.height);
            Rect rect = new Rect(0, 0, RenderTexture.active.width, RenderTexture.active.height);

            _tex2D.ReadPixels(rect, 0, 0);
            _tex2D.Apply(false);

            Sprite sprite = Sprite.Create(_tex2D, rect, Vector3.zero);
            image.sprite = sprite;

            /*RenderTexture renderTexture = myCamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);
            renderResult.Apply();
            Sprite sprite = Sprite.Create(renderResult, rect, Vector3.zero);
            image.sprite = sprite;
            */
            //byte[] byteArray = renderResult.EncodeToPNG();
            //System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenhot.png", byteArray);
            //RenderTexture.ReleaseTemporary(renderTexture);
            //myCamera.targetTexture = null;
        }
    }

    void TakeScreenshot(int width, int heigh)
    {
        //myCamera.targetTexture = RenderTexture.GetTemporary(width, heigh, 16);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int heigh)
    {
        instance.TakeScreenshot(width, heigh);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Screenshot.TakeScreenshot_Static(300, 200);
        }
    }
}

