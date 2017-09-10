using UnityEngine;
using System.Collections;

public class ColorController : MonoBehaviour {
    
    protected Color _color;
    
    private bool _changeColor = false;
    // Use this for initialization
    protected virtual void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (_changeColor) SetNewColor();
	}    

    protected virtual void SetNewColor()
    {
        
    }
    
    protected Color InterpolateColor(Color p_color)
    {
        var __newColor = p_color;

        if (_color != __newColor)
        {
            if (__newColor.r > _color.r)
            {
                __newColor.r -= 0.01f;
                if (__newColor.r < _color.r) __newColor.r = _color.r;
            }
            else if (__newColor.r < _color.r)
            {
                __newColor.r += 0.01f;
                if (__newColor.r > _color.r) __newColor.r = _color.r;
            }

            if (__newColor.g > _color.g)
            {
                __newColor.g -= 0.01f;
                if (__newColor.g < _color.g) __newColor.g = _color.g;
            }
            else if (__newColor.g < _color.g)
            {
                __newColor.g += 0.01f;
                if (__newColor.g > _color.g) __newColor.g = _color.g;
            }

            if (__newColor.b > _color.b)
            {
                __newColor.b -= 0.01f;
                if (__newColor.b < _color.b) __newColor.b = _color.b;
            }
            else if (__newColor.b < _color.b)
            {
                __newColor.b += 0.01f;
                if (__newColor.b > _color.b) __newColor.b = _color.b;
            }
        }
        else _changeColor = false;

        return __newColor;
    }

    public void ChangeColor(float p_mood)
    {
        switch(PlayerState(p_mood))
        {
            case 0:
                _color.r = 1f;
                _color.g = 0.0f;
                _color.b = 0.0f;
                break;
            case 1:
                _color.r = 0.825f;
                _color.g = 0.075f;
                _color.b = 0.075f;
                break;
            case 2:
                _color.r = 0.65f;
                _color.g = 0.15f;
                _color.b = 0.15f;
                break;
            case 3:
                _color.r = 0.475f;
                _color.g = 0.225f;
                _color.b = 0.225f;
                break;
            case 4:
                _color.r = 0.3f;
                _color.g = 0.3f;
                _color.b = 0.3f;
                break;
            case 5:
                _color.r = 0.475f;
                _color.g = 0.475f;
                _color.b = 0.225f;
                break;
            case 6:
                _color.r = 0.65f;
                _color.g = 0.65f;
                _color.b = 0.15f;
                break;
            case 7:
                _color.r = 0.825f;
                _color.g = 0.825f;
                _color.b = 0.075f;
                break;
            case 8:
                _color.r = 1f;
                _color.g = 1f;
                _color.b = 0.0f;
                break;
        }
        _changeColor = true;
    }

    private int PlayerState(float p_mood)
    {
        if(p_mood<= -0.8f)
        {
            return 0;
        }
        else if (p_mood <= -0.6f)
        {
            return 1;
        }
        else if (p_mood <= -0.4f)
        {
            return 2;
        }
        else if (p_mood <= -0.2f)
        {
            return 3;
        }
        else if (p_mood <= 0.0f)
        {
            return 4;
        }
        else if (p_mood <= 0.2f)
        {
            return 5;
        }
        else if (p_mood <= 0.4f)
        {
            return 6;
        }
        else if (p_mood <= 0.6f)
        {
            return 7;
        }
        else if (p_mood <= 0.8f)
        {
            return 8;
        }
        else 
        {
            return 9;
        }
    }
}
