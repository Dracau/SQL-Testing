using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToRegister()
    {
        SceneManager.LoadScene("RegisterMenu");
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene("LoginMenu");
    }

    public void GoToPoints()
    {
        if(!DBManager.LoggedIn) return;
        
        SceneManager.LoadScene("PointsMenu");
    }
}
