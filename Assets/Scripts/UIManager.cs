using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Dropdown resolutionDropdwon;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdwon.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;  
            }
        }

        resolutionDropdwon.AddOptions(options);
        resolutionDropdwon.value = currentResolutionIndex;
        resolutionDropdwon.RefreshShownValue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume( float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("Volume", volume);
    }
 
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen ( bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}