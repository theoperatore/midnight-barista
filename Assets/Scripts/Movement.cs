using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

  [SerializeField] int minx = -2;
  [SerializeField] int miny = 0;
  [SerializeField] int maxx = 0;
  [SerializeField] int maxy = 6;

  bool isUpPressed = false;
  bool isDownPressed = false;
  bool isLeftPressed = false;
  bool isRightPressed = false;

  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetAxisRaw("Horizontal") == 0)
    {
      isLeftPressed = false;
      isRightPressed = false;
    }

    if (Input.GetAxisRaw("Vertical") == 0)
    {
      isUpPressed = false;
      isDownPressed = false;
    }

    if (Input.GetAxisRaw("Horizontal") == -1 && !isLeftPressed)
    {
      isLeftPressed = true;
      if (transform.position.x - 1 < minx) return;
      transform.position += Vector3.left;
    }

    if (Input.GetAxisRaw("Horizontal") == 1 && !isRightPressed)
    {
      isRightPressed = true;
      if (transform.position.x + 1 > maxx) return;
      transform.position += Vector3.right;
    }

    if (Input.GetAxisRaw("Vertical") == -1 && !isDownPressed)
    {
      isDownPressed = true;
      if (transform.position.y - 1 < miny) return;
      transform.position += Vector3.down;
    }

    if (Input.GetAxisRaw("Vertical") == 1 && !isUpPressed)
    {
      isUpPressed = true;
      if (transform.position.y + 1 > maxy) return;
      transform.position += Vector3.up;
    }
  }

}
