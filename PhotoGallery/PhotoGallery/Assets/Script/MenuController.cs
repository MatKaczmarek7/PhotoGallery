using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject[] menuWindows;

    public void OpenWindow(int index)
    {
        for (int i = 0; i < menuWindows.Length; i++)
        {
            if (i == index)
            {
                menuWindows[i].SetActive(true);
            }
            else
            {
                menuWindows[i].SetActive(false);
            }
        }

    }
}
