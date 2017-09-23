using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Animator playerAnimator;
    public Transform playerTransform;
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public Emotions playerEmotions;
    
    public void Start()
    {
        playerMovement.GInitialize();
        playerEmotions.Ginitialize();
    }

    public void Update()
    {
        playerMovement.GUpdate();
        playerEmotions.GUpdate();
        CheckRotation();

        playerMovement.onPlayerWalk += delegate (bool p_walking)
        {
            playerAnimator.SetInteger("State", p_walking?1:0);
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
}
