using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;
    [SerializeField] private InputModes _currentInputMode;
    [SerializeField] private ToggleGroup inputModeToggleGroup;
    private readonly string prefsInputModeName = "inputMode";

    // Start is called before the first frame update
    void Awake()
    {
        LoadInputSettings();
        //ToDo
        //SetInputSettings();
    }
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
        if (Input.GetKey(KeyCode.Escape))
        {
            StateMachine.instance.FindOut(Events.EscapeButtonPressed);
        }
    }

    public void SaveInputSettings()
    {
        PlayerPrefs.SetString(prefsInputModeName, $"{_currentInputMode}");
        Debug.Log($"{_currentInputMode} saved");
    }

    public void LoadInputSettings()
    {
        _currentInputMode = (InputModes)System.Enum.Parse(typeof(InputModes), PlayerPrefs.GetString(prefsInputModeName));
        Debug.Log($"{_currentInputMode} load");
    }

    //public void SetInputSettings()
    //{
    //    GameObject.FindGameObjectWithTag($"{_currentInputMode}").GetComponent<Toggle>().isOn = true;
    //}

    public void ChangeInputMode()
    {
        foreach (var toggle in inputModeToggleGroup.ActiveToggles())
        {
            try
            {
                _currentInputMode = (InputModes)System.Enum.Parse(typeof(InputModes), toggle.tag);
                SaveInputSettings();
            }
            catch (System.Exception)
            {
                Debug.LogErrorFormat("Parse: Can't convert {0} to enum, please check the spell.", toggle.tag);
            }
        }
    }

    public InputModes GetCurrentInputMode()
    {
        return _currentInputMode;
    }
}


