using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using Midnight.Events;
using UnityEngine;

public class ServeCounter : MonoBehaviour
{
  [SerializeField] GameEvent raisesEvent;

  public void OnInteraction()
  {
    raisesEvent.Raise();
  }
}
