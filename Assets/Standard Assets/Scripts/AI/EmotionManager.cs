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
    private Data[] _data = new Data[3];    
	
	private void Start () {
        //Encontra os scripts necessários contidos no player:
        _playerEmotions = player.GetComponent<Emotions>();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerMovement = player.GetComponent<PlayerMovement>();

        //Encontra todos os objetos que terão suas cores modificadas
       _allColorControllers = FindObjectsOfType<ColorController>();
        //Atualiza todos os dados a cada 3 segundos
        UpdateDataNow();
        _data[2] = _data[1] = _data[0];
        InvokeRepeating("UpdateAllData", 3f, 3f);
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
        _data[0].happiness = _playerEmotions.GetHappiness();
        _data[0].sadness = _playerEmotions.GetSadness();
        _data[0].rage = _playerEmotions.GetRage();
        _data[0].health = _playerHealth.GetHealth();
        _data[0].sanity = _playerHealth.GetSanity();
        _data[0].position = _playerMovement.GetPosition();
        _data[0].playerState = _playerMovement.GetState();
    }
    //Organiza os dados
    private void UpdateAllData()
    {
        _data[2] = _data[1];
        _data[1] = _data[0];
        UpdateDataNow();

        float[] __newValues = new float[3];
        __newValues = DataAnalyzer.CalculateEmotionLevels(_data, __newValues);
        _playerEmotions.SetAllEmotions(false, __newValues[0], __newValues[1], __newValues[2]);
    }
	// Update is called once per frame
	void Update () {
        UpdateAllColors(_playerEmotions.GetRage(), _playerEmotions.GetHappiness(), _playerEmotions.GetSadness());
    }
}
