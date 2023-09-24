using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class HealCard : Card
{
    [SerializeField] private int addHealth = 35;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NetPlayer"))
        {
            NetPlayerData netData = other.GetComponent<NetPlayerData>();
            GameUtils.SendDamage(Client.nick,netData.nick,(cardData.damage));
            netData.botState.ApplyDamage(cardData.damage);
        }
        GameUtils.SendDamage(Client.nick,Client.nick,-addHealth);
        Destroy(this.gameObject);
    }
}
