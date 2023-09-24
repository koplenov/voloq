using Networking;
using UnityEngine;

public class RuntimeContext : Singleton<RuntimeContext>
{
    public CardShoot сardShoot;
    [SerializeField] private Card enemyCard;

    protected override void Init()
    {
        сardShoot = FindObjectOfType<CardShoot>();
    }
    
    public void CastSpell(CastSpellData castSpellData)
    {
        var newCard = сardShoot.CreateShootCard(enemyCard);
        newCard.transform.position = castSpellData.Position;
        newCard.Shoot(castSpellData.Direction);
    }
}
