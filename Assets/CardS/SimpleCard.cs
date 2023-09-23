using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCard : Card
{
    public override void Spell()
    {
     base.Spell();
     Debug.Log("Ебануло нихуево");
    }
}
