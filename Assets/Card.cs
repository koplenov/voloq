using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [SerializeField] private CardData cardData;
    public abstract void Spell();

    public CardData GetCardData()
    {
        return cardData;
    }
}

public struct CardData
{
    public int manaCost;
    public string description;
    public string name;
    public Sprite image;
}
