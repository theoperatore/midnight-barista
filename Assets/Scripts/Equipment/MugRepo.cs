using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugRepo : MonoBehaviour, Actionable
{

  [SerializeField] GameEvent mugTakenEvent;

  public void doAction(Player player)
  {
    if (player.CanTakeMug())
    {
      mugTakenEvent.Raise();
    }
  }
}
