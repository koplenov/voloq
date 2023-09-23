using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CardsType
{
    Buff,
    Debuff,
    Spell,
    Action
}
public class CardShoot : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private HandsCards handsCards;
    [SerializeField] private Mana mana;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
        }
    }

    private Vector3 GetCardEndPoint()
    {
        
    }
}
