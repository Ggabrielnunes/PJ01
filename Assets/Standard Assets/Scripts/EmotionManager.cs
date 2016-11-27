using UnityEngine;
using System.Collections;

//Dados utilizados para definir o estado do jogador
public struct Data
{
    public float rage;
    public float happiness;
    public float sadness;
    public float health;
    public float sanity;
    public Vector2 position;
    public States playerState;
};

public class EmotionManager : MonoBehaviour {
    public GameObject player;

    private Emotions _playerEmotions;   
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;

    private ColorController[] _allColorControllers;

    //Dados salvos a cada três segundos. Últimos três estados (contando o estado atual) são salvos.
    private Data _dataNow;
    private Data _data3s;
    private Data _data6s;

	// Use this for initialization
	private void Start () {
        //Encontra os scripts necessários contidos no player:
        _playerEmotions = player.GetComponent<Emotions>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerMovement = player.GetComponent<PlayerMovement>();

        //Encontra todos os objetos que terão suas cores modificadas
       _allColorControllers = FindObjectsOfType<ColorController>();
        //Atualiza todos os dados a cada 3 segundos
        InvokeRepeating("UpdateAllData", 1f, 3f);
	}

    //Atualiza os valores de Rage, Happiness e Sadness para todos os objetos necessários
    private void UpdateAllColors(float p_rage, float p_happiness, float p_sad)
    {
        for(int i = 0; i < _allColorControllers.Length; i++)
        {
            if (_allColorControllers[i].isActiveAndEnabled) _allColorControllers[i].ChangeColor(p_rage, p_happiness, p_sad);
        }
    }

    //Atualiza os dados atuais
    private void UpdateDataNow()
    {
        _dataNow.happiness = _playerEmotions.GetHappiness();
        _dataNow.sadness = _playerEmotions.GetSadness();
        _dataNow.rage = _playerEmotions.GetRage();
        _dataNow.health = _playerHealth.GetHealth();
        _dataNow.sanity = _playerHealth.GetSanity();
        _dataNow.position = _playerMovement.GetPosition();
        _dataNow.playerState = _playerMovement.GetState();      
    }
    //Organiza os dados
    private void UpdateAllData()
    {
        _data6s = _data3s;
        _data3s = _dataNow;
        UpdateDataNow();
    }
	
	// Update is called once per frame
	void Update () {
        UpdateAllColors(_playerEmotions.GetRage(), _playerEmotions.GetHappiness(), _playerEmotions.GetSadness());
    }
}
