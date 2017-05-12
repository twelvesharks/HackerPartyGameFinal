﻿using UnityEngine;
using System.Collections.Generic;

// TODO - consider having two seperate classes for NPCs and players. Hence Entity_Actor is a player. 

public class Entity_Actor : MonoBehaviour {

    private SpriteRenderer actorSprite;
    public Controller_Actor actorController;
    private Rigidbody actorRigidbody;
    private BoxCollider actorCollider;

    private int controllerID;

    public List<Sprite> starterSprites;
    public int spriteToLoad;

    // gameplay properties.
    public float actorVelocity;

    void Awake()
    {
        setupCharacter();
    }
	
	void Update ()
    {
        // here we get and set our transformatiion via the direction vector from the controller (we will now be changing vector position)
        actorRigidbody.velocity = actorController.getControllerDirection() * actorVelocity;
    }

    // setup the character via apperance etc. 
    void setupCharacter()
    {
        actorRigidbody = this.gameObject.GetComponent<Rigidbody>();
        actorCollider = this.gameObject.GetComponent<BoxCollider>();

        #region character sprite selection
        // TODO - add routiene to get correct player sprites. 
        actorSprite = this.gameObject.GetComponent<SpriteRenderer>();

        if(!(spriteToLoad > starterSprites.Count))
        {
            actorSprite.sprite = starterSprites[spriteToLoad];
        }

        #endregion

        // dynamicly adjust the collider accroding to the sprite size
        actorCollider.size = new Vector3(0.15f, 0.2f, 0.0f);
    }

    public void setControllerID(int newID)
    {
        controllerID = newID;
    }

}