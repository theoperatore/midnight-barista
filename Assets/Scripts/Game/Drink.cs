using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midnight.Game
{
  [CreateAssetMenu()]
  public class Drink : ScriptableObject
  {
    [SerializeField] int cost = 2;
    [SerializeField] string drinkName;
    [SerializeField] Sprite sprite;

    public int GetCost()
    {
      return cost;
    }

    public string GetDrinkName()
    {
      return drinkName;
    }

    public Sprite GetSprite()
    {
      return sprite;
    }
  }
}
