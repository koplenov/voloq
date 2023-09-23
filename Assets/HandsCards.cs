using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsCards : MonoBehaviour
{
    [SerializeField] private Mana mana;
    [SerializeField] private int maxHand = 5;
    [SerializeField] private List<Card> deka = new List<Card>();
    

    public bool AddCard(Card card)
    {
        if (deka.Count < maxHand)
        {
            deka.Add(card);
            return true;
        }
        return false;
    }

    public void UseCard(Card card)
    {
        if (deka.Contains(card))
        {
            
        }
    }
    
    public void RemoveCard(Card card)
    {
        if (deka.Contains(card))
        {
            deka.Remove(card);
        }
        else
        {
            Debug.LogError("Такой карты нет в деке");
        }
    }
    
}
