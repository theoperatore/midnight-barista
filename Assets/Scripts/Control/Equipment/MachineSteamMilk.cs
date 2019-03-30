using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using Midnight.Core;
using UnityEngine;
using UnityEngine.UI;

public class MachineSteamMilk : MonoBehaviour
{
  [SerializeField] int holdDuration = 100;
  [SerializeField] GameEvent raisesEvent;

  GameAction action;
  PlayerController player;

  private void Start()
  {
    action = GetComponent<GameAction>();
    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
  }

  public void OnInteraction()
  {
    if (player.CanMakeCappuccino())
    {
      action.StartAction(() => Input.GetButton("Jump"), holdDuration);
    }
  }

  public void HandleDone()
  {
    raisesEvent.Raise();

  }
}
