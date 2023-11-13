using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    Vector3 mousePos;

    private void OnMouseDrag() 
    {
        mousePos = Input.mousePosition;
        if(this.gameObject.name=="pin_clip")
        {
            mousePos.z = 0.38f;
        }
        else
        {
            mousePos.z = 0.43f;
        }
        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

}
