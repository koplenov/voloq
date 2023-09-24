using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class CardHandView : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text countMana;
    [SerializeField] private TMP_Text countDamage;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text title;


    public void SendConfig(CardData cardData)
    {
        icon.sprite = cardData.image;
        countMana.text = cardData.manaCost.ToString();
        countDamage.text = cardData.damage.ToString();
        description.text = cardData.description;
        title.text = cardData.name;
    }
}