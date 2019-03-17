using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeCounter : MonoBehaviour, Actionable
{
  [SerializeField] GameEvent raisesEvent;

  public void doAction(Player player)
  {
    raisesEvent.Raise();
  }
}
