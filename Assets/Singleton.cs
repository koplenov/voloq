using UnityEngine;

public abstract class Singleton<T>: MonoBehaviour where T : class
{ 
    public static T Instance { get; private set; }
    protected void Awake() { Instance = this as T; Init(); }
    protected virtual void Init(){}
}