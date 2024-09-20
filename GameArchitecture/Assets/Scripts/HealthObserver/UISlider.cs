using UnityEngine;
using UnityEngine.UI;

public class UISlider : MonoBehaviour
{
    [SerializeField] private Slider slider;


    public void Initialize(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;

    }

    public void UpdateSlider(int currentValue, int maxValue)
    {
        slider.value = currentValue;
    }
}
