using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public event Action<float> onChangeHealth;
    public event Action onDeath;
    
    public float blinkRate;

    public Animator playerAnimator;
    public Transform playerTransform;
    public GameObject playerBody;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public Emotions playerEmotions;
        
    public void Start()
    {
        playerMovement.GInitialize();
        playerEmotions.Ginitialize();

        playerMovement.onPlayerWalk += delegate (bool p_walking)
        {
            playerAnimator.SetInteger("State", p_walking ? 1 : 0);
        };

        playerMovement.onPlayerJump += delegate ()
        {
            playerAnimator.SetInteger("State", 2);
        };

        playerMovement.onPlayerFloat += delegate ()
        {
            playerAnimator.SetInteger("State", 4);
        };

        playerEmotions.onChangedEmotions += delegate (float p_mood)
        {
            playerAnimator.SetFloat("Mood", p_mood);
        };

        playerHealth.onDeath += delegate ()
        {
            playerAnimator.SetTrigger("Death");
            if (onDeath != null) onDeath();
            playerEmotions.enabled = false;
            playerHealth.enabled = false;
            playerMovement.enabled = false;
        };

        playerHealth.onPushed += delegate ()
        {
            playerMovement.lockMovement = 1;
            playerAnimator.SetInteger("State", 4);
        };
        
        playerHealth.onInvincible += delegate (bool p_inv)
        {
            if (p_inv)
            {
                InvokeRepeating("Blink", blinkRate, blinkRate);
            }
            else
            {
                CancelInvoke("Blink");
                playerBody.SetActive(true);
            }
        };

        playerHealth.onDamage += delegate (float p_health)
        {
            if (onChangeHealth != null) onChangeHealth(p_health);
        };
    }

    public void Update()
    {
        playerMovement.GUpdate();
        playerEmotions.GUpdate();
        CheckRotation();
    }

    private void CheckRotation()
    {
        if(playerMovement.direction)
        {
            if(playerTransform.eulerAngles.y!=90f)
            {
                playerTransform.eulerAngles = new Vector3(0f, 90f, 0f);
            }
        }
        else
        {
            if (playerTransform.eulerAngles.y != 270f)
            {
                playerTransform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
        }
    }

    private void Blink()
    {
        playerBody.SetActive(playerBody.activeInHierarchy ? false : true);
    }
}
