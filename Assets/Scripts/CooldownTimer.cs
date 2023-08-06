using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CooldownTimer : MonoBehaviour
{
    public Slider slider;

    public void MaxCooldown(float maxCooldown)
    {
        slider.maxValue = maxCooldown;
        slider.value = maxCooldown;
    }
    public void Cooldown(float cooldown)
    {
        slider.value = cooldown;
    }
}
