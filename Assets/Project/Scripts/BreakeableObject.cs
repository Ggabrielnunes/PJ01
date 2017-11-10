using UnityEngine;
using System.Collections;

public class BreakeableObject : MonoBehaviour {

    public Emotions _playerEmotions;
    public float requiredRage;
    public float emotionChanger;
    public GameObject wall;
    public GameObject fragments;
    public ManualMeshColorController mainColor;
    public ManualMeshColorController[] meshControllers;

	public void OnTriggerEnter2D(Collider2D p_collider)
    {
        if (p_collider.tag == "Player")
        {
            if (_playerEmotions == null) _playerEmotions = p_collider.GetComponent<Emotions>();
            if(_playerEmotions.GetMood()<=requiredRage)
            {
                _playerEmotions.SetMood(false,emotionChanger);
                var __color = mainColor.GetColor();
                ApplyColors(__color);
                wall.SetActive(false);
                fragments.SetActive(true);
            }
        }
    }

    private void ApplyColors(Color p_color)
    {
        for(int i = 0; i < meshControllers.Length; i++)
        {
            meshControllers[i].SetColorInstant(p_color);
        }
    }
}
