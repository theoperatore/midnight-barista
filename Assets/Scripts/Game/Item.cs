using UnityEngine;

namespace Midnight.Game
{
  [CreateAssetMenu()]
  public class Item : ScriptableObject
  {

    [SerializeField] string itemName;
    [SerializeField] Sprite sprite;

    public Sprite GetSprite()
    {
      return sprite;
    }

    public string GetItemName()
    {
      return itemName;
    }

  }
}
