using System.Collections;
using UnityEngine;
using Utils;

public class SimpleCard : Card
{
    public override void Spell()
    {
        GameUtils.SendCastSpell(Client.nick, cardData.cardId, Vector3.forward, transform.position);

    }
}
