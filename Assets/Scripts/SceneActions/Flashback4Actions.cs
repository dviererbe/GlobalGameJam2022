using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flashback4Actions : MonoBehaviour
{
    private int State = 0;

    [SerializeField]
    private GameObject Image1;
    
    [SerializeField]
    private GameObject Image2;
    
    [SerializeField]
    private GameObject Image3;

    public void OnContinueStory()
    {
        if (State++ == 0)
        {
            ShowLastImage();
        }
        else
        {
            ToNextScene();
        }
    }

    private void ShowLastImage()
    {
        Image1.SetActive(false);
        Image2.SetActive(false);
        Image3.SetActive(true);
    }

    private void ToNextScene()
    {
        SceneManager.LoadScene(SceneIds.WelcomeScreen);
    }
}
