using UnityEngine;
using System;
using System.Collections;

public class Emotions : MonoBehaviour {

    public event Action<float> onChangedEmotions;

    private float _mood;

    private bool _raisingEmotion = false;
    private bool _raiseToSad = false;
    private float _changeRate;

    private PlayerMovement _playerMovement;

    public void Ginitialize()
    {
        _mood = 0.5f;
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void GUpdate()
    {
        if (_raisingEmotion)
        {
            if(_raiseToSad)
            {
                if (_mood > 0) _mood -= _changeRate * Time.deltaTime;
                else _mood += _changeRate * Time.deltaTime;
            }
            else
            {
                _mood += _changeRate * Time.deltaTime;
                if (_mood > 1f) _mood = 1f;
                else if (_mood < -1f) _mood = -1f;
            }
            if (onChangedEmotions != null) onChangedEmotions(_mood);
        }
        ChangeEmotionsEffect();
    }

    public void SetMood(bool p_set, float p_mood)
    {
        if (!p_set)
        {
            _mood += p_mood;
        }
        else
        {
            _mood = p_mood;
        }

        if (_mood > 1f) _mood = 1f;
        else if (_mood < -1f) _mood = -1f;
        if (onChangedEmotions != null) onChangedEmotions(_mood);
    }

    public void ChangeEmotionsEffect()
    {
        _playerMovement.SetWalkSpeed(_mood);
        _playerMovement.SetJump(_mood * 5f);
    }

    public void IsRaisingEmotion(bool p_raise, float p_rate)
    {
        if (!p_raise)
        {
            _changeRate = 0f;
            _raisingEmotion = false;
        }
        else
        {
            _changeRate = p_rate;
            _raisingEmotion = true;
        }

        _raiseToSad = false;
    }

    public void RaisingToSad(bool p_raise, float p_rate)
    {
        if (!p_raise)
        {
            _raiseToSad = false;
            _changeRate = 0f;
            _raisingEmotion = false;
        }
        else
        {
            _raiseToSad = true;
            _changeRate = p_rate;
            _raisingEmotion = true;
        }
    }

   public float GetMood()
    {
        return _mood;
    }

    public bool IsRaising()
    {
        return _raisingEmotion;        
    }
}
