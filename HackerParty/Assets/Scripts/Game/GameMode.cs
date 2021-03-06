﻿using UnityEngine;
using System.Collections.Generic;

// n86 (Nathan Butt) - Instantiates characters and assigns them a controller. 

public class GameMode : MonoBehaviour {

    // Character list and animators to be set for the player when it is instanciated. 
    public List<Sprite> characterSprites;
    public List<RuntimeAnimatorController> characterAnimators;
    public GameObject characterToSpawn;

    public GameObject UIShell;

    public GameObject spawnPoint;
    int numberOfControllers;

	// Use this for initialization
	void Start ()
    {
        numberOfControllers = Input.GetJoystickNames().Length;
        instanciateObjects(Input.GetJoystickNames().Length);
	}

    void instanciateObjects(int controllerNumbers)
    {
        for(int i = 0; i < numberOfControllers; i++)
        {
            characterToSpawn = (GameObject)Instantiate(characterToSpawn, spawnPoint.transform.position, Quaternion.Euler(0, 0, 0));
            characterToSpawn.GetComponent<Entity_Actor>().setControllerID(i);
            Debug.Log(i);
            characterToSpawn.GetComponent<Entity_Actor>().setCharacterSkin(characterSprites[i], characterAnimators[i]);
            characterToSpawn.transform.Rotate(new Vector3(90.0f, 0, 0));
            characterToSpawn.transform.parent = UIShell.transform;
        }
    }
}
