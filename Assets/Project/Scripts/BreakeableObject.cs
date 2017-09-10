using UnityEngine;
using System.Collections;

public class BreakeableObject : MonoBehaviour {

    public Emotions _playerEmotions;
    public float requiredRage;

	public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();
            if(_playerEmotions.GetMood()<=requiredRage)
            {
                _playerEmotions.SetMood(false, requiredRage*0.5f);
                gameObject.SetActive(false);
            }
        }
    }
}
