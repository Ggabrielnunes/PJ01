using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameGuiManager guiManager;
    public EmotionManager emotionManager;

    private Emotions _playerEmotions;
    private PlayerHealth _playerHealth;

    // Use this for initialization
    void Start () {
        _playerEmotions = player.GetComponent<Emotions>();
        _playerHealth = player.GetComponent<PlayerHealth>();

        _playerEmotions.changedEmotions += delegate (float[] p_values)
        {
            guiManager.UpdateEmotionSliders(p_values);
        };
	}
}
