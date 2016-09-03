using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjectPoolNamespace;

public class StaticObjectBehaviourScript : MonoBehaviour {

    WorldGeneratorScript worldGeneratorScript;
    public float Size;
    float RoadStartDistance;

    Transform objectTransform;

    public RoadLane lanePosition;

	// Use this for initialization
	void Start () 
    {
        worldGeneratorScript = WorldScript.Instance.worldGeneratorScript;

        RoadStartDistance = worldGeneratorScript.RoadStartDistance;
        objectTransform = transform;

	}
	
	// Update is called once per frame
	void Update () {
        Move();
        SelfDestruct();

	}

    void Move()
    {
        Vector3 newPos = objectTransform.position;
        newPos.x += 8 * Time.deltaTime;
        newPos.y = 0.75f;
        switch(lanePosition)
        {
            case RoadLane.LEFT:
                newPos.z = -1.5f;
                break;
            case RoadLane.RIGHT:
                newPos.z = 1.5f;
                break;
            case RoadLane.MIDDLE:
            default:
                newPos.z = 0;
                break;
                
        }

        //objectTransform.Translate(8 * Vector3.right * Time.deltaTime);
        objectTransform.position = newPos;
    }

    void SelfDestruct()
    {

        if (transform.position.x > 10)
        {
            ObjectPool.GivebackObject(gameObject);
        }

    }
}
