using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjectPoolNamespace;

public class StraightRoadBehaviourScript : MonoBehaviour
{
    public bool newRoadIsAvailable;
    public WorldGeneratorScript worldGeneratorScript;
    public int Size;
    float RoadStartDistance;

    // Use this for initialization
    void Start()
    {
        RoadStartDistance = worldGeneratorScript.RoadStartDistance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        

        SelfDestruct();
    }


    void SelfDestruct()
    {

        if (transform.position.x > 10)
        {
            ObjectPool.GivebackObject(gameObject);
        }

    }

    void Move()
    {
        transform.Translate(8 * Vector3.right * Time.deltaTime);

        if (transform.position.x > RoadStartDistance + Size)
        {
            sendNewRoadCommand();
        }
    }

    void sendNewRoadCommand()
    {
        if (newRoadIsAvailable)
        {
            newRoadIsAvailable = false;
            worldGeneratorScript.CreateRoad(new Vector3(transform.position.x - Size,
                                                        transform.position.y,
                                                        transform.position.z));
        }
    }


}
