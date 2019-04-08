using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [Header("GameObjects"), SerializeField]
    Text scoreText;

    public float score;

    private void Start()
    {
        score = 0.0f;
    }

    private void Update()
    {
        if (GameManager.instance.state != GameManager.GameState.ACTIVE) return;

        score += (Time.deltaTime * 2.5f);


        scoreText.text = ((int)score).ToString();
    }
}
