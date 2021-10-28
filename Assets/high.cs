using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class high : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    // Update is called once per frame
    void Update()
    {
        text.text = "TOP 1: " + GameController.gCtrl.highScore;
        text1.text = "TOP 2: " + GameController.gCtrl.top2;
        text2.text = "TOP 3: " + GameController.gCtrl.top3;
        text3.text = "TOP 4: " + GameController.gCtrl.top4;
        text4.text = "TOP 5: " + GameController.gCtrl.top5;
    }
}
