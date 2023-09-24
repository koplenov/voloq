using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProperties : MonoBehaviour
{
    [SerializeField] private Slider heathBar;
    [SerializeField] private Slider manaBar;
    [SerializeField] private Mana mana;
    private void Awake()
    {
        heathBar.maxValue = 100;
        manaBar.maxValue = mana.MaxCount;
        heathBar.interactable = false;
        manaBar.interactable = false;
    }

    private void Update()
    {
        heathBar.value = Client.Instance.hp;
        heathBar.value = mana.Count;
    }
}
