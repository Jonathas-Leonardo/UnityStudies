using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyController : MonoBehaviour {

    public InputField[] inputField;

    private void Start()
    {
        for (int i = 0; i < inputField.Length; i++)
        {
            inputField[i].text = InputManager.instance.keys[i].ToString();
        }
    }

    public void ChangeKey()
    {
        KeyCode[] k = new KeyCode[inputField.Length];

        for (int i = 0; i < inputField.Length; i++)
        {
            k[i] = (KeyCode)System.Enum.Parse(typeof(KeyCode), inputField[i].text.ToUpper());
        }

        InputManager.instance.ChangeKeys(k);
    }

    public void DefaultKeys()
    {
        InputManager.instance.DefaultKeys();

        for (int i = 0; i < inputField.Length; i++)
        {
            inputField[i].text = InputManager.instance.keys[i].ToString();
        }
    }


}
