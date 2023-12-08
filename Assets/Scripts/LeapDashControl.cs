using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapDashControl : MonoBehaviour
{
    enum Direction
    {
        North, South, East, West, Center
    }

    public float speed = 3000;
    public Rigidbody2D playerRB;
    Direction direction;
    public bool hasReachedGoal = false;
    public GameObject goalObject;
     private bool isHandUp = false;
    private bool isHandDown = false;
    private bool isHandRight = false;
    private bool isHandLeft = false;
    void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //playerRB.velocity = Vector2.zero;
        direction = Direction.Center;
    }

    void Update()
    {
        //The GetAxis page describes in detail what the axisName for GetAxisRaw means. 
        //For example the Horizontal axis is managed by Left and Right, and a and d keys
        if (!hasReachedGoal)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionY;

                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    direction = Direction.East;
                }
                else
                {
                    direction = Direction.West;
                }

            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;

                if (Input.GetAxisRaw("Vertical") == 1)
                {
                    direction = Direction.North;
                }
                else
                {
                    direction = Direction.South;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Goal"))
        {
            hasReachedGoal = true;
        }
    }
    void FixedUpdate()
    {
        switch (direction)
        {
            case Direction.North:
                playerRB.velocity = new Vector2(0, speed * Time.fixedDeltaTime);
                break;
            case Direction.South:
                playerRB.velocity = new Vector2(0, -speed * Time.fixedDeltaTime);
                break;
            case Direction.East:
                playerRB.velocity = new Vector2(speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.West:
                playerRB.velocity = new Vector2(-speed * Time.fixedDeltaTime, 0);
                break;
            case Direction.Center:
                playerRB.velocity = Vector2.zero;
                break;
        }
    }

    public void poseUP()
    {
        isHandUp = true;
        direction = Direction.North;
    }
    public void poseDown()
    {
        isHandDown = true;
        direction = Direction.South;
    }
    public void poseRight()
    {
        isHandRight = true;
        Debug.Log("Hands Right!");
        direction = Direction.East;
    }
    public void poseLeft()
    {
        isHandLeft = true;
        Debug.Log("Hands Left!");
        direction = Direction.West;
    }
    public void stayStill()
    {
        Debug.Log("Idel");
        direction = Direction.Center;
    }
}
