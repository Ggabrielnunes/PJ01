using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuiManager : MonoBehaviour {

    public Slider[] emotionSliders;
    public Slider healthSlider;
    public GameObject[] keys;

    public void MInitialize()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(false);
        }
    }

    public void UpdateEmotionSlider(float p_newSlider)
    {
        for (int i = 0; i < emotionSliders.Length; i++)
        {
            emotionSliders[i].value = p_newSlider;
        }
    }

    public void ManageKey(int p_key, bool p_active)
    {
        keys[p_key].SetActive(p_active);
    }
}
