using TMPro;
using UnityEngine;
public class Score : MonoBehaviour
{
    
    //private int ScoreInt;
    //public Text ScoreText;

    private TMP_Text _score;

    public static Score Instance { get; set; } 

    private void Start()
    {
        if (Instance == null) Instance = this;
        _score = gameObject.GetComponent<TMP_Text>();
    }

    private void Update()
    {
       // UpdateScore();
    }

    public void UpdateScore()
    {
        _score.text = PlayerMovement.Instance._score.ToString();
    }
}
