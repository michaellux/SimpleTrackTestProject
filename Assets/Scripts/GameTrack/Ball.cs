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
    private float leftRightTouchCoef = 0.1f;
    private float leftRightAccelerometerCoef = 0.4f;
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
            if (InputManager.instance.GetCurrentInputMode() == InputModes.Touch)
            {
                if (isPressNowGo)
                {
                    Go();
                }
                if (isPressNowLeft)
                {
                    LeftByTouch();
                }
                if (isPressNowRight)
                {
                    RightByTouch();
                }
            }
            else if (InputManager.instance.GetCurrentInputMode() == InputModes.Accelerometer)
            {
                Go();
                LeftRight();
            }
        }
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



    public void LeftByTouch()
    {
        Debug.Log("Left");
        Vector3 direction = Vector3.left;

        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.transform.Translate(direction * leftRightTouchCoef * Time.deltaTime);

        Vector3 velocity = (_lastPosition - currentBall.transform.position) * Time.deltaTime;
        _lastPosition = currentBall.transform.position;
        currentBall.GetComponent<Rigidbody>().velocity = velocity;
    }

    public void RightByTouch()
    {
        Debug.Log("Right");
        Vector3 direction = Vector3.right;

        GameObject currentBall = GameManager.instance.GetBallOnScene();
        currentBall.transform.Translate(direction * leftRightTouchCoef * Time.deltaTime);

        Vector3 velocity = (_lastPosition - currentBall.transform.position) * Time.deltaTime;
        _lastPosition = currentBall.transform.position;
        currentBall.GetComponent<Rigidbody>().velocity = velocity;
    }

    public void LeftRight()
    {
        Debug.Log("LeftRight");
        Debug.Log(Input.acceleration.x);
        GameObject currentBall = GameManager.instance.GetBallOnScene();
        Vector3 direction = new Vector3(Input.acceleration.x, 0, 0);
        currentBall.transform.Translate(direction * leftRightAccelerometerCoef * Time.deltaTime);

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
