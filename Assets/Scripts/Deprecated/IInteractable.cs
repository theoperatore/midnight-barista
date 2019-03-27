using System.Collections;
using System.Collections.Generic;
using Midnight.Control;
using UnityEngine;

public interface IInteractable
{
  void OnInteraction(PlayerController player);
}
