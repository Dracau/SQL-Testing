using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RegisterMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField usernameField;
    [SerializeField] private TMP_InputField passwordField;
    [SerializeField] private Button registerButton;
    private string Username => usernameField.text;
    private string Password => passwordField.text;

    private void Start()
    {
        VerifyInputs();
    }

    public void Register()
    {
        StartCoroutine(RegisterCO());
    }

    private IEnumerator RegisterCO()
    {
        string returnCode;
        WWWForm form = new WWWForm();
        form.AddField("name", Username);
        form.AddField("password", Password);
        
        WWW www = new WWW("http://localhost/unity-test/register.php", form);
        yield return www;

        returnCode = Dracau.Utils.CleanupString(www.text);
        
        if (returnCode.Equals("0"))
        {
            Debug.Log("User created");
            SceneManager.LoadScene("MainMenu");
        }
        else Debug.Log("Could not create user. Error #" + returnCode);
    }

    public void VerifyInputs()
    {
        registerButton.interactable = Username.Length is > 0 and < 16  && Password.Length is > 8 and < 32;
    }
}
