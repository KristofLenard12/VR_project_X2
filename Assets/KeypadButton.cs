using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeypadButton : MonoBehaviour
{
    public int buttonID;
    public int symbolID;

    public TextMeshPro text;
    public Keypad keypad;

    public void SetText(string text, int symbolID)
    {
        this.text.text = text; //lmao
        this.symbolID = symbolID;
    }

    public void ButtonPressed()
    {
        keypad.ButtonPressed(buttonID, symbolID);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.gameObject.name} entered trigger");
        if (other.gameObject.name.Contains("Controller"))
        {
            ButtonPressed();
        }
    }
}
