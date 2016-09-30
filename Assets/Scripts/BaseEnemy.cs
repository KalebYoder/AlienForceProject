using UnityEngine;
using System.Collections;

public class BaseEnemy : Ship {
    bool emptyX; //If the ship is at an x position where it can turn through the asteroids. This also makes the enemy ships all line up perfectly in the middle of the paths.
    bool emptyY; //If the ship is at a y position where it can turn through the asteroids. This also makes the enemy ships all line up perfectly in the middle of the paths.
    bool atLeftEdge;
    bool atRightEdge;
    bool atTopEdge;
    bool atBottomEdge;
    // Use this for initialization
    void Start() {
        pointValue = 100;
        health = 1;
    }

    void Update()
    {
        //The below section will handle pathfinding
        if(transform.position.x - (int)transform.position.x == .5f)
        {
            emptyX = true;
        }
        if(transform.position.y - (int)transform.position.y == .5f)
        {
            emptyY = true;
        }
        if(transform.position.x == 0.5f)
        {
            atLeftEdge = true;
        }
        if(transform.position.x == 20.5f)
        {
            atRightEdge = true;
        }
        if(transform.position.y == -.5f)
        {
            atTopEdge = true;
        }
        if(transform.position.y == -20.5f)
        {
            atBottomEdge = true;
        }

        //If they are moving horizontally, they can only turn vertically, and vice versa

        if()
        
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
        else if(collision.collider.CompareTag("Enemy") && Physics2D.Raycast(transform.position, transform.forward, 1.0f)) //makes the enemy ship running into the other reverse
        {
            transform.localRotation = Quaternion.Inverse(transform.localRotation);
        }
        else if(Physics2D.Raycast(transform.position, transform.forward, 1.0f))
        {
            if(Random.Range(0, 2) == 1) //gives a random chance of turning left or right on impact with a wall or asteroid, although asteroid collision shouldn't happen
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 270);
            }
        }
    }
}
