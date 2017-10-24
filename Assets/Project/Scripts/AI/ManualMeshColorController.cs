using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMeshColorController : ColorController
{
    public int materialIndex;
    private Material _material;

    public override void SetColorInstant(Color p_color)
    {
        if(_material==null) _material = GetComponent<MeshRenderer>().materials[materialIndex];
        _material.color = p_color;
    }

    protected override void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[materialIndex];
        _color = _material.color;
    }

    protected override void SetNewColor()
    {
        _material.color = InterpolateColor(_material.color);
    }
}
