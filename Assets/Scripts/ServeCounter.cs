using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeCounter : MonoBehaviour, Actionable
{
  public void doAction(Player player)
  {
    player.ServeDrink();
  }
}
