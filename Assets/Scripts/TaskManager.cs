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
        public List<GameObject> Barriers = new List<GameObject>();
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
        if (index == tasks.Count - 1)
        {
            textMesh.text = "Все задания завершены!";
        }
        else
        {
            if (tasks[index].NextPos)
                ChangePoses.changePoses.NextPos(tasks[index].NextPos);
            BarrierActivation(tasks[index], false);
            index++;
            BarrierActivation(tasks[index], true);
            SetCameraTask();      
        }       
        
    }

    void BarrierActivation(Task task, bool enabled)
    {
        if (task.Barriers.Count != 0)
            foreach (GameObject barrier in task.Barriers)
            {
                barrier.SetActive(enabled);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
