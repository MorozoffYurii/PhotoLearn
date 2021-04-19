using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PinPhoto : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "photo")
        {
            PhotoInfo photo = other.gameObject.GetComponent<PhotoInfo>();
            if (!other.gameObject.GetComponent<Interactable>().attachedToHand && !photo.pinned)
            {                
                photo.pinned = true;
                photo.pins.SetActive(true);
                placePhoto(other.transform);
                FixedJoint joint = other.gameObject.AddComponent<FixedJoint>();
                joint.breakForce = 20;
                //StartCoroutine(placePhoto(other.transform));
            }
        }
    }

    //IEnumerator placePhoto(Transform photo)
    void placePhoto(Transform photo)
    {
        //yield return new WaitForSeconds(0.2f);
        Vector3 startPos = photo.position;
        Vector3 euler = photo.eulerAngles;

        photo.position = new Vector3(startPos.x, startPos.y, -14.8f);
        photo.eulerAngles = new Vector3(0, 180, euler.z);
        //photo.eulerAngles = new Vector3(0, 0, 0);

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "photo")
        {
            PhotoInfo photo = other.gameObject.GetComponent<PhotoInfo>();
            if (photo.pinned)
            {
                photo.pinned = false;
                photo.pins.SetActive(false);
            }
        }
    }
}
