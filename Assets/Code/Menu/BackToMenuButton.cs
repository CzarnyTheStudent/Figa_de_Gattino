using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(0);
    }
}
