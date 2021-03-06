﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public int maxHealth = 20;
    public Text healthText;
    public int currentHealth;
    public HealthSlider healthBar;

    public GameObject gameOverExplosion;

    public GameObject gameOver;
    public GameObject youWin;

    private Vector3 bossToPlayerDistance;

    void Start()
    {

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthText.text = "Boss: " + maxHealth.ToString();

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Fire"))
        {
            TakeDamage(20);
        }


    }


    public void TakeDamage(int damage)
    {
        if (currentHealth >= 20)
        {
            currentHealth -= damage;
            print("damage taken");
            healthBar.SetHealth(currentHealth);
            healthText.text = "Health: " + currentHealth;
        }
        else if (currentHealth < 20)
        {
            this.gameObject.SetActive(false);
            Instantiate(gameOverExplosion, transform.position, transform.rotation);
            gameOver.SetActive(true);
            youWin.SetActive(true);// displays the message 'Game Over'


            print("printing from Player.cs script");
            //SkinnedMeshRenderer temp = playerBody.GetComponent<SkinnedMeshRenderer>();
            //temp.enabled = false;
        }
    }


}


