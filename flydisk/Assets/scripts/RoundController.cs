using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {
    public Text roundText;
    public Text centerText;
    // 外部引用

    SceneController scene;
    Count count;
    ScoreRecorder recorder;
    DiskActionManager actionManager;
    // 类间引用

    int round;

    // Use this for initialization
    void Start()
    {
        scene = Singleton<SceneController>.Instance;
        count = Singleton<Count>.Instance;
        actionManager = Singleton<DiskActionManager>.Instance;
        recorder = scene.recorder;
    }

    // Update is called once per frame
    void Update()
    {
        if (scene.nowState == Status.WATING)
        // 等待阶段
        {
            centerText.text = "按ENTER键开始游戏！";
            if (Input.GetKeyDown("return"))
            {
                count.beginCount();
                roundText.text = "Round:" + round;
                recorder.SetActive();
                scene.nowState = Status.COUNTING;
                // 开始计数
            }
        }
    }

    public void runRound()
    {
        actionManager.runActionByRound(round);
    }

    public void NextRound()
    {
        round++;
        roundText.text = "Round:" + round;
        recorder.SetActive();
    }

    public void resetRound()
    {
        round = 1;
    }
}
