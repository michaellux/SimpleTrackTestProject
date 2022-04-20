using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;

    [DllImport("__Internal")]
    private static extern void AddEscapeKeyPressListener();

    // Start is called before the first frame update
    void Start()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape");
            SwitchToAnotherState();
        }
    }

    public void SwitchToAnotherState()
    {
        StateMachine.instance.FindOut(Events.EscapeButtonPressed);
    }
}
