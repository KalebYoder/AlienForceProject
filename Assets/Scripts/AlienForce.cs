using UnityEngine;
using System.Collections;

public class AlienForce : MonoBehaviour {

    public GameObject Asteroid;
    public ArrayList AsteroidList = new ArrayList();
    int levelNum;
    public GameObject PlayerShip;
    PlayerShip Player;
    int levelDisplay;
    public GameObject EnemyShip;
    public ArrayList EnemyList = new ArrayList();

	// Use this for initialization
	void Start () {
        levelDisplay = 0;
        for (float x = 1.5f; x < 21.0f; x+=2.0f) //tried floats ending in .5, now trying integers
        {
            for (float y = -1.5f; y > -21.0f; y-=2.0f)
            {
                //Asteroid myAsteroid = (Asteroid)Instantiate(newAsteroid, Coordinates, Quaternion.identity);
                //Debug.Log(newAsteroid.transform);
                //Asteroid newAsteroid = (Asteroid)Instantiate(Asteroid, new Vector3(x, y, 0), Quaternion.identity);
                AsteroidList.Add(Instantiate(Asteroid, new Vector3(x, y, 0f), Quaternion.identity));
            }
        }
        GameObject Player = (GameObject)Instantiate(PlayerShip, new Vector3(20.5f, -20.5f, 0f), Quaternion.identity);
        for (float x = .5f; x < 21f; x += 2.0f)
        {
            EnemyList.Add(Instantiate(EnemyShip, new Vector3(x, -.5f, 0f), Quaternion.identity));
        }
        //define level text outside of this method
        //define lives outside of this method
        //displayLives(3);
        //define LevelNum outside this method
        levelNum = 0;
        //StartLevel();
    }

    // Update is called once per frame
    /*void update()
    {
        if (EnemyList.Count == 0)
        {
            //StartLevel();
        }
        //Need condition for dead player
        if (Input.GetKeyDown("space"))
        {
            if (!(Player.isDead || Player.shotExists))
            {
                Player.Fire();
            }
            else
            {
                Player.Spawn();
            }
        }
        else if (Input.GetKeyDown("up"))
        {
            Player.Direction = Vector2.up;
        }
        else if (Input.GetKeyDown("down"))
        {
            Player.Direction = Vector2.down;
        }
        else if (Input.GetKeyDown("left"))
        {
            Player.Direction = Vector2.left;
        }
        else if (Input.GetKeyDown("right"))
        {
            Player.Direction = Vector2.right;
        }
    }*/

    /*private void StartLevel()
    {
        Time.timeScale = 0; //pause game until space is hit
        levelDisplay++;
        Player.transform.position = new Vector2(21, -21);
        for (int x = 0; x <= 21; x += 2)
        {
            EnemyList.Add(Instantiate(BaseEnemy, new Vector2(x, 0), Quaternion.identity));
        }
        //put "Press space to start" on screen
        while (!Input.GetKeyDown("Space"))
        {
            //Waiting for player to hit space before starting the level
        }
        Time.timeScale = 1;
    }*/

    public void ShipCollision(BaseEnemy EnemyShip1, BaseEnemy EnemyShip2)
    {
        //if(Raycast(EnemyShip1.transform, EnemyShip1.Direction, 1.0f)
        //ship facing colliding ship reverses direction for at least three units
    }
}
