using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePoses : MonoBehaviour
{
    public static ChangePoses changePoses;
    [SerializeField] List<GameObject> Poses;
    int i = 0;
    // Start is called before the first frame update
    private void Start()
    {
        changePoses = this;
    }
    public void NextPos()
    {
        Poses[i].SetActive(false);
        i++;
        if (i == Poses.Count)
            i = 0;
        Poses[i].SetActive(true);
    }

    public void NextPos(GameObject Pos)
    {
        Poses[i].SetActive(false);
        i = Poses.IndexOf(Pos);
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
