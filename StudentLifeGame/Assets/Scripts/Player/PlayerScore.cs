using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance = null;

    [Header("GameObjects"), SerializeField]
    Text scoreText;

    private float score;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        score = 0.0f;
    }

    private void Update()
    {
        score += (Time.deltaTime * 2.5f);


        scoreText.text = ((int)score).ToString();
    }
}
