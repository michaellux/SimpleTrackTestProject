using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateMachine : MonoBehaviour
{
    public static StateMachine instance = null;
    internal State State { get; set; }

    void Awake()
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
        State = new MenuState();
        //StateMachine = new StateMachine();
    }

    public void FindOut(Events eventItem)
    {
        State.HandleButton(this, eventItem);
    }
}
