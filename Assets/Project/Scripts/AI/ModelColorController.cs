using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelColorController : ColorController {
    
    private Material _material;
    protected override void Start()
    {
        _material = GetComponent<SkinnedMeshRenderer>().material;
        _color = _material.color;
    }

    protected override void SetNewColor()
    {
        _material.color = InterpolateColor(_material.color);
    }
}
