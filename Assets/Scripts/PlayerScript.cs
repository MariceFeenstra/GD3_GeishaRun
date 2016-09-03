using UnityEngine;
using System.Collections;

public enum RoadLane
{
    LEFT = 0,
    MIDDLE = 1,
    RIGHT = 2
}

public enum SwipeDirection
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}



public class PlayerScript : MonoBehaviour {

    RoadLane currentPlayerLane;
    RoadLane previousPlayerLane;

    bool inJump;
    float jumpTimer;
    float maxJumpTime;

    bool ducking;
    float duckTimer;
    float maxDuckTime;

	// Use this for initialization
	void Start () {
        currentPlayerLane = RoadLane.MIDDLE;
        transform.position = new Vector3(0, 0.75f, 0);


        inJump = false;
        jumpTimer = 0.0f;
        maxJumpTime = 0.8f;

        ducking = false;
        duckTimer = 0.0f;
        maxDuckTime = 0.8f;
	}
	
	// Update is called once per frame
	void Update () {


        Jump();
        Duck();
        MoveToLane();
	}

    void MoveToLane()
    {
        float xPos, yPos, zPos;

        xPos = 0;
        yPos = 0.75f;
        zPos = transform.position.z;

        if (inJump) yPos = 1.75f;
        else if (ducking) yPos = 0.25f;
        

        if (previousPlayerLane != currentPlayerLane)
        {
            switch (currentPlayerLane)
            {
                case RoadLane.LEFT:
                    zPos = -1.5f;
                    break;
                case RoadLane.MIDDLE:
                    zPos = 0;
                    break;
                case RoadLane.RIGHT:
                    zPos = 1.5f;
                    break;
            }
            previousPlayerLane = currentPlayerLane;
        }


        transform.position = new Vector3(xPos, yPos, zPos);
    }

    public void recievedInput(SwipeDirection direction)
    {
        switch(direction)
        {
            case SwipeDirection.UP:
                if (ducking)
                {
                    ducking = false;
                }
                else
                {
                    if (!inJump)
                    {
                        inJump = true;
                        jumpTimer = maxJumpTime;
                    }
                }
                break;
            case SwipeDirection.RIGHT:
                currentPlayerLane++;
                break;
            case SwipeDirection.DOWN:
                if (inJump)
                {
                    inJump = false;
                }
                else
                {
                    if (!ducking)
                    {
                        ducking = true;
                        duckTimer = maxDuckTime;
                    }
                }
                break;
            case SwipeDirection.LEFT:
                currentPlayerLane--;
                break;
        }
        if ((int)currentPlayerLane > 2) currentPlayerLane = RoadLane.RIGHT;
        if ((int)currentPlayerLane < 0) currentPlayerLane = RoadLane.LEFT;

    }


    void Jump()
    {
        if(inJump)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0) inJump = false;
        }
    }

    void Duck()
    {
        if(ducking)
        {
            duckTimer -= Time.deltaTime;
            if(duckTimer <= 0) ducking = false;
        }


    }





}
