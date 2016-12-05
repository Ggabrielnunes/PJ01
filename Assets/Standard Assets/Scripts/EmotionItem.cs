using UnityEngine;
using System.Collections;

public class EmotionItem : MonoBehaviour {

    [SerializeField] private string _emotion;
    [SerializeField] private float _amount;
    [SerializeField] private float _rate;

    private bool _isRaising;
    private Emotions _playerEmotions;

    public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if(p_collider.tag=="Player" && _amount>0)
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();
            if(_playerEmotions.GetEmotion(_emotion)<1f)
            {
                _playerEmotions.IsRaisingEmotion(_emotion, true, _rate);
                _isRaising = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D p_collider)
    {
        if(p_collider.tag=="Player")
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();            
            _playerEmotions.IsRaisingEmotion("",false,0f);
            _isRaising = false;
        }
    }

    public void Update()
    {
        if(_isRaising)
        {
            if(_amount>0 && _playerEmotions!=null && _playerEmotions.GetEmotion("Rage")<1f) _amount -= _rate*Time.deltaTime;
            else
            {
                _playerEmotions.IsRaisingEmotion("", false, 0f);
                _isRaising = false;
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

    public string GetEmotion()
    {
        return _emotion;
    }
}
