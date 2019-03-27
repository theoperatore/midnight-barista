using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class Drink : ScriptableObject
{
  [SerializeField] int cost = 2;
  [SerializeField] string drinkName;
  [SerializeField] InventoryState inventoryState;

  public int GetCost()
  {
    return cost;
  }

  public string GetDrinkName()
  {
    return drinkName;
  }

  public InventoryState GetInventoryState()
  {
    return inventoryState;
  }
}
