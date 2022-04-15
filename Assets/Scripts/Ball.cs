using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private Vector3 lastPosition = Vector3.zero;
    public Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(direction * _speed * Time.deltaTime);

        // Реализация инерции https://question-it.com/questions/1622381/kak-dobavit-inertsiju-obektu-3d-v-unity
        Vector3 velocity = (lastPosition - transform.position) * Time.deltaTime;
        lastPosition = transform.position;
        rigidBody.velocity = velocity;
    }
}
