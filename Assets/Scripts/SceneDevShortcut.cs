using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDevShortcut : MonoBehaviour
{
    void OnLoadFlashback1()
    {
        SceneManager.LoadScene(SceneIds.Flashback1);       
    }

    void OnLoadFlashback2()
    {
        SceneManager.LoadScene(SceneIds.Flashback2);
    }

    void OnLoadFlashback3()
    {
        SceneManager.LoadScene(SceneIds.Flashback3);
    }

    void OnLoadFlashback4()
    {
        SceneManager.LoadScene(SceneIds.Flashback4);
    }
}
