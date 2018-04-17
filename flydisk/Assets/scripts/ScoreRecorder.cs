using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecorder : MonoBehaviour
{

    public Text scoreText;
    // 计分板

    int score;
    // 纪录分数
    
    public ScoreRecorder(Text _scoreText)
    {
        scoreText = _scoreText;
    }

    public void ResetScore()
    {
        score = 0;
    }

    // 飞碟点击中加分
    public void AddScore(int addscore)
    {
        score += addscore;
        scoreText.text = "Score:" + score;
    }

    public void SetDisActive()
    {
        scoreText.text = "";
    }

    public void SetActive()
    {
        scoreText.text = "Score:" + score;
    }
}