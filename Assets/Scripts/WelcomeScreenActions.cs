using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreenActions : MonoBehaviour
{
    private const int IntroSceneId = 1;

    [SerializeField]
    private GameObject PopupOverlay;

    [SerializeField]
    private GameObject CloseDialog;

    [SerializeField]
    private GameObject TeamDescription;

    [SerializeField]
    private GameObject CreditList;

    public void StartGame()
    {
        SceneManager.LoadScene(IntroSceneId);
    }

    public void ShowTeamInfos()
    {
        TeamDescription.SetActive(true);
        PopupOverlay.SetActive(true);
    }

    public void ShowCredits()
    {
        CreditList.SetActive(true);
        PopupOverlay.SetActive(true);
    }

    public void ShowExitDialog()
    {
        CloseDialog.SetActive(true);
        PopupOverlay.SetActive(true);
    }

    public void HidePopup()
    {
        PopupOverlay.SetActive(false);
        CloseDialog.SetActive(false);
        TeamDescription.SetActive(false);
        CreditList.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
