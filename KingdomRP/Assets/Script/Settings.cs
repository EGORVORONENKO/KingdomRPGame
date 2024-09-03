using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
	public Dropdown resolutionDropdown;
	public Dropdown qualityDropdown;
	
	Resolution[] resolutions;
	
	void Start()
	{
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		resolutions = Screen.resolutions;
		int currenResolutionIndex = 0;
		
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
			options.Add(option);
			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
				currenResolutionIndex = i;
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.RefreshShownValue();
		LoadSettings(currenResolutionIndex);
	}
	
	public void SetFullscreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
	
	public void SetResolution(int resolutionIndex)
	{
	Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}
	
	public void SaveSettings()
	{
		PlayerPrefs.SetInt("ResolutionPreference", resolutionDropdown.value);
		PlayerPrefs.SetInt("FullscreenPreference", System.Convert.ToInt32(Screen.fullScreen));
	}

	public void LoadSettings(int currenResolutionIndex)
	{
		if (PlayerPrefs.HasKey("ResolutionPreference"))
			resolutionDropdown.value = PlayerPrefs.GetInt("ResolutionPreference");
		else
			resolutionDropdown.value = currenResolutionIndex;
		
		if (PlayerPrefs.HasKey("FullscreenPreference"))
			 Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
		else
			Screen.fullScreen = true;
	}

}