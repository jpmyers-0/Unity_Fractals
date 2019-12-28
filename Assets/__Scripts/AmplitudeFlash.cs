﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmplitudeFlash : MonoBehaviour
{
    public AudioPeer _audioPeer;
    public Gradient _colorGrad;
    public float _colorMultiplier;

    private Color _startColor, _endColor;
    private Color _emissionColor;
    private Renderer rend;
    void Start()
    {
        _startColor = new Color(0, 0, 0, 0);
        _endColor = new Color(0, 0, 0, 1);
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _emissionColor = _colorGrad.Evaluate(AudioPeer._amplitude);

        Color colorLerp = Color.Lerp(_startColor, _emissionColor * _colorMultiplier, AudioPeer._amplitudeBuffer);
        rend.material.SetColor("_EmissionColor", colorLerp);
        colorLerp = Color.Lerp(_startColor, _endColor, AudioPeer._amplitudeBuffer);
        rend.material.SetColor("_Color", colorLerp);
    }
}