using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using Midnight.Core;
using Midnight.Events;
using UnityEngine;
using UnityEngine.UI;

public class MachineWater : MonoBehaviour
{
  [SerializeField] int holdDuration = 25;
  [SerializeField] GameEvent raisesEvent;

  GameAction action;
  PlayerController player;


  // Start is called before the first frame update
  void Start()
  {
    action = GetComponent<GameAction>();
    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
  }

  public void OnInteraction()
  {
    if (player.CanMakeAmericano())
    {
      action.StartAction(() => Input.GetButton("Jump"), holdDuration);
    }
  }

  public void HandleDone()
  {
    raisesEvent.Raise();
  }
}
