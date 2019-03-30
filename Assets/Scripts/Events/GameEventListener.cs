using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Midnight.Events
{
  public class GameEventListener : MonoBehaviour
  {

    [SerializeField] GameEvent eventToListen;
    [SerializeField] UnityEvent onEventRaised;

    private void OnEnable()
    {
      eventToListen.AddEventListener(this);
    }

    private void OnDisable()
    {
      eventToListen.RemoveEventListener(this);
    }

    public void OnEventRaised()
    {
      onEventRaised.Invoke();
    }
  }
}
