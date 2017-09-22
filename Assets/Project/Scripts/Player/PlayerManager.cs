using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public Animator playerAnimator;
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
    }
}
