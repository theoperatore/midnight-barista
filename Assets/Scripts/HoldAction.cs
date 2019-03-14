using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAction : MonoBehaviour
{
  public Coroutine StartAction(Action<int> onDone, Action<int> onCancel, int maxDuration = 100)
  {
    return StartCoroutine(HandleHeld(onDone, onCancel, Noop, maxDuration));
  }

  public Coroutine StartAction(Action<int> onDone, Action<int> onCancel, Action<int> onProgress, int maxDuration = 100)
  {
    return StartCoroutine(HandleHeld(onDone, onCancel, onProgress, maxDuration));
  }

  private IEnumerator HandleHeld(Action<int> onDone, Action<int> onCancel, Action<int> onProgress, int max)
  {
    int durationHeld = 0;
    while (Input.GetButton("Jump") && durationHeld < max)
    {
      durationHeld += 1;
      onProgress(durationHeld);
      yield return new WaitForEndOfFrame();
    }

    if (durationHeld < max)
    {
      onCancel(durationHeld);
    }
    else
    {
      onDone(durationHeld);
    }
  }

  private void Noop(int ignored) { }
}
