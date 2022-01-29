using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreenActions : MonoBehaviour
{
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
        Debug.Log("Let's Go!");
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
        Debug.Log("Quit!");
        //Application.Quit();
    }
}
