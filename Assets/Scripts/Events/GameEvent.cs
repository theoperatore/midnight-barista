using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameEvent : ScriptableObject
{
  private List<GameEventListener> listeners = new List<GameEventListener>();

  public void AddEventListener(GameEventListener listener)
  {
    listeners.Add(listener);
  }

  public bool RemoveEventListener(GameEventListener listener)
  {
    return listeners.Remove(listener);
  }

  public void Raise()
  {
    listeners.ForEach(action => action.OnEventRaised());
  }
}
