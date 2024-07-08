using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliderUI : MonoBehaviour
{
    [SerializeField] private Slider Slider;
    [SerializeField] private TextMeshProUGUI PercentageText;

    private MixerGroup MixerGroup;

    private void Awake()
    {
        Slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    public void Init(MixerGroup mixerGroup)
    {
        MixerGroup = mixerGroup;
        SetValue(GameManager.Instance.AudioManager.GetMixerVolume(MixerGroup));
    }

    public void SetValue(float normalizedValue)
    {
        Slider.SetValueWithoutNotify(normalizedValue);
        UpdatePercentageText();
    }

    private void UpdatePercentageText()
    {
        PercentageText.text = $"{Slider.value * 100:00}%";
    }

    private void OnSliderValueChanged(float value)
    {
        GameManager.Instance.AudioManager.SetMixerVolume(MixerGroup, value);
        UpdatePercentageText();
    }
}
