using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
  [SerializeField] private int allCount;
  [SerializeField] private int maxCount;

  public void Add(int count)
  {
    allCount += count;
    
    if (allCount > maxCount)
    {
      allCount = maxCount;
    }
  }

  public bool Use(int count)
  {
    if (count >= allCount)
    {
      allCount -= count;
      return true;
    }

    return false;
  }
}
