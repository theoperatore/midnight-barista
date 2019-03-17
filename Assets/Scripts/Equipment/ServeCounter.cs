using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeCounter : MonoBehaviour, Interactable
{
  [SerializeField] GameEvent raisesEvent;

  public void OnInteraction(Player player)
  {
    raisesEvent.Raise();
  }
}
