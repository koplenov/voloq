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
    [SerializeField] private Transform spawnPoint;
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Card newCard = CreateShootCard();
            newCard.transform.forward = spawnPoint.transform.forward;
            newCard.Shoot(camera.transform.forward);
            GameUtils.SendCastSpell(Client.nick,"spell spell", camera.transform.forward, newCard.transform.position);
            handsCards.ReloadAnimation();
        }
    }

    public Card CreateShootCard()
    {
        return Instantiate(CardsBundle.Instance.GetRandomCard(), spawnPoint.position, Quaternion.identity);
    }
    
    public Card CreateShootCard(Card _prefab)
    {
        return Instantiate(_prefab, spawnPoint.position, Quaternion.identity);
    }
    
    private Vector3 GetCardEndPoint()
    {
        return Vector3.zero;
    }
}
