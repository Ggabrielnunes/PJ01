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

    public void ChangeColor(float p_r, float p_g, float p_b)
    {
        _color.r = p_r*2;
        _color.g = p_g*2;
        _color.b = p_b;
        _changeColor = true;

        if (_color.r > 1f) _color.r = 1f;
        else if (_color.r < 0.3f) _color.r = 0.3f;
        if (_color.g > 1f) _color.g = 1f;
        else if (_color.g < 0.3f) _color.g = 0.3f;
        if (_color.b > 1f) _color.b = 1f;
        else if (_color.b < 0.3f) _color.b = 0.3f;
    }

    public void ToYellow(float p_happiness)
    {

    }

    public void ToRed(float p_rage)
    {

    }

    public void ToGrey(float p_sad)
    {

    }    
}
