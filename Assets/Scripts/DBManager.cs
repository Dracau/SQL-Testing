using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int score;
    public static bool LoggedIn => username != null;

    public static void LogIn(string newUsername, int newScore)
    {
        username = newUsername;
        score = newScore;
    }
    public static void LogOut()
    {
        username = null;
    }
}