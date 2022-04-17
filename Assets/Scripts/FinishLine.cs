using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        GameObject currentball = collision.gameObject;
        currentball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        StateMachine.instance.FindOut(Events.CrossFinishLine);
        Debug.Log("CrossFinishLine");
    }
}
