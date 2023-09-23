using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine.PlayerLoop;
using UnityEngine.ProBuilder.Shapes;
using Utils;
using Sprite = UnityEngine.Sprite;

[RequireComponent(typeof(Rigidbody))]
public abstract class Card : MonoBehaviour
{
    [SerializeField] private Transform cardMesh;
    [SerializeField] private float force;
    [SerializeField] protected CardData cardData;
    [SerializeField] protected Rigidbody rigidBody;
    Vector3 lastFramePosition = Vector3.zero;
    [SerializeField] private LayerMask enemyLayerMask;

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
        if (Physics.Raycast(new Ray(transform.position, lastFramePosition),out hit,1000f,enemyLayerMask))
        {
            if (hit.collider)
            {
                if (hit.collider.CompareTag("NetPlayer"))
                {
                    NetPlayerData netData = hit.collider.GetComponent<NetPlayerData>();
                    Debug.Log("Попал в " + netData.nick);
                    GameUtils.SendDamage(Client.nick,netData.nick,cardData.damage);
                    netData.botState.ApplyDamage(cardData.damage);
                    
                }
            }
        }
        lastFramePosition = transform.position;
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
