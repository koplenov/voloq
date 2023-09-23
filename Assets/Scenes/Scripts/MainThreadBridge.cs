using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainThreadBridge : MonoBehaviour
{
    public static MainThreadBridge Instance;
    void Awake()
    {
        Instance = this;
    }

    void FixedUpdate()
    {
        while (eventsToRaise.Any())
        {
            eventsToRaise.Dequeue().Invoke();
        }
    }

    Queue<Action> eventsToRaise = new Queue<Action>();
    
    public static void DoInMainThread(Action action)
    {
        lock (Instance.eventsToRaise)
        {
            Instance.eventsToRaise.Enqueue(action);  
        }
    }
}