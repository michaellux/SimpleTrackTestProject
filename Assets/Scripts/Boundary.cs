using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter(Collider collision)
    {
        GameObject currentball = collision.gameObject;
        currentball.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        yield return new WaitForSeconds(3);
        StateMachine.instance.FindOut(Events.FallingOffTheTrack);
        Debug.Log("FallingOff");
    }
}
