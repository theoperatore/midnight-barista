using UnityEngine;

[CreateAssetMenu()]
public class InventoryState : ScriptableObject
{
  [SerializeField] string stateName;

  public string getName()
  {
    return stateName;
  }
}
