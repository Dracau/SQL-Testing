using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [FormerlySerializedAs("registerButton")] [SerializeField] private Button loginButton;
    private string Username => usernameField.text;
    private string Password => passwordField.text;

    private void Start()
    {
        VerifyInputs();
    }

    public void Login()
    {
        StartCoroutine(LoginCO());
    }

    private IEnumerator LoginCO()
    {
        string returnCode;
        WWWForm form = new WWWForm();
        form.AddField("name", Username);
        form.AddField("password", Password);
        
        WWW www = new WWW("http://localhost/unity-test/login.php", form);
        yield return www;

        returnCode = Dracau.Utils.CleanupString(www.text);
        Debug.Log(returnCode);

        if (returnCode[0] == '0')
        {
            Debug.Log("Logged in #" + returnCode);
            DBManager.LogIn(Username, int.Parse(returnCode.Split("\t")[1]));
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("Couldn't login Error code #" + returnCode);
        }
    }

    public void VerifyInputs()
    {
        loginButton.interactable = Username.Length is > 0 and < 16  && Password.Length is > 8 and < 32;
    }
}
