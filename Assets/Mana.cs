using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
  [SerializeField] private int count;
  [SerializeField] private int maxCount;
  [SerializeField] private float time = 2f;

  public int MaxCount => maxCount;
  public int Count => count;
  IEnumerator CD()
  {
    while (count < maxCount)
    {
      yield return new WaitForSeconds(time);
      Add(1);
    }
  }
  
  public void Add(int count)
  {
    this.count += count;
    
    if (this.count > maxCount)
    {
      this.count = maxCount;
    }
  }

  public bool Use(int count)
  {
    if (count >= this.count)
    {
      this.count -= count;
      StartCoroutine(CD());
      return true;
    }
    else
    {
      StartCoroutine(CD());
      return false;
    }
  }
}
