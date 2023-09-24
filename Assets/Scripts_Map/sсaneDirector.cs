using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class sсaneDirector : MonoBehaviour
{
    public GameObject[] arrayExample = new GameObject[5];
    public Transform[] borderScane = new Transform[4];
    public int coolDown = 1;
    public float sizeYNumber = 10;
    private int[] poolNumber = { 0, 90, 180, 270 };
    public int countStartNumber = 0;
    // Start is called before the first frame update
    void Start()
    { 
        for(int i = 0; i < countStartNumber; i++) 
        {
            SpawnNewFigure();
        }
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    IEnumerator SpawnTimer() 
    {

        while (true)
        {;
            yield return new WaitForSeconds(coolDown);
            SpawnNewFigure();
        }
    }

    void SpawnNewFigure()
    {
        GameObject newFigure = Instantiate(arrayExample[Random.Range(0, arrayExample.Length)]);
        newFigure.transform.SetPositionAndRotation(new Vector3(Random.Range(borderScane[0].position.x, borderScane[2].position.x),
            sizeYNumber,
            Random.Range(borderScane[1].position.z , borderScane[0].position.z)),
            new Quaternion(0,0,0,0
            ));
        newFigure.transform.Rotate(poolNumber[Random.Range(0, 4)], poolNumber[Random.Range(0, 4)], poolNumber[Random.Range(0, 4)]);

    }

}
