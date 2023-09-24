using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class TaranSpell : Spell
{
    [SerializeField] private GameObject skin;
    [SerializeField] private float speed;
    [SerializeField] private float delay;
    
    private GameObject activeTaran;
    
    public override void Cost()
    {
        activeTaran.transform.DOMove(activeTaran.transform.forward * 15, speed).SetSpeedBased().SetDelay(delay).OnComplete(()=>{Destroy(this.gameObject);});
    }

    private GameObject CreateTaranObject(Vector3 spawnPosition)
    {
        return Instantiate(skin, spawnPosition, quaternion.Euler(0, Random.Range(0,360f), 0));
    }
    
    public void SetSpawnPosition(Vector3 pos)
    {
        activeTaran = CreateTaranObject(pos);
    }

}
