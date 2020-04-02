﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{

    public GameObject explosion;
    public Vector3 destroyPosition;
    public GameObject ring;

    void OnTriggerEnter(Collider other)
	{
        if(other.tag== "Boundary") //ensures that the monster ignores contact with boundry
		{
            return;
		}

        if (other.tag == "RingPickup") //ensures that the monster ignores contact with boundry
        {
            
        }


        Destroy(other.gameObject); //destroys the collider (i.e. bolt) 
        Destroy(gameObject); //destroys itself

      Instantiate(explosion, other.transform.position, other.transform.rotation); //spaws explosion after game object is destroyed

        destroyPosition = other.transform.position;

        destroyPosition.y += 15f;

        Instantiate(ring, destroyPosition, other.transform.rotation); //spawns coin after gameobject is destroyed

        Stats.Points += 20;
        Stats.EnemiesRemaining -= 1;

    }
}