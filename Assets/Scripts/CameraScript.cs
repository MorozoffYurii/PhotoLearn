using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public bool Horizontal;
    public Vector3 TestAngle;
    public bool CorrectPhoto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 angle = transform.eulerAngles;
        TestAngle = angle;
        if (Horizontal)
        {
            if (angle.x <= 10 || angle.x >= 350)
                CorrectPhoto = true;
            else
                CorrectPhoto = false;
        }
        if (!Horizontal)
        {
            if ((angle.x >= 80 && angle.x <=100) || (angle.x >= 260 && angle.x <= 280))
                CorrectPhoto = true;
            else
                CorrectPhoto = false;
        }
    }
}
