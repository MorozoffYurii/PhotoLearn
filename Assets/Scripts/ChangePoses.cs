using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePoses : MonoBehaviour
{
    [SerializeField] List<GameObject> Poses;
    int i = 0;
    // Start is called before the first frame update
    
    public void NextPos()
    {
        Poses[i].SetActive(false);
        i++;
        if (i == Poses.Count)
            i = 0;
        Poses[i].SetActive(true);
    }

    public void PreviousPos()
    {
        Poses[i].SetActive(false);
        i--;
        if (i == -1)
            i = Poses.Count - 1;
        Poses[i].SetActive(true);
    }



}
