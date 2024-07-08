using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private VolumeSliderUI VolumeSliderMaster;
    [SerializeField] private VolumeSliderUI VolumeSliderSFX;
    [SerializeField] private VolumeSliderUI VolumeSliderEnvironment;

    private void Start()
    {
        VolumeSliderMaster.Init(MixerGroup.Master);
        VolumeSliderSFX.Init(MixerGroup.SFX);
        VolumeSliderEnvironment.Init(MixerGroup.Environment);
    }
}
