using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{
    public static string username;

    public Text Username;

    void Start()
    {
        Username.text = username;
    }
}

