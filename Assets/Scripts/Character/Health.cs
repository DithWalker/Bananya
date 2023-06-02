using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider health_bar;
    
   
    public void SetHealth(float newValue)
    {
        health_bar.value = newValue <= 0.0f ? 0.0f : newValue;
        
    }
    public void SetMaxHealth(float maxValue)
    {
        health_bar.maxValue = maxValue;
        health_bar.value = maxValue;

    }
   
}