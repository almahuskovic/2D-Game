using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
        SetValue(value);
    }
    public void SetValue(int value)
    {
        slider.value = value;
    }
}
