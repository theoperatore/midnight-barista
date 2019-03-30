using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using Midnight.Core;
using UnityEngine;
using UnityEngine.UI;

public class MachineCoffee : MonoBehaviour
{

  [SerializeField] int buttonHoldDuration = 100;
  [SerializeField] GameEvent raisesEvent;

  GameAction gameAction;
  PlayerController player;

  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    gameAction = GetComponent<GameAction>();
  }

  public void OnInteraction()
  {
    if (player.CanMakeEspresso())
    {
      gameAction.StartAction(() => Input.GetButton("Jump"), buttonHoldDuration);
    }
  }

  public void HandleDone(float duration)
  {
    raisesEvent.Raise();
  }
}
