using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Grinder : MonoBehaviour, Actionable
{

  [SerializeField] int buttonHoldDuration = 100;
  [SerializeField] Slider progressBar;
  [SerializeField] InventoryState givesState;

  HoldAction holdAction;
  Player player;

  private void Start()
  {
    holdAction = GetComponent<HoldAction>();
    progressBar.gameObject.SetActive(false);
  }

  // called from the player script via Actionable interface
  public void doAction(Player player)
  {
    Inventory inv = player.GetInventory();
    if (inv.HasItem(State.WAND_EMPTY) && !inv.HasItem(State.WAND_FILLED))
    {
      this.player = player;
      progressBar.gameObject.SetActive(true);
      holdAction.StartAction(HandleDone, HandleCancel, HandleProgress, buttonHoldDuration);
    }
  }

  private void HandleDone(int durationHeld)
  {
    if (!this.player) return;
    progressBar.gameObject.SetActive(false);
    player.GetInventory().AddItemToInventory(State.WAND_FILLED);
    player.SetWandState(givesState);
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
