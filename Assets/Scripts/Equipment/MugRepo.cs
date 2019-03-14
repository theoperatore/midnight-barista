using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugRepo : MonoBehaviour, Actionable
{

  [SerializeField] InventoryState emptyMug;

  public void doAction(Player player)
  {
    Inventory inv = player.GetInventory();
    if (!inv.HasItem(State.EMPTY_MUG) && !player.IsHoldingDrink())
    {
      inv.AddItemToInventory(State.EMPTY_MUG);
      player.SetDrinkState(emptyMug);
    }
  }
}
