using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Midnight.Core
{
  public class Inventory : MonoBehaviour
  {

    HashSet<State> inventory;

    public Inventory()
    {
      inventory = new HashSet<State>();
    }

    public void AddItems(params State[] state)
    {
      foreach (var s in state)
      {
        inventory.Add(s);
      }
    }

    public bool RemoveItems(params State[] state)
    {
      foreach (var s in state)
      {
        inventory.Remove(s);
      }

      return true;
    }

    public bool HasItem(State state)
    {
      return inventory.Contains(state);
    }

    public bool HasItems(params State[] states)
    {
      foreach (State state in states)
      {
        if (!inventory.Contains(state)) return false;
      }

      return true;
    }
  }
}
