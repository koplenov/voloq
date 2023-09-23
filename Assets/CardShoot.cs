using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

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
    [SerializeField] private Card prefab;
    [SerializeField] private Transform spawnPoint;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Card newCard = CreateShootCard();
            newCard.transform.forward = spawnPoint.transform.forward;
            newCard.Shoot(camera.transform.forward);
        }
    }

    public Card CreateShootCard()
    {
        return Instantiate(prefab, spawnPoint.position, Quaternion.identity);
    }
    
    private Vector3 GetCardEndPoint()
    {
        return Vector3.zero;
    }
}
