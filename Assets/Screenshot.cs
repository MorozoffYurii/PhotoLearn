using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Screenshot : MonoBehaviour
{
    private static Screenshot instance;
    Camera myCamera;
    public GameObject Photo;
    public float printTime;
    bool printing;
    [SerializeField] SteamVR_Action_Boolean TakeShot;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        myCamera = GetComponent<Camera>();
        printing = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NewPaper()
    {

    }

    void TakeScreenshot(int width, int heigh)
    {
        if (!printing)
        {
            //Creating Screenshot
            RenderTexture.active = myCamera.targetTexture;

            Texture2D _tex2D = new Texture2D(RenderTexture.active.width, RenderTexture.active.height);
            Rect rect = new Rect(0, 0, RenderTexture.active.width, RenderTexture.active.height);

            _tex2D.ReadPixels(rect, 0, 0);
            _tex2D.Apply(false);

            Sprite sprite = Sprite.Create(_tex2D, rect, Vector3.zero);

            //image.sprite = sprite;

            //Creating photo
            GameObject photo = Instantiate(Photo, Photo.transform.position, Photo.transform.rotation);
            photo.SetActive(true);
            photo.GetComponent<PhotoInfo>().image.sprite = sprite;
            photo.LeanMoveX(2.75f, printTime);
            printing = true;
            StartCoroutine(resumePrinting(photo.GetComponent<Rigidbody>()));
        }        
    }

    IEnumerator resumePrinting(Rigidbody rigidbody)
    {
        yield return new WaitForSeconds(printTime);
        rigidbody.isKinematic = false;
        printing = false;
    }

    public static void TakeScreenshot_Static(int width, int heigh)
    {
        instance.TakeScreenshot(width, heigh);
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Screenshot.TakeScreenshot_Static(300, 200);
        }*/
    }

    public void OnGrab()
    {
        if (TakeShot.stateDown)
        {
            Screenshot.TakeScreenshot_Static(300, 200);
            if (CameraScript.cameraScript.CorrectPhoto)
                TaskManager.taskManager.NextTask();
        }
    }
}

