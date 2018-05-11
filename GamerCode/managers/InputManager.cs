using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public KeyCode[] keys;

    public static InputManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);

        DefaultKeys();
    }

    public void ChangeKeys(KeyCode[] k)
    {
        keys = k;
    }

    public void DefaultKeys()
    {
        keys = new KeyCode[] {
            KeyCode.J, KeyCode.I, KeyCode.L, KeyCode.K,
            KeyCode.A, KeyCode.W, KeyCode.D, KeyCode.S,
            KeyCode.F, KeyCode.R,
            KeyCode.Q, KeyCode.E, KeyCode.U, KeyCode.O
        };
    }
}
