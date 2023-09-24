using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class TaranCard : Card
{
    [SerializeField] private TaranSpell taran;
    
    public override void Spell() // при ображении на сервер напомнить добавить поле объект для вской помойки
    {
        GameUtils.SendCastSpell(Client.nick,cardData.cardId, Vector3.forward, transform.position);
        taran.SetSpawnPosition(transform.position);
        taran.Cost();
    }
}
