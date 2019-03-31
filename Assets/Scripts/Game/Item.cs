using UnityEngine;

namespace Midnight.Game
{
  [CreateAssetMenu()]
  public class Item : ScriptableObject
  {

    [SerializeField] string itemName;
    [SerializeField] Sprite sprite;
    [SerializeField] int cost = 0;

    public Sprite GetSprite()
    {
      return sprite;
    }

    public string GetItemName()
    {
      return itemName;
    }

    public int GetCost()
    {
      return cost;
    }

  }
}
