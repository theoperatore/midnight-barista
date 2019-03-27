using System.Collections;
using System.Collections.Generic;
using Midnight.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Midnight.Control
{
  public class PlayerController : MonoBehaviour
  {
    [SerializeField] int profit = 0;
    [SerializeField] Image wandImage;
    [SerializeField] Image drinkImage;
    [SerializeField] Text profitText;
    [SerializeField] InventoryState[] inventorySpriteKeyNames;
    [SerializeField] Sprite[] inventorySprites;

    int isEngagingHash = Animator.StringToHash("isEngaging");
    Animator animator;
    Drink drink;
    Dictionary<InventoryState, Sprite> sprites = new Dictionary<InventoryState, Sprite>();
    Inventory inventory;

    // FIXME: deprecate IInteractable
    IInteractable inFrontOf = null;
    Interactable interactable = null;

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
      animator = GetComponent<Animator>();
      inventory = GetComponent<Inventory>();
    }

    public void SetDrink(Drink createdDrink)
    {
      this.drink = createdDrink;
      this.SetDrinkState(createdDrink.GetInventoryState());
    }

    public void ServeDrink()
    {
      if (!this.drink) return;

      Drink d = this.drink;
      this.drink = null;
      drinkImage.color = Color.black;
      drinkImage.sprite = null;
      inventory.RemoveItems(State.AMERICANO, State.CAPPUCCINO, State.ESPRESSO);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
      inFrontOf = other.gameObject.GetComponent<IInteractable>();
      interactable = other.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (inFrontOf == other.gameObject.GetComponent<IInteractable>())
      {
        inFrontOf = null;
      };

      if (interactable == other.gameObject.GetComponent<Interactable>())
      {
        interactable = null;
      };
    }

    private void Update()
    {
      if (Input.GetButtonDown("Jump") && inFrontOf != null)
      {
        inFrontOf.OnInteraction(this);
      }

      if (Input.GetButtonDown("Jump") && interactable != null)
      {
        interactable.RaiseInteraction();
      }

      if (Input.GetButton("Jump"))
      {
        animator.SetBool(isEngagingHash, true);
      }
      else
      {
        animator.SetBool(isEngagingHash, false);
      }
    }

    // conditional checks
    public bool CanTakeMug()
    {
      return !inventory.HasItems(State.EMPTY_MUG) && !drink;
    }

    public bool CanGrindCoffee()
    {
      return inventory.HasItems(State.WAND_EMPTY);
    }

    public bool CanMakeEspresso()
    {
      return inventory.HasItems(State.WAND_FILLED, State.EMPTY_MUG);
    }

    public bool CanMakeAmericano()
    {
      return inventory.HasItems(State.ESPRESSO);
    }

    public bool CanMakeCappuccino()
    {
      return inventory.HasItems(State.ESPRESSO);
    }

    // event handlers
    public void HandleCoffeeWandTake(InventoryState wand)
    {
      this.SetWandState(wand);
      inventory.AddItems(State.WAND_EMPTY);
    }

    public void HandleCoffeeGround(InventoryState filledWand)
    {
      this.SetWandState(filledWand);
      inventory.RemoveItems(State.WAND_EMPTY);
      inventory.AddItems(State.WAND_FILLED);
    }

    public void HandleMugTaken(InventoryState emptyMug)
    {
      if (!CanTakeMug()) return;
      this.SetDrinkState(emptyMug);
      inventory.AddItems(State.EMPTY_MUG);
    }

    public void HandleEspressoCreated(InventoryState espresso)
    {
      this.SetDrinkState(espresso);
      inventory.RemoveItems(State.EMPTY_MUG, State.WAND_FILLED);
      inventory.AddItems(State.WAND_EMPTY, State.ESPRESSO);
    }

    public void HandleAmericanoCreated(InventoryState americano)
    {
      this.SetDrinkState(americano);
      inventory.AddItems(State.AMERICANO);
      inventory.RemoveItems(State.CAPPUCCINO, State.ESPRESSO);
    }

    public void HandleCappuccinoCreated(InventoryState cappuccino)
    {
      this.SetDrinkState(cappuccino);
      inventory.AddItems(State.CAPPUCCINO);
      inventory.RemoveItems(State.AMERICANO, State.ESPRESSO);
    }
  }
}
