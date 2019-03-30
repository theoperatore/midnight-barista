using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Midnight.Core
{

  [System.Serializable]
  public class ActionEvent : UnityEvent<float> { }

  public class GameAction : MonoBehaviour
  {
    [SerializeField] UnityEvent onStart;
    [SerializeField] ActionEvent onProgress;
    [SerializeField] ActionEvent onEnd;
    [SerializeField] ActionEvent onCancel;


    public Coroutine StartAction(Func<bool> shouldContinue, float maxDuration = 0)
    {
      onStart.Invoke();
      return StartCoroutine(HandleHold(shouldContinue, maxDuration));
    }

    private IEnumerator HandleHold(Func<bool> shouldContinue, float maxDuration)
    {
      float progress = 0;
      while (shouldContinue() && progress < maxDuration)
      {
        progress += 1f;
        onProgress.Invoke(progress / maxDuration);
        yield return new WaitForEndOfFrame();
      }
      if (progress < maxDuration)
      {
        onCancel.Invoke(progress);
      }
      else
      {
        onEnd.Invoke(progress);
      }
    }

    private bool Noop() { return false; }
  }
}
