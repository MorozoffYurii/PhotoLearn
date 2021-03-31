using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public bool Horizontal;
    public Vector3 TestAngle;
    public bool CorrectPhoto;
    public Camera Camera;
    public Collider SearchedObj;
    [SerializeField] LineRenderer line;
    public static CameraScript cameraScript;
    // Start is called before the first frame update
    void Start()
    {
        cameraScript = this;
        line.enabled = false;
        line.startColor = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0,transform.position);
        if (CheckAxis())
        {
            if (CheckObj())
            {
                line.startColor = Color.green;
                line.endColor = Color.green;
                CorrectPhoto = true;
            }
            else
            {
                line.startColor = Color.red;
                line.endColor = Color.red;
                CorrectPhoto = false;
            }
            line.enabled = true;

        }
        else
        {
            line.enabled = false;
            CorrectPhoto = false;
        }

    }

    bool CheckAxis()
    {
        Vector3 angle = transform.eulerAngles;
        TestAngle = angle;
        if (Horizontal)
        {
            if (angle.x <= 10 || angle.x >= 350)
                return true;
            else
                return false;
        }
        else
        {
            if ((angle.x >= 80 && angle.x <= 100) || (angle.x >= 260 && angle.x <= 280))
                return true;
            else
                return false;
        }        
    }

    bool CheckObj()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.right);
        Physics.Raycast(ray, out hit);

        if (hit.collider != null)
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            line.SetPosition(1, hit.point);
            

            if (SearchedObj == hit.collider)
                return true;
            else
                return false;
            
        }
        else
        {
            line.SetPosition(1, transform.right * 10 + transform.position);

            return false;
        }
    }
}
