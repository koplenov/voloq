using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBonus : MonoBehaviour
{
    private bool itHaveBonus = false;
    private float timeInSec = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator ExecuteAfterTime(float timeInSec)
    {
        yield return new WaitForSeconds(timeInSec);
        itHaveBonus = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        ExecuteAfterTime(timeInSec);
        if (itHaveBonus)
        {
            // TODO Collision

            itHaveBonus = false;
        }
    }
}
