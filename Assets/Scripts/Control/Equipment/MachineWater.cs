using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using Midnight.Core;
using UnityEngine;
using UnityEngine.UI;

public class MachineWater : MonoBehaviour, IInteractable
{
  [SerializeField] int holdDuration = 25;
  [SerializeField] Slider progress;
  [SerializeField] GameEvent raisesEvent;

  HoldAction action;

  // Start is called before the first frame update
  void Start()
  {
    action = GetComponent<HoldAction>();
    progress.gameObject.SetActive(false);
  }

  public void OnInteraction(PlayerController player)
  {
    if (player.CanMakeAmericano())
    {
      progress.gameObject.SetActive(true);
      action.StartAction(HandleDone, HandleCancel, HandleProgress, holdDuration);
    }
  }

  void HandleDone(int duration)
  {
    progress.gameObject.SetActive(false);
    raisesEvent.Raise();
  }

  void HandleCancel(int duration)
  {
    progress.gameObject.SetActive(false);

  }

  void HandleProgress(int duration)
  {
    progress.value = (float)duration / (float)holdDuration;
  }
}
