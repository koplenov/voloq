using System;
using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class GeneratorScene : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector2 sizeMap;
    public int sizeChank =5;
    public GameObject[] prefabChanks = new GameObject[6];
    public int jumpForce = 1000;
    public GameObject platform;
    private GameObject[][] intMap;
    public GameObject spawner;
    //public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        int iSize = System.Convert.ToInt32(sizeMap.x / (5 * sizeChank));
        int jSize = System.Convert.ToInt32(sizeMap.y / (5 * sizeChank));

        intMap = new GameObject[iSize][];

        for (int i = 0; i < iSize; i++)
            intMap[i] = new GameObject[jSize];
        StartCoroutine(SpawnTimer());

        SpawnFloat();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTimer()
    {

        while (true)
        {
            yield return new WaitForSeconds(3);
            
            StartCoroutine(SwapPlatform());
        }
    }

    void SpawnFloat()
    {

        for (int i = 0; i < intMap.Length; i++)
        {
            for (int j = 0; j < intMap[i].Length; j++)
            {

                int randomNum = UnityEngine.Random.Range(0, prefabChanks.Length);
                intMap[i][j] = ConstructorChank();//Instantiate(prefabChanks[randomNum]);
                intMap[i][j].transform.position = new Vector3(i * 5 * sizeChank - sizeMap.x / 2, startPosition.y, j * sizeChank * 5 - sizeMap.y / 2);
                intMap[i][j].transform.Rotate(intMap[i][j].transform.rotation.x, UnityEngine.Random.Range(0, 3) * 90, intMap[i][j].transform.rotation.z);
                intMap[i][j].transform.localScale *= sizeChank;

            }
        }

        GameObject firstSpawn = Instantiate(spawner);
        firstSpawn.transform.position = new Vector3(0,startPosition.y + spawner.transform.lossyScale.y + sizeChank, -1 * sizeChank * 5 - sizeMap.y / 2);
        firstSpawn.transform.localScale *= sizeChank;
        GameObject secondSpawn = Instantiate(spawner);
        secondSpawn.transform.position = new Vector3(0, startPosition.y + spawner.transform.lossyScale.y + sizeChank, intMap[0].Length * sizeChank * 5 - sizeMap.y / 2);
        secondSpawn.transform.localScale *= sizeChank;
    }

    IEnumerator SwapPlatform()
    {
        int firstPlatformPositionX = UnityEngine.Random.Range(0, intMap.Length);
        int firstPlatformPositionZ = UnityEngine.Random.Range(0, intMap[0].Length);
        int symmetryPlatformPositionX = UnityEngine.Random.Range(0, intMap.Length); //intMap.Length - firstPlatformPositionX-1;
        int symmetryPlatformPositionZ = UnityEngine.Random.Range(0, intMap[0].Length);  //intMap[0].Length - firstPlatformPositionZ-1;

        GameObject FirstObj = intMap[firstPlatformPositionX][firstPlatformPositionZ];
        GameObject SecondObj = intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ];

        //GameObject slotEffectFirst = Instantiate(particle);
        //GameObject slotEffectSecond = Instantiate(particle);

       

         yield return new WaitForSeconds(2);


        if (intMap[firstPlatformPositionX][firstPlatformPositionZ] != null && intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ] != null)
        {
            //GameObject particleFirst = Instantiate(particle);
            //GameObject particleSecond = Instantiate(particle);

            

            Vector3 buffer = new Vector3(0,0,180);

            intMap[firstPlatformPositionX][firstPlatformPositionZ].transform.DORotate(buffer, 3f);
            intMap[firstPlatformPositionX][firstPlatformPositionZ].transform.DOJump(intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ].transform.position, jumpForce, 1, 3f);
            //intMap[firstPlatformPositionX][firstPlatformPositionZ].transform.DOMove(intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ].transform.position, 2f);

            intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ].transform.DORotate(buffer, 3f);
            intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ].transform.DOJump(intMap[firstPlatformPositionX][firstPlatformPositionZ].transform.position, jumpForce, 1, 3f);
            //intMap[symmetryPlatformPositionX][symmetryPlatformPositionZ].transform.DOMove(intMap[firstPlatformPositionX][firstPlatformPositionZ].transform.position, 2f);
      
        }



    }

    GameObject ConstructorChank()
    {
        GameObject result = Instantiate(platform);
        result.transform.position = new Vector3(0, 0, 0);

        GameObject UpPart = Instantiate(prefabChanks[UnityEngine.Random.Range(0, prefabChanks.Length)]);
        UpPart.transform.position = new Vector3(0, 1, 0);
        UpPart.transform.Rotate(0, UnityEngine.Random.Range(0, 3) * 90, 0);
        UpPart.transform.SetParent(result.transform);

        GameObject DownPart = Instantiate(prefabChanks[UnityEngine.Random.Range(0, prefabChanks.Length)]);
        DownPart.transform.position = new Vector3(0, -1, 0);
        DownPart.transform.Rotate(0, UnityEngine.Random.Range(0,3) * 90, 180);
        DownPart.transform.SetParent(result.transform);

        return result;
    }
}
        //for (int i = 0; i < intMap.Length; i++)
        //{
        //    for (int j = 0; j < intMap[i].Length; j++)
        //    {
        //        if (intMap[i][j].tag == "WallBlock")
        //        {
        //            for(int k = -1; k < 2; k++)
        //            {
        //                for(int l = -1; l < 2; l++)
        //                {
        //                    if (k == 0 && l == 0)
        //                        continue;
        //                    if((k + i >= 0 && k + i < intMap.Length) && (l + j >= 0 && j + l < intMap[i].Length))
        //                    {
        //                        if(Math.Sign(k)  != 0 && Math.Sign(l) != 0)
        //                        {
        //                            Destroy(intMap[k + i][l + j]);
        //                            intMap[k + i][l + j] = Instantiate(ladderCorner);
        //                            intMap[k + i][l + j].transform.position = new Vector3((i + k) * 5 - sizeX / 2, 3, (j + l) * 5 - sizeY / 2);
        //                        }
        //                        else
        //                        {
        //                            Destroy(intMap[k + i][l + j]);
        //                            intMap[k + i][l + j] = Instantiate(ladder);
        //                            intMap[k + i][l + j].transform.position = new Vector3((i + k) * 5 - sizeX / 2, 3, (j + l) * 5 - sizeY / 2);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }

