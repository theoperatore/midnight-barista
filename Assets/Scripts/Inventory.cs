using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

  Dictionary<State, bool> inventory;

  public Inventory()
  {
    inventory = new Dictionary<State, bool>();
  }

  public void AddItemToInventory(State state)
  {
    inventory.Add(state, true);
  }

  public bool RemoveItemFromInventory(params State[] state)
  {
    foreach (var s in state)
    {
      inventory.Remove(s);
    }

    return true;
  }

  public bool HasItem(State state)
  {
    return inventory.ContainsKey(state);
  }

  public bool HasItems(params State[] states)
  {
    foreach (State state in states)
    {
      if (!inventory.ContainsKey(state)) return false;
    }

    return true;
  }
}
