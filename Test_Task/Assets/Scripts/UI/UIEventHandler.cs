using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject credentialsWindow;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void OpenSettingsWindow()
    {
        settingsWindow.SetActive(true);
    }
    public void OpenCredentialsWindow()
    {
        CloseSettingsWindow();
        credentialsWindow.SetActive(true);
    }
    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void CloseCredentialsWindow()
    {
        credentialsWindow.SetActive(false);
    }
}
