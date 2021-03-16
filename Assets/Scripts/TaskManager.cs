using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [Serializable]
    public class Task
    {
        public Collider Target;
        public string text;
        public bool Horizontal;
    }

    [SerializeField] List<Task> tasks;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
