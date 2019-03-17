using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineCoffee : MonoBehaviour, Actionable
{

  [SerializeField] int buttonHoldDuration = 100;
  [SerializeField] Slider progressBar;
  [SerializeField] GameEvent raisesEvent;

  HoldAction holdAction;

  // Start is called before the first frame update
  void Start()
  {
    holdAction = GetComponent<HoldAction>();
    progressBar.gameObject.SetActive(false);
  }

  public void doAction(Player player)
  {
    if (player.CanMakeEspresso())
    {
      progressBar.gameObject.SetActive(true);
      holdAction.StartAction(HandleDone, HandleCancel, HandleProgress, buttonHoldDuration);
    }
  }

  private void HandleDone(int duration)
  {
    raisesEvent.Raise();
    progressBar.gameObject.SetActive(false);
  }

  private void HandleCancel(int duration)
  {
    progressBar.gameObject.SetActive(false);
  }

  private void HandleProgress(int duration)
  {
    progressBar.value = (float)duration / (float)buttonHoldDuration;
  }
}
