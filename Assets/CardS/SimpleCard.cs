using System.Collections;
using UnityEngine;

public class SimpleCard : Card
{
    public override void Spell()
    {
     base.Spell();
     Debug.Log("Ебануло нихуево");
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
