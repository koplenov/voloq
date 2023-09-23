using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Slider heathBar;

    private void Awake()
    {
        heathBar.maxValue = 100;
        heathBar.interactable = false;
    }

    private void Update()
    {
        heathBar.value = Client.Instance.hp;
    }
}
