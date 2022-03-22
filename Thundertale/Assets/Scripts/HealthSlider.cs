using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] Slider slider = null;
    [SerializeField] bool isPlayerSlider = false;

    // Start is called before the first frame update
    void Awake()
    {
        Health.OnHealthChange += SetSlider;
    }

    private void OnDisable()
    {
        Health.OnHealthChange -= SetSlider;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSlider(Vector2 health, bool isPlayer)
    {
        if (isPlayerSlider != isPlayer)
            return;
        slider.maxValue = health.y;
        slider.value = health.x;
    }
}
