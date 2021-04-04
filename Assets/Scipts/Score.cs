using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int WordCount;

    public Text scoreText;

    void Start()
    {


        WordCount = 0;
    }

    void Update()
    {
        scoreText.text = WordCount.ToString();
    }




}
