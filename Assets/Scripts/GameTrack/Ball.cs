using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private bool isMovable = false;
    private Vector3 _lastPosition = Vector3.zero;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        _speed = Random.Range(5.0f, 10.0f);
    }

    void Update()
    {
        if (isMovable)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            transform.Translate(direction * _speed * Time.deltaTime);

            //the implementation of inertia is based on https://question-it.com/questions/1622381/kak-dobavit-inertsiju-obektu-3d-v-unity
            Vector3 velocity = (_lastPosition - transform.position) * Time.deltaTime;
            _lastPosition = transform.position;
            rigidBody.velocity = velocity;
        }
    }

    public void ChangeBallMovableStatus(bool desiredStatus)
    {
        isMovable = desiredStatus;
    }
}
