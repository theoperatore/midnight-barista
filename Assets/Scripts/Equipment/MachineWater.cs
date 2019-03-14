using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachineWater : MonoBehaviour, Actionable
{
  [SerializeField] int holdDuration = 25;
  [SerializeField] Drink americano;
  [SerializeField] Slider progress;

  Player player;
  HoldAction action;

  // Start is called before the first frame update
  void Start()
  {
    action = GetComponent<HoldAction>();
    progress.gameObject.SetActive(false);
  }

  public void doAction(Player player)
  {
    this.player = player;
    if (player.GetInventory().HasItem(State.ESPRESSO))
    {
      progress.gameObject.SetActive(true);
      action.StartAction(HandleDone, HandleCancel, HandleProgress, holdDuration);
    }
  }

  void HandleDone(int duration)
  {
    player.GetInventory().RemoveItemFromInventory(State.ESPRESSO);
    player.GetInventory().AddItemToInventory(State.AMERICANO);
    player.SetDrink(americano);
    progress.gameObject.SetActive(false);
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
