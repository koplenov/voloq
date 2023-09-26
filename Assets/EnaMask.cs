using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnaMask : MonoBehaviour
{
    public GameObject mask;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            mask.SetActive(true);
        }
    }
}
