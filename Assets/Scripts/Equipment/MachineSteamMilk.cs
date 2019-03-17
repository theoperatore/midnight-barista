using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineSteamMilk : MonoBehaviour, Actionable
{
  [SerializeField] int holdDuration = 100;
  [SerializeField] GameEvent raisesEvent;
  [SerializeField] Slider progress;

  HoldAction action;

  private void Start()
  {
    progress.gameObject.SetActive(false);
    action = GetComponent<HoldAction>();
  }

  public void doAction(Player player)
  {
    if (player.CanMakeCappuccino())
    {
      progress.gameObject.SetActive(true);
      action.StartAction(HandleDone, HandleCancel, handleProgress, holdDuration);
    }
  }

  public void HandleDone(int durationHeld)
  {
    raisesEvent.Raise();
    progress.gameObject.SetActive(false);

  }

  public void HandleCancel(int durationHeld)
  {
    progress.gameObject.SetActive(false);
  }

  public void handleProgress(int durationHeld)
  {
    progress.value = (float)durationHeld / (float)holdDuration;
  }
}
