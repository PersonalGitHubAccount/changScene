using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sliderPercent : MonoBehaviour
{
    public Text percentText;

    public Slider percentSlider;
    // Use this for initialization

    public static sliderPercent Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
	
    public void SetSliderValue(int percent)
    {
        percentSlider.value = percent / 100.0f;
        percentText.text = percent.ToString() + "%";
    }

}
