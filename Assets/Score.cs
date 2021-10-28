using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    // Update is called once per frame
    void Update()
    {
        text.text=   "Score: "+   GameController.gCtrl.GetCurrentScore();
    }
}
