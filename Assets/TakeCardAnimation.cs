using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCardAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem card;
    
    public void ShowCard()
    {
        card.Play();
    }
}
