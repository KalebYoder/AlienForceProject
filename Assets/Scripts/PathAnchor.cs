using UnityEngine;
using System.Collections;

public class PathAnchor : MonoBehaviour {

    public bool atLeftEdge;
    public bool atRightEdge;
    public bool atTopEdge;
    public bool atBottomEdge;
    public bool isHorizontal;
    public BaseEnemy ParentShip {get; set;}
    Transform ParentTransform;
    // Use this for initialization
    void Start () {
        transform.parent = ParentShip.transform;
	}
	
	// Update is called once per frame
	void Update () {
        atLeftEdge = (transform.position.x <= 0.5f);
        atRightEdge = (transform.position.x >= 20.5f);
        atTopEdge = (transform.position.y >= -.5f);
        atBottomEdge = (transform.position.y <= -20.5f);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        var directionChoice = Random.Range(0, 8);
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
                if (isHorizontal && !atLeftEdge && transform.rotation.eulerAngles != new Vector3(0, 0, 90))
                {
                    ParentShip.transform.Rotate(new Vector3(0, 0, -90), Space.World);
                }
                else if (!atTopEdge && transform.rotation.eulerAngles != new Vector3(0, 0, 0))
                {
                    ParentShip.transform.Rotate(new Vector3(0, 0, 180), Space.World);
                }
                //IgnorePath();
                break;
            case 7: //turn right or down
                if (isHorizontal && !atRightEdge && transform.rotation.eulerAngles != new Vector3(0, 0, -90))
                {
                    ParentShip.transform.Rotate(new Vector3(0, 0, 90), Space.World);
                }
                else if (!atBottomEdge && transform.rotation.eulerAngles != new Vector3(0, 0, 180))
                {
                    ParentShip.transform.Rotate(new Vector3(0, 0, 0), Space.World);
                }
                //IgnorePath();
                break;
        }
    }

    /*private void IgnorePath()
    {
        ignorePathTime = 5;
        gameObject.layer = 9;
    }*/

    /*public void OnTriggerStay2D(Collider2D collider)
    {
        onHorizontal = (collider.gameObject.transform.rotation.eulerAngles.z == 0);
        onVertical = (collider.gameObject.transform.rotation.eulerAngles.z == 90);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collider);
    }*/
}
