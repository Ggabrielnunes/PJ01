using UnityEngine;
using System.Collections;

//Dados utilizados para definir o estado do jogador
public struct Data
{
    public float mood;
    public float health;
    public Vector2 position;
    public States playerState;
};

public class EmotionManager : MonoBehaviour {

    public GameObject player;

    private Emotions _playerEmotions;   
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;

    public ColorController[] _allColorControllers;
    private int _timesDataUpdated = 0;

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
    private void UpdateAllColors(float p_mood)
    {
        for(int i = 0; i < _allColorControllers.Length; i++)
        {
            if (_allColorControllers[i].isActiveAndEnabled) _allColorControllers[i].ChangeColor(p_mood);
        }
    }
    //Atualiza os dados atuais
    private void UpdateDataNow()
    {
        _data[0].mood = _playerEmotions.GetMood();
        _data[0].health = _playerHealth.GetHealth();
        _data[0].position = _playerMovement.GetPosition();
        _data[0].playerState = _playerMovement.GetState();
    }
    //Organiza os dados
    private void UpdateAllData()
    {       
        _data[2] = _data[1];
        _data[1] = _data[0];
        UpdateDataNow();

        float __newValue = 0f;
        __newValue = DataAnalyzer.CalculateEmotionLevels(_data, __newValue);
        if(_timesDataUpdated>=3 && !_playerEmotions.IsRaising())
        {
            _playerEmotions.SetMood(false, __newValue);
        }

        if (_timesDataUpdated < 3) _timesDataUpdated++;
    }
	// Update is called once per frame
	void Update () {
        UpdateAllColors(_playerEmotions.GetMood());
    }
}
