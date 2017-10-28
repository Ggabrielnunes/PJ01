﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public PlayerManager playerManager;
    public GameGuiManager guiManager;
    public EmotionManager emotionManager;
    public KeyManager keyManager;
    public EnemyManager enemyManager;

    private Door _door;
    private Emotions _playerEmotions;
    private PlayerHealth _playerHealth;
    private Dictionary<string, object> _analyticsDictionary;

    // Use this for initialization
    void Start () {
        _door = FindObjectOfType<Door>();

        _playerEmotions = player.GetComponent<Emotions>();
        _playerHealth = player.GetComponent<PlayerHealth>();

        guiManager.MInitialize();
        keyManager.MInitialize();
        enemyManager.MInitialize();

        if(_door!=null)
        {
            _door.onEndStage += delegate ()
            {
                guiManager.EndgameFade();                
            };
        }

        playerManager.onChangeHealth += delegate (float p_health)
        {
            guiManager.UpdateHealthSlider(p_health);
        };

        playerManager.onDeath += delegate()
        {
            Dictionary<string, object> __newDic = new Dictionary<string, object>();
            __newDic.Add("Position", player.transform.position);
            __newDic.Add("Mood", _playerEmotions.GetMood());
            AnalyticsManager.Instance.SendCustomEvent("Death", __newDic);
            guiManager.ActivateGOScreen();
        };

        _playerEmotions.onChangedEmotions += delegate (float p_value)
        {
            guiManager.UpdateEmotionSlider(p_value);
            enemyManager.UpdateEnemyEmotions(p_value);
        };

        keyManager.onGotKey += delegate (int p_key)
        {
            guiManager.ManageKey(p_key, true);
        };

        keyManager.onUsedKey += delegate (int p_key)
        {
            guiManager.ManageKey(p_key, false);
        };

        guiManager.onFadeOutEnd += delegate (int p_effect)
        {
            if (p_effect == 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if (p_effect == 2)
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if(p_effect == 3) Application.Quit();
            else if(p_effect == 4)
            {
                SceneManager.LoadScene("MainMenu");
            }
        };
    }
}
