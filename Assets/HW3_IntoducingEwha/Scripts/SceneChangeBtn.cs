using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeBtn : MonoBehaviour
{
    public void ClickBtn_SceneChange()
    {
        SceneManager.LoadScene("Bridge");
    }
}
