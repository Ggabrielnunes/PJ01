using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorController : ColorController {

    private SpriteRenderer _spriterRenderer;
    public bool iDebug;
    protected override void Start()
    {
        _spriterRenderer = GetComponent<SpriteRenderer>();
        _color = _spriterRenderer.color;
    }

    protected override void SetNewColor()
    {        
        _spriterRenderer.color = InterpolateColor(_spriterRenderer.color);
    }
}
