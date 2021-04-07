using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public static TaskManager taskManager;
    [SerializeField] TextMeshPro textMesh;
    [Serializable]
    public class Task
    {
        public Collider Target;
        public string text;
        public bool Horizontal;
        public GameObject NextPos;
    }

    [SerializeField] List<Task> tasks;
    int index;


    // Start is called before the first frame update
    void Start()
    {
        taskManager = this;
        index = 0;
        SetCameraTask();
    }

    void SetCameraTask()
    {
        CameraScript.cameraScript.Horizontal = tasks[index].Horizontal;
        CameraScript.cameraScript.SearchedObj = tasks[index].Target;
        textMesh.text = tasks[index].text;
    }

    public void NextTask()
    {
        
        if (tasks[index].NextPos)
            ChangePoses.changePoses.NextPos(tasks[index].NextPos);
        index++;
        if (index == tasks.Count)
        {
            textMesh.text = "Все задания завершены!";
        }
        else
        {            
            SetCameraTask();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
