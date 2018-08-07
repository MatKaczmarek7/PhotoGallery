using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractiveItem : MonoBehaviour, IInteractable
{

    public event Action OnClick;

    public void Click()
    {
        if (OnClick != null)
        {
            OnClick();
        }
    }
}
