using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//Change script to HololensInput

[RequireComponent(typeof(InteractiveItem))]
public class Input : MonoBehaviour, IPointerClickHandler
{

    public InteractiveItem interactiveItem;

    private void Awake()
    {
        if (!interactiveItem)
        {
            interactiveItem = GetComponent<InteractiveItem>();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        interactiveItem.Click();
    }
}
