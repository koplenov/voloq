using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PulseWaweSpell : Spell
{
    [SerializeField] private GameObject sphere;
    
    [SerializeField] private float radius;
    [SerializeField] private float waweDiraction;
    [SerializeField] private int countWawe;
    
    public override void Cost()
    {
        sphere.transform.DOScale(Vector3.one * radius, waweDiraction).SetLoops(countWawe);
    }
}
