using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Vector3 movePosition;
    public float moveSpeed = 8f;
    public float smoothSpeed = 0.125f;

    //  Character rotation values
    //float rotationSpeed = 120f;
    Quaternion desiredRotation;

    float timeBetweenTicks = 0f;
    bool doubleClick = false;
    public float dashDistance = 120f;
    bool dashDelay = false;

    //  Variables to check double-tap
    int upCount = 0;
    int downCount = 0;
    int leftCount = 0;
    int rightCount = 0;

    //float dashTime = 0f;
    //float dashSpeed = 30f;

    float jumpVelocity = -2f;
    public float gravity = 30f;

    public CharacterController controller;
    public Animator animator;


    //  Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    //  Update is called once per frame
    void Update()
    {
        //Checking double tap for dash
        doubleClick = false;

        if (Input.anyKeyDown)
        {
            CheckDoubleTap();
        }

        timeBetweenTicks = Time.time;

        //  Getting player input Vectors and adding to new position
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //Check for player input to enable animations
        if (inputX != 0 || inputZ != 0)
        {
            animator.SetInteger("isMoving", 1);
        } else
        {
            animator.SetInteger("isMoving", 0);
        }

        float moveX = inputX * moveSpeed * Time.deltaTime;
        float moveZ = inputZ * moveSpeed * Time.deltaTime;
        movePosition = new Vector3(moveX, 0f, moveZ);

        //  Checking if on ground for jumping/velocity
        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            jumpVelocity = 10f;
        }
        else if (controller.isGrounded)
        {
            jumpVelocity = -2f;
        }
        else
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }

        movePosition.y = jumpVelocity * Time.deltaTime;

        //  Adjusting rotation of character to match direction of movement (Broken)
        desiredRotation = Quaternion.LookRotation(movePosition);
        desiredRotation.x = 0f;
        desiredRotation.z = 0f;
        if (controller.velocity.x != 0f || controller.velocity.z != 0f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothSpeed);
        }

        //  Dash or normal movement
        if (doubleClick && !dashDelay && controller.isGrounded)
        {
            Dash();
        }
        else
        {
            controller.Move(movePosition);
        }
        //if (dashTime >= 0)
        //{
        //    dashTime -= Time.deltaTime;
        //    controller.Move(movePosition * dashSpeed);

        //}
        //else
        //{
        //    controller.Move(movePosition);
        //}

        //controller.Move(movePosition);
    }

    private IEnumerator OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag != "Ground")
        {
            Debug.Log("Collided with: " + hit.gameObject.name);
        }

        //if (hit.collider.name == "DeathPlane")
        //{
        //    transform.position = lastPosition;
        //}

        if (hit.collider.name == "EnemyMesh(Cube)")
        {
            //Vector3 dir = (hit.point - transform.position).normalized;
            //Debug.Log(dir + ", " + -dir);
            //while(Vector3.Distance(hit.point, transform.position) < Vector3.Distance(hit.point, dir))
            //{
            //    Debug.Log("Still in loop.");
            //    Vector3 desiredPosition = Vector3.Lerp(transform.position, dir, 0.25f);
            //    controller.Move(desiredPosition);
            //    yield return null;
            //}

        }
        else
        {
            yield return null;
        }
    }

    // Adjust to work over set period (lerp?)
    private void Dash()
    {
        //controller.height = 1;
        //controller.center = new Vector3(0,0,0);

        //if (upCount > 1)
        //{
        //    movePosition.z += dashDistance * Time.deltaTime;
        //    upCount = 0;
        //}
        //else if (downCount > 1)
        //{
        //    movePosition.z -= dashDistance * Time.deltaTime;
        //    downCount = 0;
        //}
        //else if (leftCount > 1)
        //{
        //    movePosition.x -= dashDistance * Time.deltaTime;
        //    leftCount = 0;
        //}
        //else if (rightCount > 1)
        //{
        //    movePosition.x += dashDistance * Time.deltaTime;
        //    rightCount = 0;
        //}

        //controller.Move(movePosition);

        //controller.height = 3;
        //controller.center = new Vector3(0, 1, 0);

        //DashWait();
    }

    //  Wait time before dash can be used again (not working?)
    private IEnumerator DashWait()
    {
        Debug.Log("Waiting for delay...");
        dashDelay = true;
        yield return new WaitForSeconds(3f);
        dashDelay = false;
        
    }

    //  Checking for double key press
    private void CheckDoubleTap()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("w"))
        {
            downCount = 0;
            leftCount = 0;
            rightCount = 0;

            if (upCount > 0)
            {
                if (Time.time < timeBetweenTicks + 0.2f && timeBetweenTicks != 0)
                {
                    doubleClick = true;
                    upCount++;
                }
                else
                {
                    upCount = 0;
                }
            }
            else if (upCount == 0)
            {
                upCount++;
            }
        }
        else if (Input.GetKeyDown("down") || Input.GetKeyDown("s"))
        {
            upCount = 0;
            leftCount = 0;
            rightCount = 0;

            if (downCount > 0)
            {
                if (Time.time < timeBetweenTicks + 0.2f && timeBetweenTicks != 0)
                {
                    doubleClick = true;
                    downCount++;
                }
                else
                {
                    downCount = 0;
                }
            }
            else if (downCount == 0)
            {
                downCount++;
            }
        }
        else if (Input.GetKeyDown("left") || Input.GetKeyDown("a"))
        {
            upCount = 0;
            downCount = 0;
            rightCount = 0;

            if (leftCount > 0)
            {
                if (Time.time < timeBetweenTicks + 0.2f && timeBetweenTicks != 0)
                {
                    doubleClick = true;
                    leftCount++;
                }
                else
                {
                    leftCount = 0;
                }
            }
            else if (leftCount == 0)
            {
                leftCount++;
            }
        }
        if (Input.GetKeyDown("right") || Input.GetKeyDown("d"))
        {
            upCount = 0;
            downCount = 0;
            leftCount = 0;

            if (rightCount > 0)
            {
                if (Time.time < timeBetweenTicks + 0.2f && timeBetweenTicks != 0)
                {
                    doubleClick = true;
                    rightCount++;
                }
                else
                {
                    rightCount = 0;
                }
            }
            else if (rightCount == 0)
            {
                rightCount++;
            }
        }
    }

    //private IEnumerator RotateCharacter(Quaternion start, Quaternion end)
    //{


    //    yield return null;
    //}
}
