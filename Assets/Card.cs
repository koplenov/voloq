using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.PlayerLoop;
using Utils;

[RequireComponent(typeof(Rigidbody))]
public abstract class Card : MonoBehaviour
{
    [SerializeField] private Transform cardMesh;
    [SerializeField] private float force;
    [SerializeField] protected CardData cardData;
    [SerializeField] protected Rigidbody rigidBody;
    Vector3 lastFramePosition = Vector3.zero;

    private void OnEnable()
    {
        lastFramePosition = transform.position;
    }

    public virtual void Spell()
    {
        GameUtils.SendCastSpell(Client.nick,"ebalayka", Vector3.forward, transform.position);
    }

    public CardData GetCardData()
    {
        return cardData;
    }

    private void Update()
    {
        cardMesh.rotation *= Quaternion.Euler(0,0,15);
    }

    public void Shoot(Vector3 targetDirection)
    {
        rigidBody.AddForce(targetDirection * force,ForceMode.Impulse);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, lastFramePosition,out hit))
        {
            if (hit.collider)
            {
                Debug.LogError(hit.collider.name);
            }
        }
    }
    
    private void LateUpdate()
    {
        lastFramePosition = transform.position;
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NetPlayer"))
        {
            NetPlayerData netData = other.GetComponent<NetPlayerData>();
            GameUtils.SendDamage(Client.nick,netData.nick,(cardData.damage));
            netData.botState.ApplyDamage(cardData.damage);
           
        }
        print(other.name);
        
    }
}
[Serializable]
public struct CardData
{
    public int damage;
    public int heal;
    
    public int manaCost;
    public string description;
    public string name;
    public Sprite image;
}
