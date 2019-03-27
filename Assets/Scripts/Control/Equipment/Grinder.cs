using System;
using System.Collections;
using Midnight.Control;
using Midnight.Core;
using UnityEngine;
using UnityEngine.UI;

public class Grinder : MonoBehaviour, IInteractable
{

  [SerializeField] int buttonHoldDuration = 100;
  [SerializeField] Slider progressBar;
  [SerializeField] GameEvent emitsEvent;

  HoldAction holdAction;

  private void Start()
  {
    holdAction = GetComponent<HoldAction>();
    progressBar.gameObject.SetActive(false);
  }

  // called from the player script via Actionable interface
  public void OnInteraction(PlayerController player)
  {
    if (player.CanGrindCoffee())
    {
      progressBar.gameObject.SetActive(true);
      holdAction.StartAction(HandleDone, HandleCancel, HandleProgress, buttonHoldDuration);
    }
  }

  private void HandleDone(int durationHeld)
  {
    progressBar.gameObject.SetActive(false);
    emitsEvent.Raise();
  }

  private void HandleCancel(int durationHeld)
  {
    progressBar.gameObject.SetActive(false);
  }

  private void HandleProgress(int durationHeld)
  {
    progressBar.value = (float)durationHeld / (float)buttonHoldDuration; ;
  }
}
