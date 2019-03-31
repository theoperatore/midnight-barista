using System.Collections;
using System.Collections.Generic;
using Midnight.Core;
using Midnight.Game;
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

    int isEngagingHash = Animator.StringToHash("isEngaging");
    Item craftedDrink;
    Animator animator;
    Inventory inventory;

    Interactable interactable = null;

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

    public void SetDrink(Item createdDrink)
    {
      craftedDrink = createdDrink;
      this.SetDrinkState(createdDrink.GetSprite());
    }

    public void ServeDrink()
    {
      drinkImage.color = Color.black;
      drinkImage.sprite = null;
      inventory.RemoveItems(State.AMERICANO, State.CAPPUCCINO, State.ESPRESSO);
      this.AddProfit(craftedDrink.GetCost());
      craftedDrink = null;
    }

    public void SetWandState(Item wand)
    {
      SetWandState(wand.GetSprite());
    }

    private void SetWandState(Sprite sprite)
    {
      wandImage.color = Color.white;
      wandImage.sprite = sprite;
    }

    private void SetDrinkState(Sprite sprite)
    {
      drinkImage.color = Color.white;
      drinkImage.sprite = sprite;
    }

    public void AddProfit(int amount)
    {
      profit += amount;
      profitText.text = profit.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      interactable = other.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
      if (interactable == other.gameObject.GetComponent<Interactable>())
      {
        interactable = null;
      };
    }

    private void Update()
    {
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
      return !inventory.HasItems(State.EMPTY_MUG) && !craftedDrink;
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
    public void HandleCoffeeWandTake(Item wand)
    {
      this.SetWandState(wand.GetSprite());
      inventory.AddItems(State.WAND_EMPTY);
    }

    public void HandleCoffeeGround(Item filledWand)
    {
      this.SetWandState(filledWand.GetSprite());
      inventory.RemoveItems(State.WAND_EMPTY);
      inventory.AddItems(State.WAND_FILLED);
    }

    public void HandleMugTaken(Item emptyMug)
    {
      if (!CanTakeMug()) return;
      this.SetDrinkState(emptyMug.GetSprite());
      inventory.AddItems(State.EMPTY_MUG);
    }

    public void HandleEspressoCreated(Item espresso)
    {
      this.SetDrink(espresso);
      inventory.RemoveItems(State.EMPTY_MUG, State.WAND_FILLED);
      inventory.AddItems(State.WAND_EMPTY, State.ESPRESSO);
    }

    public void HandleAmericanoCreated(Item americano)
    {
      this.SetDrink(americano);
      inventory.AddItems(State.AMERICANO);
      inventory.RemoveItems(State.CAPPUCCINO, State.ESPRESSO);
    }

    public void HandleCappuccinoCreated(Item cappuccino)
    {
      this.SetDrink(cappuccino);
      inventory.AddItems(State.CAPPUCCINO);
      inventory.RemoveItems(State.AMERICANO, State.ESPRESSO);
    }
  }
}
