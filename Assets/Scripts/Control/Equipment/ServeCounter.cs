using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using UnityEngine;

public class ServeCounter : MonoBehaviour, IInteractable
{
  [SerializeField] GameEvent raisesEvent;

  public void OnInteraction(PlayerController player)
  {
    raisesEvent.Raise();
  }
}
