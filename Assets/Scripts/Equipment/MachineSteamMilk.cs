using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineSteamMilk : MonoBehaviour, Actionable
{
  [SerializeField] int holdDuration = 100;
  [SerializeField] Drink cappuccino;
  [SerializeField] Slider progress;

  Player player;
  HoldAction action;

  private void Start()
  {
    progress.gameObject.SetActive(false);
    action = GetComponent<HoldAction>();
  }

  public void doAction(Player player)
  {
    this.player = player;
    Inventory inv = player.GetInventory();

    if (inv.HasItems(State.ESPRESSO))
    {
      progress.gameObject.SetActive(true);
      action.StartAction(HandleDone, HandleCancel, handleProgress, holdDuration);
    }
  }

  public void HandleDone(int durationHeld)
  {
    player.GetInventory().RemoveItemFromInventory(State.ESPRESSO);
    player.GetInventory().AddItemToInventory(State.CAPPUCCINO);
    player.SetDrink(cappuccino);
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
