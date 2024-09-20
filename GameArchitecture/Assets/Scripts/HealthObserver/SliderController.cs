using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private UISlider slider;

    private void Start()
    {
        //Subscribe the Slider to the healthchange event
        slider.Initialize(health.GetMaxHealth());
        health.HealthChanged += slider.UpdateSlider;
    }

    private void OnDestroy()
    {
        //Unsubscribe the Slider to the healthchange to avoid memory leaks
        health.HealthChanged -= slider.UpdateSlider;
    }
}
