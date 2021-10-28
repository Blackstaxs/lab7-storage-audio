using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Linq;

public class GameController : MonoBehaviour
{
    public int highScore= 0;
    public int top2 = 0;
    public int top3 = 0;
    public int top4 = 0;
    public int top5 = 0;
    const string fileName = "/highscore.dat";
    public static GameController gCtrl;
    // Start is called before the first frame update

    public void Awake() 
    { 
        if (gCtrl == null) 
        { 
            DontDestroyOnLoad(gameObject); 
            gCtrl = this; 
            LoadScore();
        } 
    }

    [Serializable] 
    class GameData
    {
        public int score;
        public int score2;
        public int score3;
        public int score4;
        public int score5;
    };

    public void LoadScore() 
    { 
        if (File.Exists(Application.persistentDataPath + fileName)) 
        { 
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read); 
            GameData data = (GameData)bf.Deserialize(fs); 
            fs.Close(); 
            gCtrl.highScore = data.score;
            gCtrl.top2 = data.score2;
            gCtrl.top3 = data.score3;
            gCtrl.top4 = data.score4;
            gCtrl.top5 = data.score5;
        } 
    }

    public void SaveScore(int score) 
    {
        if (score > gCtrl.highScore) 
        {
            gCtrl.top5 = gCtrl.top4;
            gCtrl.top4 = gCtrl.top3;
            gCtrl.top3 = gCtrl.top2;
            gCtrl.top2 = gCtrl.highScore;
            gCtrl.highScore = score; 
            BinaryFormatter bf = new BinaryFormatter(); 
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate); 
            GameData data = new GameData(); 
            data.score = score;
            data.score2 = gCtrl.top2;
            data.score3 = gCtrl.top3;
            data.score4 = gCtrl.top4;
            data.score5 = gCtrl.top5;
            bf.Serialize(fs, data); 
            fs.Close();
        } 
        if((score < gCtrl.highScore) && (score > top2))
        {
            gCtrl.top5 = gCtrl.top4;
            gCtrl.top4 = gCtrl.top3;
            gCtrl.top3 = gCtrl.top2;
            gCtrl.top2 = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
            GameData data = new GameData();
            data.score = score;
            data.score2 = gCtrl.top2;
            data.score3 = gCtrl.top3;
            data.score4 = gCtrl.top4;
            data.score5 = gCtrl.top5;
            bf.Serialize(fs, data);
            fs.Close();
        }
        if ((score < gCtrl.top2) && (score > top3))
        {
            gCtrl.top5 = gCtrl.top4;
            gCtrl.top4 = gCtrl.top3;
            gCtrl.top3 = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
            GameData data = new GameData();
            data.score = score;
            data.score3 = gCtrl.top3;
            data.score4 = gCtrl.top4;
            data.score5 = gCtrl.top5;
            bf.Serialize(fs, data);
            fs.Close();
        }
        if ((score < gCtrl.top3) && (score > top4))
        {
            gCtrl.top5 = gCtrl.top4;
            gCtrl.top4 = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
            GameData data = new GameData();
            data.score = score;
            data.score4 = gCtrl.top4;
            data.score5 = gCtrl.top5;
            bf.Serialize(fs, data);
            fs.Close();
        }
        if ((score < gCtrl.top4) && (score > top5))
        {
            gCtrl.top5 = score;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
            GameData data = new GameData();
            data.score = score;
            data.score5 = gCtrl.top5;
            bf.Serialize(fs, data);
            fs.Close();
        }
    }

    public int GetCurrentScore() 
    { 
        return PlayerPrefs.GetInt("CurrentScore"); 
    }
    public void SetCurrentScore(int num) 
    { 
        PlayerPrefs.SetInt("CurrentScore", num);
    }

    public void AddScorePressed() 
    { 
        int score = GetCurrentScore(); 
        score++; SetCurrentScore(score); 
        SaveScore(score); 
    }
    public void MinusScorePressed() 
    { 
        int score = GetCurrentScore(); 
        score--; 
        SetCurrentScore(score); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
