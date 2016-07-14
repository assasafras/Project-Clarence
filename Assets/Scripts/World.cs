using UnityEngine;
using System.Collections;
using System;

public class World : MonoBehaviour {

    public float RotateSpeed = 100f;
    public bool canRotate = true;
    public Vector3 targetRotation;
    private float targetX;
    public float currentX, previousX;
    public float rotateVelocity;
    public bool rotateRight, rotateLeft;
    public Animator ac;
    private BasicBitchPlayer player;
    public static World current;

    public enum InputMethod
    {
        touch
        , keyboard
        , gamepad
    }

    // Use this for initialization
    void Awake ()
    {
        World.current = this;
        ac = gameObject.GetComponent<Animator>();
        player = GameObject.Find("BasicPlayer").GetComponent<BasicBitchPlayer>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameState.IsPaused)
        {
            //if(!rotateLeft && !rotateRight)
            //{
            //    var roundedX = Mathf.Round(transform.eulerAngles.x / 30) * 30;
            //    var differenceX = roundedX - transform.eulerAngles.x;
            //    if (differenceX != 0)
            //        print("Difference:" + differenceX);
            //    transform.Rotate(differenceX, 0, 0);
            //}

            // Keyboard input.
            float hrzntl;
            hrzntl = Input.GetAxisRaw("Horizontal");

            // Touch input.
            //hrzntl = ProcessTouch();

            //// Mouse input.
            //if(Input.GetMouseButtonDown(0))
            //{
            //    if (Input.mousePosition.x > (Screen.width * 0.5))
            //    {
            //        hrzntl = 1;
            //    }
            //    else
            //    {
            //        hrzntl = -1;
            //    }
            //}

            //if (hrzntl == 1)
            //    ac.Play("RotateRight");
            ////rotateLeft = true;
            //else if (hrzntl == -1)
            //    ac.Play("RotateLeft");

            //print("--------------------------------------------------");
            //print("Update called on World!");
            if (hrzntl != 0) // there is some input
            {
                SnapRotateWorld(hrzntl);
                //RotateWorld(hrzntl);
            }
            //else // no input.
            //{
            //    //print("canRotate to True - Horizontal input: " + hrzntl);
            //    //canRotate = true;
            //    //SnapToLane();
            //}

            //transform.Rotate(Vector3.Lerp(transform.rotation.eulerAngles, targetRotation, 8 * Time.deltaTime));

            if (targetX > 0)
            {
                //print("targetX is greater than 0: " + targetX + ", so we will rotate by " + rotateVelocity);
                var currentX = this.transform.rotation.eulerAngles.x;
                var previousX = currentX;
                //print("Current X: " + currentX);
                this.transform.Rotate(rotateVelocity, 0, 0);
                targetX -= Mathf.Abs(rotateVelocity);
                //print("targetX is now " + targetX + " and current X is now " + this.transform.rotation.eulerAngles.x);
                if (targetX <= 0)
                {
                    //print("targetX(" + targetX + ") is now less than or equal to 0!");
                    if ((rotateRight && (currentX < previousX)) || (rotateLeft && (currentX > previousX)))
                        //then we've gone over the 360 degree mark, we want to invert the remaining targetX.
                        targetX *= -1;
                    if (rotateLeft)
                        targetX *= -1;
                    //print("Rotating on the x axis("+ this.transform.rotation.eulerAngles.x  + ") by an adjusted targetX's value: "+ -targetX);
                    this.transform.Rotate(-targetX, 0, 0);
                    //print("Final value: " + this.transform.rotation.eulerAngles.x + "");
                    targetX = 0;
                }
            }
            else
            {
                canRotate = true;
                rotateRight = false;
                rotateLeft = false;
            }
            //print("Before Slerp: " + transform.rotation);
            //transform.rotation = Quaternion.Slerp(targetRotation, transform.rotation, Time.deltaTime * 8);

            //print("After Slerp: " + transform.rotation);

            //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x + 1, 0f, 0f));

            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 8);

            //currentX = Mathf.Round(transform.rotation.eulerAngles.x);

            //if(currentX != previousX)
            //    print("currentX: " + currentX);

            //previousX = currentX;

            //if(transform.rotation == targetRotation)
            //{
            //    canRotate = true;
            //}
            //if (currentX != targetX)
            //{
            //    // Rotate towards target.
            //    this.transform.Rotate(rotateVelocity, 0, 0);
            //}
            //else
            //{
            //    //var eulers = transform.rotation.eulerAngles;
            //    //transform.rotation = Quaternion.Euler(Mathf.Round(eulers.x)
            //    //transform.rotation = targetRotation;
            //    canRotate = true;
            //}

        }
    }

    private static float ProcessTouch()
    {
        int hrzntl = 0;
        for (var i = 0; i < Input.touchCount; ++i)
        {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began)
            {
                // Need to put .x
                if (touch.position.x > (Screen.width * 0.5))
                {
                    hrzntl = 1;
                }
                else
                {
                    hrzntl = -1;
                }
            }
        }

        return hrzntl;
    }

    public void RotateUp()
    {
        SnapRotateWorld(1f);
    }

    public void RotateDown()
    {
        SnapRotateWorld(-1f);
    }

    private void SnapRotateWorld(float horizontalInput)
    {
        if (canRotate && !GameState.IsPaused)
        {
            canRotate = false;
            if (horizontalInput > 0)
                rotateRight = true;
            else
                rotateLeft = true;

            targetX = 30f;
            rotateVelocity = Mathf.Sign(horizontalInput) * -player.TurnSpeed;
        }
    }

    private void RotateWorld(float amount)
    {
        float rtSpd = -(amount * RotateSpeed) * Time.deltaTime;
        this.transform.Rotate(rtSpd, 0, 0);
    }

    private void SnapToLane()
    {
        float currX = transform.rotation.eulerAngles.x;
        int subAngle, superAngle;
        float newAngle;
        subAngle = Mathf.FloorToInt(currX % 30 - 15) < 0 ? 0 : 30;
        superAngle = Mathf.FloorToInt(currX / 30) * 30;
        newAngle = superAngle + subAngle;
        print("current angle: " + this.transform.eulerAngles.x + "new angle: " + newAngle);
        this.transform.eulerAngles = new Vector3(newAngle, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        print("After setting angle: " + this.transform.eulerAngles.x);
    }
}
