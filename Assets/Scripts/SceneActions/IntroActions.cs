using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroActions : MonoBehaviour
{
    public void OnContinueStory()
    {
        ToNextScene();
    }

    private void ToNextScene()
    {
        SceneManager.LoadScene(SceneIds.Gameworld);
    }
}
