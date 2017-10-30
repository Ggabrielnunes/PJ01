using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameGuiManager : MonoBehaviour {

    public event System.Action<int> onFadeOutEnd;

    public Slider moodSlider;
    public Image fadeOutScreen;
    public Image healthSlider;
    public Image sliderHandler;
    public GameObject[] keys;
    public GameObject gameOverScreen;
    public Button[] buttons;
    public Sprite happyMask;
    public Sprite sadMask;
    public Sprite madMask;

    private float _fadeSpeed = 2f;
    private int _actionOnFadeOut;

    public void MInitialize()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].SetActive(false);
        }
        Fade(false);
    }

    public void ActivateGOScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ButtonPress(int p_button)
    {
        _actionOnFadeOut = p_button;
        Fade(true);
    }

    public void UpdateHealthSlider(float p_health)
    {
        healthSlider.fillAmount = p_health / 100;
    }

    public void UpdateEmotionSlider(float p_newSlider)
    {
        moodSlider.value = p_newSlider;
        if(p_newSlider<=-0.3f)
        {
            sliderHandler.sprite = madMask;
        }
        else if(p_newSlider>=0.3f)
        {
            sliderHandler.sprite = happyMask;
        }
        else
        {
            sliderHandler.sprite = sadMask;
        }
    }

    public void ManageKey(int p_key, bool p_active)
    {
        keys[p_key].SetActive(p_active);
    }

    public void EndgameFade()
    {
        _actionOnFadeOut = 4;
        fadeOutScreen.CrossFadeAlpha(1f, _fadeSpeed, false);
        Invoke("OnFadeAction", _fadeSpeed + 0.5f);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    private void Fade(bool p_in)
    {
        fadeOutScreen.CrossFadeAlpha(p_in ? 1f : 0f, _fadeSpeed, false);
        if (p_in) Invoke("OnFadeAction", _fadeSpeed + 0.5f);
    }

    private void OnFadeAction()
    {
        if(_actionOnFadeOut != 0 && onFadeOutEnd != null) onFadeOutEnd(_actionOnFadeOut);
    }
}
