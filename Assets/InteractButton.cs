using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractButton : MonoBehaviour
{
    Button button;
    public static event Action interactButtonPressed;

    private void Start()
    {
       button = GetComponent<Button>();
       button.interactable = false;

    }
    private void OnEnable()
    {
        Pushable.interactButtonOn += TurnOnButton;
        Pushable.interactButtonOff += TurnOffButton;
    }
    private void OnDisable()
    {
        Pushable.interactButtonOn -= TurnOnButton;
        Pushable.interactButtonOff -= TurnOffButton;
    }

    public void TurnOnButton()
    {
        button.interactable = true;
    }
    public void TurnOffButton()
    {
        button.interactable = false;
    }

    public void ButtonPressed()
    {
        interactButtonPressed.Invoke();
    }
}
