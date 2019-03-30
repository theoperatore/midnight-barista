using System;
using System.Collections;
using Midnight.Control;
using Midnight.Core;
using Midnight.Events;
using UnityEngine;
using UnityEngine.UI;

public class Grinder : MonoBehaviour
{

  [SerializeField] float buttonHoldDuration = 100f;
  [SerializeField] GameEvent emitsEvent;

  GameAction gameAction;
  PlayerController player;

  private void Start()
  {
    gameAction = GetComponent<GameAction>();
    try
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    catch (Exception e)
    {
      print(e);
    }
  }

  // invoked by Interactable component
  public void OnInteraction()
  {
    if (player.CanGrindCoffee())
    {
      gameAction.StartAction(() => Input.GetButton("Jump"), buttonHoldDuration);
    }
  }

  public void HandleDone(float durationHeld)
  {
    emitsEvent.Raise();
  }
}
