using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private bool isMovable = false;
    [SerializeField] private bool isPressNowGo = false;
    [SerializeField] private bool isPressNowLeft = false;
    [SerializeField] private bool isPressNowRight = false;
    private float leftRightCoef = 0.1f;
    private Vector3 _lastPosition = Vector3.zero;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        _speed = Random.Range(5.0f, 10.0f);
    }

    void Update()
    {
        //Debug.Log(isMovable);
        //Debug.Log(isPressNow);
        if (isMovable)
        {
            if (isPressNowGo)
            {
                Go();
            }
            if (isPressNowLeft)
            {
                Left();
            }
            if (isPressNowRight)
            {
                Right();
            }
        }
        //if (isMovable)
        //{
        //    switch (InputManager.instance.GetCurrentInputMode())
        //    {
        //        case InputModes.Touch:
        //            MoveByTouch();
        //            break;
        //        case InputModes.Accelerometer:
        //            MoveByAccelerometer();
        //            break;
        //        default:
        //            break;
        //    }
            //float horizontalInput = Input.GetAxis("Horizontal");
            //float verticalInput = Input.GetAxis("Vertical");

            //Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
            //transform.Translate(direction * _speed * Time.deltaTime);

            ////the implementation of inertia is based on https://question-it.com/questions/1622381/kak-dobavit-inertsiju-obektu-3d-v-unity
            //Vector3 velocity = (_lastPosition - transform.position) * Time.deltaTime;
            //_lastPosition = transform.position;
            //rigidBody.velocity = velocity;
        //}
    }

    public void ChangeBallMovableStatus(bool desiredStatus)
    {
        isMovable = desiredStatus;
    }

    public void ChangeBallMovableLeftStatus(bool desiredStatus)
    {
        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.GetComponent<Ball>().isPressNowLeft = desiredStatus;
    }

    public void ChangeBallMovableRightStatus(bool desiredStatus)
    {
        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.GetComponent<Ball>().isPressNowRight = desiredStatus;
    }

    public void Go()
    {
        Debug.Log("Go");
        Vector3 direction = Vector3.forward;
        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.transform.Translate(direction * _speed * Time.deltaTime);

        Vector3 velocity = (_lastPosition - currentBall.transform.position) * Time.deltaTime;
        _lastPosition = currentBall.transform.position;
        currentBall.GetComponent<Rigidbody>().velocity = velocity;
    }



    public void Left()
    {
        Debug.Log("Left");
        Vector3 direction = Vector3.left;

        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.transform.Translate(direction * leftRightCoef * Time.deltaTime);

        Vector3 velocity = (_lastPosition - currentBall.transform.position) * Time.deltaTime;
        _lastPosition = currentBall.transform.position;
        currentBall.GetComponent<Rigidbody>().velocity = velocity;

        
    }

    public void Right()
    {
        Debug.Log("Right");
        Vector3 direction = Vector3.right;

        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.transform.Translate(direction * leftRightCoef * Time.deltaTime);

        Vector3 velocity = (_lastPosition - currentBall.transform.position) * Time.deltaTime;
        _lastPosition = currentBall.transform.position;
        currentBall.GetComponent<Rigidbody>().velocity = velocity;
    }

    public void ChangeIsPressStatus(bool desiredStatus)
    {
        Debug.Log(desiredStatus);
        GameManager.instance.GetBallOnScene().GetComponent<Ball>().isPressNowGo = desiredStatus;
        Debug.Log(isPressNowGo);
    }

    public void MoveByTouch()
    {
        
    }

    public void MoveByAccelerometer()
    {

    }
}
