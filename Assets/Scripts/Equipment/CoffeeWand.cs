using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeWand : MonoBehaviour, Interactable
{
  [SerializeField] GameEvent emitsEvent;

  public void OnInteraction(Player player)
  {
    emitsEvent.Raise();
    gameObject.SetActive(false);
  }
}
