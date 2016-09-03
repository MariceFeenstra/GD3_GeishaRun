using UnityEngine;
using System.Collections;

public class TouchControlScript : MonoBehaviour {

    public PlayerScript playerScript;
    public Vector2 startPos;
    public Vector2 direction;
    bool directionChosen;
    
	// Use this for initialization
	void Start () {
        directionChosen = false;
	}
	
	// Update is called once per frame
	void Update () {


        AlternateControls();
        TouchControls();
	}

    void TouchControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;
                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }


        if(directionChosen)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y * -.5f))
            {
                if (direction.x > 0)
                {
                    playerScript.recievedInput(SwipeDirection.RIGHT);
                }
                else
                {
                    playerScript.recievedInput(SwipeDirection.LEFT);
                }
            } 
            if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x * -.5f))
            {
                if (direction.y > 0)
                {
                    playerScript.recievedInput(SwipeDirection.UP);
                }
                else
                {
                    playerScript.recievedInput(SwipeDirection.DOWN);
                }
            }
            directionChosen = false;
        }




    }

    void AlternateControls()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerScript.recievedInput(SwipeDirection.UP);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerScript.recievedInput(SwipeDirection.RIGHT);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerScript.recievedInput(SwipeDirection.DOWN);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerScript.recievedInput(SwipeDirection.LEFT);
        } 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("LetsPressSpace");
            WorldScript.Instance.worldGeneratorScript.SpawnObject();
        }
    }

}
