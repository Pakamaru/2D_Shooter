using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private Vector3 offset;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        offset = new Vector3(0, GetComponentInParent<CombatUnit>().transform.localScale.y, 0);
    }

    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;
    }

    private void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
