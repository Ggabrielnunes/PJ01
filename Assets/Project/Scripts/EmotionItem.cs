using UnityEngine;
using System.Collections;

public class EmotionItem : MonoBehaviour {

    public enum Emotion
    {
        HAPPY,
        RAGE,
        SAD
    }

    public ParticleSystem particles;

    [SerializeField] private Emotion _emotion;
    [SerializeField] private float _amount;
    [SerializeField] private float _rate;

    private bool _isRaising;
    private Emotions _playerEmotions;

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if(p_collider.tag=="Player" && _amount>0)
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();
            if(_emotion==Emotion.HAPPY)
            {
                _playerEmotions.IsRaisingEmotion(true, _rate);
            }
            else if (_emotion==Emotion.RAGE)
            {
                _playerEmotions.IsRaisingEmotion(true, -_rate);
            }
            else
            {
                _playerEmotions.RaisingToSad(true, _rate);
            }

            _isRaising = true;
        }
    }

    public void OnTriggerExit2D(Collider2D p_collider)
    {
        if(p_collider.tag=="Player")
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();            
            _playerEmotions.IsRaisingEmotion(false,0f);
            _isRaising = false;
        }
    }

    public void Update()
    {
        if(_isRaising)
        {
            if (_amount > 0 && _playerEmotions != null) _amount -= _rate * Time.deltaTime;
            else
            {
                _playerEmotions.IsRaisingEmotion(false, 0f);
                _isRaising = false;
                particles.Stop(true);
            }
        }
    }

    public float GetRate()
    {
        return _rate;
    }

    public float GetAmount()
    {
        return _amount;
    }    

    private bool CanRaise()
    {
        switch(_emotion)
        {
            case Emotion.HAPPY:
                if (_playerEmotions.GetMood() < 1f)
                    return true;
                else return false;
            case Emotion.RAGE:
                if (_playerEmotions.GetMood() > -1f)
                    return true;
                else return false;
            case Emotion.SAD:
                if (_playerEmotions.GetMood() > -0.3f && _playerEmotions.GetMood() < 0.3f)
                    return true;
                else return false;
        }
        return false;
    }
}
