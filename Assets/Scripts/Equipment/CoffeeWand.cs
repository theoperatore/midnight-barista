using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWand : MonoBehaviour, Actionable
{
  [SerializeField] GameEvent emitsEvent;

  public void doAction(Player player)
  {
    emitsEvent.Raise();
    gameObject.SetActive(false);
  }
}
