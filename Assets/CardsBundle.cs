using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsBundle : MonoBehaviour
{
   [SerializeField] private Card[] cards;

   public static CardsBundle Instance;
   
   public Card GetRandomCard()
   {
      int rand = Random.Range(0,cards.Length);

      return cards[rand];
   }

   private void Awake()
   {
      Instance = this;
   }
}
