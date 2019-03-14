using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineCoffee : MonoBehaviour, Actionable
{

  [SerializeField] int buttonHoldDuration = 100;
  [SerializeField] Slider progressBar;
  [SerializeField] Drink createdDrink;
  [SerializeField] InventoryState wandState;

  HoldAction holdAction;
  Player player;

  // Start is called before the first frame update
  void Start()
  {
    holdAction = GetComponent<HoldAction>();
    progressBar.gameObject.SetActive(false);
  }

  public void doAction(Player player)
  {
    Inventory inv = player.GetInventory();

    if (player.IsHoldingDrink()) return;
    if (inv.HasItems(State.WAND_FILLED, State.EMPTY_MUG))
    {
      this.player = player;
      progressBar.gameObject.SetActive(true);
      holdAction.StartAction(HandleDone, HandleCancel, HandleProgress, buttonHoldDuration);
    }
  }

  private void HandleDone(int duration)
  {
    if (!this.player) return;
    Inventory inv = player.GetInventory();
    inv.RemoveItemFromInventory(State.EMPTY_MUG, State.WAND_FILLED);
    player.SetDrink(createdDrink);
    player.SetWandState(wandState);
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
