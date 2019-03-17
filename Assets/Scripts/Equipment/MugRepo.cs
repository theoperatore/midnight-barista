using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MugRepo : MonoBehaviour, Interactable
{

  [SerializeField] GameEvent mugTakenEvent;

  public void OnInteraction(Player player)
  {
    if (player.CanTakeMug())
    {
      mugTakenEvent.Raise();
    }
  }
}
