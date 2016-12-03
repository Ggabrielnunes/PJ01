using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuiManager : MonoBehaviour {

    public Slider[] emotionSliders;
    public Slider healthSlider;

	public void UpdateEmotionSliders(float[] p_newSlider)
    {
        for(int i = 0; i < emotionSliders.Length;i++)
        {
            emotionSliders[i].value = p_newSlider[i];
        }
    }
}
