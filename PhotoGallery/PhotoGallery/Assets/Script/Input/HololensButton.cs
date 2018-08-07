using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractiveItem))]
[RequireComponent(typeof(Input))]
public class HololensButton : MonoBehaviour
{
    public InteractiveItem interactiveItem;
    public UnityEvent OnClickEvent;

    public void Awake()
    {
        if(!interactiveItem)
        {
            interactiveItem = GetComponent<InteractiveItem>();
        }
    }
    private void OnEnable()
    {
        interactiveItem.OnClick += Click;
    }

    private void OnDisable()
    {
        interactiveItem.OnClick -= Click;
    }

    public void Click()
    {
        OnClickEvent.Invoke();
    }

}
