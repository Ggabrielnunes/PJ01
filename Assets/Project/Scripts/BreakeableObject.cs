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
            if(_playerEmotions.GetRage()>=requiredRage)
            {
                _playerEmotions.SetAllEmotions(false, -requiredRage, 0, 0);
                gameObject.SetActive(false);
            }
        }
    }
}
