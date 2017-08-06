using UnityEngine;
using System;
using System.Collections;

public class Emotions : MonoBehaviour {

    public event Action<float[]> onChangedEmotions;
      
    private float _rage;
    private float _happiness;
    private float _sadness;

    private bool _raisingEmotion=false;
    private float _rageRate=0;
    private float _happyRate=0;
    private float _sadRate=0;

    private PlayerMovement _playerMovement;

    private void Start()
    {
        _rage = _happiness = _sadness = 0.5f;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void UpdateEmotions()
    {
        float[] __values = new float[3];
        __values[0] = _rage;
        __values[1] = _happiness;
        __values[2] = _sadness;

        if (onChangedEmotions != null) onChangedEmotions(__values);
    }

    private void Update()
    {        
        if (_raisingEmotion)
        {
            _rage += _rageRate * Time.deltaTime;
            _happiness += _happyRate * Time.deltaTime;
            _sadness += _sadRate * Time.deltaTime;
            if (_rage > 1f) _rage = 1f;
            else if (_rage < 0f) _rage = 0f;
            if (_happiness > 1f) _happiness = 1f;
            else if (_happiness < 0f) _happiness = 0f;
            if (_sadness > 1f) _sadness = 1f;
            else if (_sadness < 0f) _sadness = 0f;
            UpdateEmotions();
        }
        ChangeEmotionsEffect();
    }   

    public void SetAllEmotions(bool p_set, float p_rage, float p_happy, float p_sad)
    {      
        if(!p_set)
        {
            _rage += p_rage;
            _happiness += p_happy;
            _sadness += p_sad;
        }
        else
        {
            _rage = p_rage;
            _happiness = p_happy;
            _sadness = p_sad;
        }

        if (_rage > 1f) _rage = 1f;
        else if (_rage < 0f) _rage = 0f;
        if (_happiness > 1f) _happiness = 1f;
        else if (_happiness < 0f) _happiness = 0f;
        if (_sadness > 1f) _sadness = 1f;
        else if (_sadness < 0f) _sadness = 0f;

        UpdateEmotions();
    }

    public void ChangeEmotionsEffect()
    {
        _playerMovement.SetJump(_happiness * 5f);
        _playerMovement.SetWalkSpeed(_rage * 5, _sadness);
    }

    public void IsRaisingEmotion(string p_emotion, bool p_raise, float p_rate)
    {
        if(!p_raise)
        {
            _rageRate = 0f;
            _happyRate = 0f;
            _sadRate = 0f;
            _raisingEmotion = false;
        }
        else
        {
            if (p_emotion == "Rage")
            {
                _rageRate = p_rate;
                _happyRate = -p_rate;
                _sadRate = -p_rate;
            }
            else if (p_emotion == "Happiness")
            {
                _rageRate = -p_rate;
                _happyRate = p_rate;
                _sadRate = -p_rate;
            }
            else if (p_emotion == "Sadness")
            {
                _rageRate = -p_rate;
                _happyRate = -p_rate;
                _sadRate = p_rate;
            }
            _raisingEmotion = true;
        }
    }
   
    public float[] GetAllEmotions()
    {
        float[] __emotions = new float[3];
        __emotions[0] = _rage;
        __emotions[1] = _happiness;
        __emotions[2] = _sadness;
        return __emotions;
    }

    public float GetRage()
    {
        return _rage;
    }

    public float GetHappiness()
    {
        return _happiness;
    }

    public float GetSadness()
    {
        return _sadness;
    }

    public float GetEmotion(string p_emotion)
    {
        if (p_emotion == "Rage") return _rage;
        else if (p_emotion == "Happiness") return _happiness;
        else if (p_emotion == "Sadness") return _sadness;
        return 1f;
    }

    public bool IsRaising()
    {
        return _raisingEmotion;        
    }
}
