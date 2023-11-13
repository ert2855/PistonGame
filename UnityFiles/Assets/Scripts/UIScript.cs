using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject arrow;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            arrow.SetActive(false);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
