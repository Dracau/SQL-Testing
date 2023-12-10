using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField pointsField;
    [SerializeField] private Button addButton;

    private void Start()
    {
        VerifyInput();
    }

    public void AddPoints(int amount)
    {
        DBManager.score += int.Parse(pointsField.text);
        StartCoroutine(UpdateScoreCO());
    }

    private IEnumerator UpdateScoreCO()
    {
        string returnCode;
        WWWForm form = new WWWForm();
        form.AddField("username", DBManager.username);
        form.AddField("score", DBManager.score);
        
        WWW www = new WWW("http://localhost/unity-test/updatescore.php", form);
        yield return www;

        returnCode = Dracau.Utils.CleanupString(www.text);

        if (returnCode == "0")
        {
            Debug.Log("Updated Score #" + returnCode);
        }
        else
        {
            Debug.Log("Couldn't update score #" + returnCode);
        }
    }

    public void VerifyInput()
    {
        if (string.IsNullOrEmpty(pointsField.text))
        {
            addButton.interactable = false;
            return;
        }
        addButton.interactable = true;
    }
}
