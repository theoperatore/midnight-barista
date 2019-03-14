using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWand : MonoBehaviour, Actionable
{
  [SerializeField] InventoryState givesState;

  public void doAction(Player player)
  {
    player.GetInventory().AddItemToInventory(State.WAND_EMPTY);
    player.SetWandState(givesState);
    gameObject.SetActive(false);
  }
}
