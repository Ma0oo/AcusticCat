using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudControl : MonoBehaviour
{
    [SerializeField] private Slider _foodBar;
    [SerializeField] private Slider _stressBar;

    private void OnEnable()
    {
        Special.UpdateFood += OnUpdateFood;
        Special.UpdateStress += OnUpdateStress;
    }
    private void OnDisable()
    {
        Special.UpdateFood -= OnUpdateFood;
        Special.UpdateStress -= OnUpdateStress;
    }
    private void OnUpdateFood(float value)
    {
        UpdateBar(Bar.Food, value);
    }
    private void OnUpdateStress(float value)
    {
        UpdateBar(Bar.Stress, value);
    }
    private void UpdateBar(Bar bar, float value)
    {
        if (bar == Bar.Food)
            _foodBar.value = value;
        if (bar == Bar.Stress)
            _stressBar.value = value;
    }
    private enum Bar
    {
        Food, Stress
    }
}
