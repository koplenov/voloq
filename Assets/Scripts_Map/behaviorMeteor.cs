using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorMeteor : MonoBehaviour
{
    public GameObject selfObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(selfObject);
    }
}
