using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUFuildToCamera : MonoBehaviour {

    public enum TexType
    {
        Color,
        Velocity,
        Pressure,
        Debug
    }

    public TexType _type;
    public Shader _shader;
    Material _material;

    GPUFluid _fluid;

    private void Start()
    {
        _fluid = FindObjectOfType<GPUFluid>();
        _material = new Material(_shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        var tex = new[] {_fluid._color, _fluid._velocity, _fluid._pressure, _fluid._debugTex }[(int)_type];
        Graphics.Blit(tex, destination, _material);
    }

    private void OnDestroy()
    {
        Destroy(_material);
    }
}
