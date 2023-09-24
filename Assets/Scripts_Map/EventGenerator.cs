using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 startPosition;
    public Vector2 sizeMap;
    public int timerEvent;
    public GameObject meteor;
    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(60);
            EventMeteorRain();
        }
    }


    void EventMeteorRain()
    {
        int countPushMeteor = 20;
        float angle = 45f;
        float speed = 5.0f;
        for (int i = 0; i < countPushMeteor; i++)
        {
            GameObject exampleMeteor = Instantiate(meteor);
            exampleMeteor.transform.position = new Vector3(Random.Range(startPosition.x - sizeMap.x, startPosition.x + sizeMap.x), 20, Random.Range(startPosition.y - sizeMap.y, startPosition.y + sizeMap.y));
            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            exampleMeteor.GetComponent<Rigidbody>().AddForce(direction * speed, ForceMode.VelocityChange);

        }
    }



}
