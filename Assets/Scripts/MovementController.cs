using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Rigidbody2D playerRB { get; private set; }
    private Vector2 direction = Vector2.up;
    public float speed = 2000f; //5f;
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;
    public bool hasReachedGoal = false;
    public GameObject goalObject;

    // Hand pose controllers:
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
        setDirection(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReachedGoal)
        {
            if (Input.GetKey(inputUp))
            {
                setDirection(Vector2.up);
            }
            else if (Input.GetKey(inputDown))
            {
                setDirection(Vector2.down);
            }
            else if (Input.GetKey(inputRight))
            {
                setDirection(Vector2.right);
            }
            else if (Input.GetKey(inputLeft))
            {
                setDirection(Vector2.left);
            }
            else
            {
                //setDirection(Vector2.zero);
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

    public void setDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }

    void FixedUpdate()
    {
        Vector2 position = playerRB.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        playerRB.MovePosition(position + translation);
        //playerRB.velocity = direction * speed;
    }

    public void poseUP()
    {
        isHandUp = true;
        Debug.Log("Hands UP!");
        setDirection(Vector2.up);
    }
    public void poseDown()
    {
        isHandDown = true;
        Debug.Log("Hands Down!");
        setDirection(Vector2.down);
    }
    public void poseRight()
    {
        isHandRight = true;
        Debug.Log("Hands UP!");
        setDirection(Vector2.right);
    }
    public void poseLeft()
    {
        isHandLeft = true;
        Debug.Log("Hands Down!");
        setDirection(Vector2.left);
    }
}

