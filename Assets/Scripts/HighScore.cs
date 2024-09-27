using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_TEXT;
    static private int _SCORE = 0;
    private Text txtCom;
    // Start is called before the first frame update

    void Awake()
    {
        _UI_TEXT = GetComponent<Text>();
        if(PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        else
            PlayerPrefs.SetInt("HighScore", SCORE);
    }
    static public int SCORE{
        get{return _SCORE;}
        private set {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if(_UI_TEXT != null)
            {
                _UI_TEXT.text = "High Score: " + value.ToString("#,0");
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {
        if(scoreToTry <= SCORE) return;
        SCORE = scoreToTry;
    }
}
