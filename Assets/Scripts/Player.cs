using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  [SerializeField] int profit = 0;
  [SerializeField] Image wandImage;
  [SerializeField] Image drinkImage;
  [SerializeField] Text profitText;
  [SerializeField] InventoryState[] inventorySpriteKeyNames;
  [SerializeField] Sprite[] inventorySprites;

  Actionable inFrontOf = null;
  Inventory inventory = new Inventory();
  Drink drink;
  Dictionary<InventoryState, Sprite> sprites = new Dictionary<InventoryState, Sprite>();

  private void Awake()
  {
    if (inventorySpriteKeyNames.Length != inventorySprites.Length)
    {
      throw new System.ArgumentException("Player.cs: Sprite Keys and Sprite values have unequal lengths! They must be equal lengths!");
    }

    for (int i = 0; i < inventorySpriteKeyNames.Length; i++)
    {
      sprites.Add(inventorySpriteKeyNames[i], inventorySprites[i]);
    }
  }

  private void Start()
  {
    wandImage.sprite = null;
    drinkImage.sprite = null;
    wandImage.color = Color.black;
    drinkImage.color = Color.black;
    profitText.text = profit.ToString();
  }

  public Inventory GetInventory()
  {
    return inventory;
  }

  public void SetDrink(Drink createdDrink)
  {
    this.drink = createdDrink;
    drinkImage.color = Color.white;
    drinkImage.sprite = sprites[createdDrink.GetInventoryState()];
  }

  public void ServeDrink()
  {
    Drink d = this.drink;
    this.drink = null;
    drinkImage.color = Color.black;
    drinkImage.sprite = null;
    this.AddProfit(d.GetCost());
  }

  public bool IsHoldingDrink()
  {
    return this.drink != null;
  }

  public void SetWandState(InventoryState state)
  {
    wandImage.color = Color.white;
    wandImage.sprite = sprites[state];
  }

  public void SetDrinkState(InventoryState state)
  {
    drinkImage.color = Color.white;
    drinkImage.sprite = sprites[state];
  }

  public void AddProfit(int amount)
  {
    profit += amount;
    profitText.text = profit.ToString();
  }

  public int GetProfit()
  {
    return profit;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    inFrontOf = other.gameObject.GetComponent<Actionable>();
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (inFrontOf == other.gameObject.GetComponent<Actionable>())
    {
      inFrontOf = null;
    };
  }

  private void Update()
  {
    if (Input.GetButtonDown("Jump") && inFrontOf != null)
    {
      inFrontOf.doAction(this);
    }
  }
}
