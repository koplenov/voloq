using System;
using Networking;
using UnityEditor;
using UnityEngine;

public class NetworkBehaviour : MonoBehaviour
{
    public string guid;

    private void Start()
    {
        Client.Instance.SyncObjects[gameObject] = this;
    }

    public void UpdateTransform(SyncTransformData syncTransformData)
    {
        transform.position = syncTransformData.Position;
        transform.rotation = Quaternion.Euler(syncTransformData.Rotation);
    }
}

[CustomEditor(typeof(NetworkBehaviour))]
[CanEditMultipleObjects]
public class SyncPositionEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate guid"))
        {
            (serializedObject.targetObject as NetworkBehaviour).guid = Guid.NewGuid().ToString();
            serializedObject.ApplyModifiedProperties();
        }
        
        if (GUILayout.Button("Generate guid for all"))
        {
            foreach (var syncPosition in FindObjectsOfType<NetworkBehaviour>())
            {
                syncPosition.guid = Guid.NewGuid().ToString();
            }
        }
    }
}
