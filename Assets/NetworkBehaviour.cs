using System;
using Networking;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

public class NetworkBehaviour : MonoBehaviour
{
    public string guid;

    private void Start()
    {
        Client.Instance.SyncObjects[guid] = this;
    }

    public void UpdateTransform(SyncTransformData syncTransformData)
    {
        transform.position = Vector3.Slerp(transform.position, syncTransformData.Position, Time.fixedDeltaTime * 8);
        transform.rotation = Quaternion.Euler(syncTransformData.Rotation);
    }
}

#if UNITY_EDITOR
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
#endif
