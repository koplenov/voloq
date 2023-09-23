using Networking;
using UnityEngine;

public class RuntimeContext : Singleton<RuntimeContext>
{
    public void CastSpell(CastSpellData castSpellData)
    {
        Debug.Log(castSpellData);
        Debug.Log(castSpellData.nick);
        Debug.Log(castSpellData.position);
        Debug.Log(castSpellData.direction);
    }
}
