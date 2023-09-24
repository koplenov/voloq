using Networking;
using UnityEngine;

public class RuntimeContext : Singleton<RuntimeContext>
{
    public CardShoot сardShoot;

    protected override void Init()
    {
        сardShoot = FindObjectOfType<CardShoot>();
    }
    
    public void CastSpell(CastSpellData castSpellData)
    {
        var newCard = сardShoot.CreateShootCard();
        newCard.transform.position = castSpellData.Position;
        newCard.Shoot(castSpellData.Direction);
    }
}
