using UnityEngine;
using System.Collections;


public class WorldScript : MonoBehaviour {

    public static WorldScript Instance;
    public float PlayerMovementSpeed;

    public WorldGeneratorScript worldGeneratorScript;


	// Use this for initialization
	void Start () {
        Instance = this;

        worldGeneratorScript = GetComponent<WorldGeneratorScript>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
