using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameGuiManager guiManager;
    public EmotionManager emotionManager;
    public KeyManager keyManager;
    public EnemyManager enemyManager;

    private Emotions _playerEmotions;
    private PlayerHealth _playerHealth;

    // Use this for initialization
    void Start () {
        _playerEmotions = player.GetComponent<Emotions>();
        _playerHealth = player.GetComponent<PlayerHealth>();

        guiManager.MInitialize();
        keyManager.MInitialize();
        enemyManager.MInitialize();

        _playerEmotions.onChangedEmotions += delegate (float[] p_values)
        {
            guiManager.UpdateEmotionSliders(p_values);
            enemyManager.UpdateEnemyEmotions(p_values);
        };

        keyManager.onGotKey += delegate (int p_key)
        {
            guiManager.ManageKey(p_key, true);
        };

        keyManager.onUsedKey += delegate (int p_key)
        {
            guiManager.ManageKey(p_key, false);
        };
    }
}
