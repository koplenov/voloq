using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandsCards : MonoBehaviour
{
    [SerializeField] private Mana mana; 
    [SerializeField] private int maxHand = 5;
    [SerializeField] private List<Card> deka = new List<Card>();
    [SerializeField] private CardHandView[] dekaCards;
    [SerializeField] private Transform[] dekaCardsPositionsActivate;
    [SerializeField] private Transform[] dekaCardsPositionsIdle;
    [SerializeField] private bool[] dekaCardsIsActive;
    [SerializeField] private Animator handsAnimator;

    private void Start()
    {
        dekaCardsIsActive = new bool[dekaCards.Length];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(dekaCardsIsActive[0])
                HideCardInHand(0);
            else
                SelectCardInHand(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(dekaCardsIsActive[1])
                HideCardInHand(1);
            else
                SelectCardInHand(1);
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(dekaCardsIsActive[2])
                HideCardInHand(2);
            else
                SelectCardInHand(2);
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if(dekaCardsIsActive[3])
                HideCardInHand(3);
            else
                SelectCardInHand(3);
        }
    }

    private void SelectCardInHand(int i)
    {
        ReloadAnimation();
        dekaCardsIsActive[i] = true;
        
        dekaCards[i].transform.DOMove(dekaCardsPositionsActivate[i].transform.position, 0.55f);
        dekaCards[i].transform.DORotate(dekaCardsPositionsActivate[i].transform.rotation.eulerAngles, 0.55f);

        for (var i1 = 0; i1 < dekaCards.Length; i1++)
        {
            if (i != i1) HideCardInHand(i1);
        }
    }

    private void HideCardInHand(int i)
    {
        dekaCardsIsActive[i] = false;
        dekaCards[i].transform.DOMove(dekaCardsPositionsIdle[i].transform.position, 0.55f);
        dekaCards[i].transform.DORotate(dekaCardsPositionsIdle[i].transform.rotation.eulerAngles, 0.55f);
    }
    
    public bool AddCard(Card card)
    {
        if (deka.Count < dekaCards.Length)
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

    public void ReloadAnimation()
    {
        handsAnimator.SetTrigger("take");
    }
}
