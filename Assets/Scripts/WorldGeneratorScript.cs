using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.ObjectPoolNamespace;


public class WorldGeneratorScript : MonoBehaviour {

    public GameObject Ground1;
    public int Size;
    public float RoadStartDistance;
    

	// Use this for initialization
	void Start () {

        RoadStartDistance = -32;
        PreGeneration();
	}
	
	// Update is called once per frame
	void Update () {


	}

    public GameObject CreateRoad(Vector3 newRoadPosition)
    {
        GameObject Road = ObjectPool.GetNextObject(ObjectPoolTypes.DefaultTile);
        Road.transform.position = newRoadPosition;

        StraightRoadBehaviourScript newRoadScript = Road.GetComponent<StraightRoadBehaviourScript>();
        newRoadScript.worldGeneratorScript = this;
        newRoadScript.newRoadIsAvailable = true;
        return Road;
    }

    public void CreateRoad()
    {
        CreateRoad(new Vector3(RoadStartDistance, 0, 0));
    }

    public GameObject SpawnObject()
    {
        Debug.Log("Oh my, Spawning Time already?");
        System.Random rand = new System.Random();
        RoadLane lane = (RoadLane)rand.Next(0, 3);
        GameObject spawnedObject = SpawnObject(lane);
        return spawnedObject;
    }

    public GameObject SpawnObject(RoadLane lanePosition)
    {
        Debug.Log("Spawn that thing.");
        GameObject SpawnedObject = ObjectPool.GetNextObject(ObjectPoolTypes.StaticObject);
        SpawnedObject.transform.position = new Vector3(RoadStartDistance, -10, 0);

        StaticObjectBehaviourScript objectScript = SpawnedObject.GetComponent<StaticObjectBehaviourScript>();
        objectScript.lanePosition = lanePosition;

        return SpawnedObject;
    }

    void PreGeneration()
    {
        for (int i = 8; i > RoadStartDistance; i -= Size)
        {
            StraightRoadBehaviourScript newRoadScript = CreateRoad(new Vector3(i, 0, 0)).GetComponent<StraightRoadBehaviourScript>();
            newRoadScript.newRoadIsAvailable = false;
        }
        CreateRoad();
    }

}
