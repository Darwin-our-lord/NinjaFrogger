using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool[] isGoalReached = new bool[5];
    [SerializeField] GameObject ScoreText;
    static int score = 0;
    float lastScoreTime = 0; //last time a score was counted
    public void CheckForWin()
    {
        if(isGoalReached[0] && isGoalReached[1] && isGoalReached[2] && isGoalReached[3] && isGoalReached[4])
        {
            Application.LoadLevel(Application.loadedLevel);
            Debug.Log($"{score}");
        }
    }
    public void GiveGoalScore()
    {
        score+= (int)(lastScoreTime-Time.time + 1000);
        UpdateScoreText();
    }
    public void GiveScore(int _score)
    {
        score += _score;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        ScoreText.GetComponent<TMP_Text>().text = "SCORE: " + score;
    }

}
