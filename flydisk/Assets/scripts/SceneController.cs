using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using My.Disk;
using UnityEngine.UI;

public enum Status { BEGIN, COUNTING, WATING, GAMING, OVER }
public class SceneController : MonoBehaviour
{
    public Text centerText;
    public Text scoreText;
    public Text roundText;

    public ScoreRecorder recorder;
    RoundController round;

    public Status nowState;

    void Start()
    {
        nowState = Status.BEGIN;
        centerText.text = "";
        roundText.text = "";
        recorder = new ScoreRecorder(scoreText);
        round = Singleton<RoundController>.Instance;

        round.resetRound();
        recorder.SetDisActive();
        // 初始设置
    }

    private void OnGUI()
    {
        if (nowState == Status.BEGIN)
        {
            GUI.Label(new Rect(500, 150, Screen.width / 2, 50), "点击Play，开始游戏！");
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Play"))
            {
                nowState = Status.WATING;
                recorder.ResetScore();
            }
        }
        else if (nowState == Status.OVER)
        {
            if (GUI.RepeatButton(new Rect(Screen.width / 2 - 50, Screen.height * 3 / 4 - 25, 100, 50), "Try again!"))
                restart();
        }
    }

    public void restart()
    {
        round.resetRound();
        centerText.text = "";
        recorder.SetDisActive();
        roundText.text = "";
        nowState = Status.BEGIN;
    }
}