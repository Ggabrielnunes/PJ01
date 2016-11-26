using UnityEngine;
using System.Collections;

public class EmotionManager : MonoBehaviour {
    [Tooltip("Emotion script attached to Player")]
    [SerializeField] private Emotions _playerEmotions;
    private ColorController[] _allColorControllers;

	// Use this for initialization
	private void Start () {
       _allColorControllers = FindObjectsOfType<ColorController>();
	}

    private void UpdateAllColors(float p_rage, float p_happiness, float p_sad)
    {
        for(int i = 0; i < _allColorControllers.Length; i++)
        {
            if (_allColorControllers[i].isActiveAndEnabled) _allColorControllers[i].ChangeColor(p_rage, p_happiness, p_sad);
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateAllColors(_playerEmotions.GetRage(), _playerEmotions.GetHappiness(), _playerEmotions.GetSadness());
    }
}
