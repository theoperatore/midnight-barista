using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{

  BoxCollider2D armCollider;
  GameObject inFrontOf = null;

  // Start is called before the first frame update
  void Start()
  {
    armCollider = GetComponent<BoxCollider2D>();
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    inFrontOf = other.gameObject;
  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (inFrontOf == other.gameObject)
    {
      inFrontOf = null;
    };
  }

  private void Update()
  {
    if (Input.GetButtonDown("Jump") && inFrontOf)
    {
      print("Activate " + inFrontOf.name);
    }
  }
}
