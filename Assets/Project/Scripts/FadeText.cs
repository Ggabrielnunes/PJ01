using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeText : MonoBehaviour {

    public Text uiText;

    private void Awake()
    {
        uiText.CrossFadeAlpha(0f, 0.01f, false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            uiText.CrossFadeAlpha(1f, 2f, false);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            uiText.CrossFadeAlpha(0f, 2f, false);
        }
    }
}
