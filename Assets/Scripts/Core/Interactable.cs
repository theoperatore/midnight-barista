using UnityEngine;
using UnityEngine.Events;

namespace Midnight.Core
{
  public class Interactable : MonoBehaviour
  {
    [SerializeField] UnityEvent onInteraction;

    public void RaiseInteraction()
    {
      onInteraction.Invoke();
    }
  }
}
