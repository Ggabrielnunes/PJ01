using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuiManager : MonoBehaviour {

    public Slider moodSlider;
    public Image healthSlider;
    public GameObject[] keys;

    public void MInitialize()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(false);
        }
    }

    public void UpdateHealthSlider(float p_health)
    {
        healthSlider.fillAmount = p_health / 100;
    }

    public void UpdateEmotionSlider(float p_newSlider)
    {
        moodSlider.value = p_newSlider;
    }

    public void ManageKey(int p_key, bool p_active)
    {
        keys[p_key].SetActive(p_active);
    }
}
