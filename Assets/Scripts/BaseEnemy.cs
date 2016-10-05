using UnityEngine;
using System.Collections;

public class BaseEnemy : Ship {
    public bool emptyX; //If the ship is at an x position where it can turn through the asteroids
    public bool emptyY; //If the ship is at a y position where it can turn through the asteroids
    public bool evenX; //if the integer portion of the x value of the transform is even
    public bool evenY; //if the integer portion of the y value of the transform is even
    public bool evenXY;
    public bool canTurnX;
    public bool canTurnY;
    public bool atLeftEdge;
    public bool atRightEdge;
    public bool atTopEdge;
    public bool atBottomEdge;
    public bool movingHorizontal;
    public bool onTrigger;
    public float ignorePathTime;
    public bool isHorizontal;
    public bool onHorizontal;
    public bool onVertical;

    // Use this for initialization
    void Start() {
        pointValue = 100;
        health = 1;
    }

    void Update()
    {
        /*The below section will handle pathfinding
        The ship is always centered on foo.5 of the axis it's not traveling on
        The ship can turn once it's at bar.5 of both axes
        The ship should only turn when the integer portion of x or y is even
        The ship cannot normally reverse, except in a collision with another enemy ship, handled in OnCollision2D below
        */
        /*emptyX = (transform.position.y - System.Math.Floor(transform.position.y) >= .45f && transform.position.y - System.Math.Floor(transform.position.y) <= .55f); // negative problem?
        emptyY = (transform.position.x - System.Math.Floor(transform.position.x) >= .45f && transform.position.x - System.Math.Floor(transform.position.x) <= .55f);

        evenX = (System.Math.Floor(transform.position.x) % 2 == 0);
        evenY = (System.Math.Floor(transform.position.y) % 2 == 0);
        //evenXY = (System.Math.Floor(transform.position.y) % 2 == 0 && System.Math.Floor(transform.position.y) % 2 == 0);
        evenXY = (System.Math.Floor(transform.position.x) % 2 == 0 && System.Math.Ceiling(transform.position.y) % 2 == 0);

        canTurnX = (emptyX && evenXY);
        canTurnY = (emptyY && evenXY);
        */
        //Since it's centered at foo.5 and the board goes from 0-21, 0.5 and 20.5 are the farthest the ship can go in either direction
        if(ignorePathTime >= 0)
        {
            ignorePathTime -= Time.deltaTime;
        }
        else
        {
            gameObject.layer = 0;
        }
        atLeftEdge = (transform.position.x <= 0.5f);
        atRightEdge = (transform.position.x >= 20.5f);
        atTopEdge = (transform.position.y >= -.5f);
        atBottomEdge = (transform.position.y <= -20.5f);

        // Shouldn't need this? movingHorizontal = (System.Math.Abs(transform.rotation.z) == 90); //true if the ship is horizontal, as left is 90 degrees and right is -90
        /*if (emptyX || emptyY)
        {
            var directionChoice = Random.Range(0, 7);
            /******************************************************
            *******************************************************
            ****!!!!!CHANGE TO USE rigidBody2D.MovePosition!!!!****
            *******************************************************
            ******************************************************/
            /*switch (directionChoice)
            {
                //The ship turns 1/4 of the time, since cases 0-3 do nothing, the reverse direction fails, and the same direction doesn't turn
                //When the ship turns, it gets placed onto the .5 line
                case 0:
                case 1:
                case 2:
                case 3:
                    break;
                case 4: //turn up
                    if (transform.eulerAngles != (new Vector3(0, 0, 180)) && !atTopEdge && canTurnY/*emptyY && evenY)
                    {
                        transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) + .5f, transform.position.z);
                        transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    break;
                case 5: //turn down
                    if (transform.rotation != Quaternion.Euler(0, 0, 0) && !atBottomEdge && canTurnY/*emptyY && evenY)
                    {
                        transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) + .5f, transform.position.z);
                        transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    break;
                case 6: //turn left
                    if (transform.rotation != Quaternion.Euler(0, 0, -90) && !atLeftEdge && canTurnX/*emptyX && evenX)
                    {
                        transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) + .5f, transform.position.z);
                        //transform.rotation = Quaternion.Euler(0, 0, 90);
                        //transform.RotateAround( Vector3.forward, 90);
                        transform.Rotate(new Vector3(0, 0, 90));
                    }
                    break;
                case 7: //turn right
                    if (transform.rotation != Quaternion.Euler(0, 0, 90) && !atRightEdge && canTurnX/*emptyX && evenX)
                    {
                        transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) + .5f, transform.position.z);
                        //transform.rotation = Quaternion.Euler(0, 0, -90);
                        transform.Rotate(new Vector3(0, 0, -90));
                    }
                    break;
            }
        }
        
        /*var LeftCast = Physics2D.CircleCast(transform.position + (transform.right * -1), .45f, transform.position); //This checks whether there is anything to the left
        var RightCast = Physics2D.CircleCast(transform.position + (transform.right), .45f, transform.position); //This checks whether there is anything to the right
        var directionChoice = Random.Range(0, 6) % 6; //This will undergo random modulus division to determine whether it turns right, left, or heads straight.
        switch (directionChoice)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                break;
            case 4:
                if (LeftCast.collider == null)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 270);
                }
                break;
            case 5:
                if (RightCast.collider == null)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 90);
                }
                break;
        }*/
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("PlayerShot"))
        {
            health--;
        }
        else if(collision.collider.CompareTag("Enemy")) //&& Physics2D.Raycast(transform.position, transform.forward, 1.0f))
        {
            transform.localRotation = Quaternion.Inverse(transform.localRotation); //makes the enemy ship going head-first into the other ship reverse
            transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) + .5f, transform.position.z);
        }
        else if(Physics2D.Raycast(transform.position, transform.forward, 1.0f))
        {
            //needs to be rotated off of player's direction, rather than globally.
            if(Random.Range(0, 1) == 1) //gives a random chance of turning left or right on impact with a wall.
            {
                transform.RotateAround(transform.position, Vector3.forward, 90);
                transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor (transform.position.y) - .5f, transform.position.z);
            }
            else
            {
                transform.RotateAround(transform.position, Vector3.forward, -90);
                transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Floor(transform.position.y) - .5f, transform.position.z);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        onTrigger = true;
        var directionChoice = Random.Range(0, 7);
        var isHorizontal = (collider.transform.rotation.z == 0); //the path is by default stretched along the X axis
        /******************************************************
        *******************************************************
        ****!!!!!CHANGE TO USE rigidBody2D.MovePosition!!!!****
        *******************************************************
        ******************************************************/
        switch (directionChoice)
        {
            //The ship turns 1/4 of the time, since cases 0-3 do nothing, the reverse direction fails, and the same direction doesn't turn
            //When the ship turns, it gets placed onto the .5 line
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                break;
            case 6: //turn left or up
                if (isHorizontal && !atLeftEdge)
                {
                    transform.Rotate(new Vector3(0, 0, 90), Space.World);
                }
                else if (!atTopEdge)
                {
                    transform.Rotate(new Vector3(0, 0, 0), Space.World);
                }
                //IgnorePath();
                break;
            case 7: //turn right or down
                if (isHorizontal && !atRightEdge)
                {
                    transform.Rotate(new Vector3(0, 0, -90), Space.World);
                }
                else if (!atBottomEdge)
                {
                    transform.Rotate(new Vector3(0, 0, 180), Space.World);
                }
                //IgnorePath();
                break;
        }
    }

    private void IgnorePath()
    {
        ignorePathTime = 5;
        gameObject.layer = 9;
    }

    public void OnTriggerStay2D(Collider2D collider)
    {
        onHorizontal = (collider.gameObject.transform.rotation.eulerAngles.z == 0);
        onVertical = (collider.gameObject.transform.rotation.eulerAngles.z == 90);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
    }
}
/*void OnCollisionStay2D(Collision2D collision)
{
    if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("PlayerShot"))
    {
        health--;
    }
    else if(collision.collider.CompareTag("Enemy") && Physics2D.Raycast(transform.position, transform.forward, 1.0f))
    {
        transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Ceiling(transform.position.y) - .5f, transform.position.z);
        transform.localRotation = Quaternion.Inverse(transform.localRotation); //makes the enemy ship going head-first into the other ship reverse

    }
    else if(Physics2D.Raycast(transform.position, transform.forward, 1.0f))
    {
        if(Random.Range(0, 1) == 1) //gives a random chance of turning left or right on impact with a wall.
        {
            transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Ceiling(transform.position.y) - .5f, transform.position.z);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else
        {
            transform.position.Set((float)System.Math.Floor(transform.position.x) + .5f, (float)System.Math.Ceiling(transform.position.y) - .5f, transform.position.z);
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
    }
}*/
