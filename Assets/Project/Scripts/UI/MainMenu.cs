using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {
    
    public Image[] stageImages;

    public GameObject mainMenu;
    public GameObject stageSelect;
    public GameObject helpMenu;
    public GameObject settingsMenu;

    private int _unlockedStages;

	public void StartGame(bool p_start)
    {
        mainMenu.SetActive(p_start ? false : true);
        stageSelect.SetActive(p_start ? true : false);

        _unlockedStages = PlayerPrefs.GetInt("UnlockedStages");
        if (_unlockedStages <= 0) _unlockedStages = 1;

        for(int i = 0; i < stageImages.Length; i++)
        {
            if(i < _unlockedStages)
            {
                stageImages[i].GetComponentInParent<Button>().interactable = true;
                var __color = stageImages[i].color;
                __color.a = 0;
                stageImages[i].color = __color;
            }
        }
    }

    public void SelectStage(int p_stage)
    {
       SceneManager.LoadScene("Stage_"+p_stage);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
