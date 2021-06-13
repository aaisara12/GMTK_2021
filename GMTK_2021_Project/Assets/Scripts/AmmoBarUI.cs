﻿using UnityEngine;
using UnityEngine.UI;

public class AmmoBarUI : MonoBehaviour
{
    [SerializeField] AmmoStat ammoStat;
    Slider slider;

    void Awake()
    {
        if(ammoStat == null)
            Debug.LogWarning("No health stat component linked to this health bar!");
        else
        {
            ammoStat.OnChangeBullets += HandleNewBullets;
        }
        
        slider = GetComponent<Slider>();
        if(slider == null)
            Debug.LogWarning("Health bar component needs a slider!");

    }

    void OnDestroy()
    {
        ammoStat.OnChangeBullets += HandleNewBullets;
    }

    void HandleNewBullets(AmmoInfo info)
    {
        slider.value = info.currentBullets/((float)info.maxBullets);
    }
}
