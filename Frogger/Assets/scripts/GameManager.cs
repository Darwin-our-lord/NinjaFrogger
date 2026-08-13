using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool[] isGoalReached = new bool[5];
    int score = 0;
    float lastScoreTime = 0; //last time a score was counted
    public void CheckForWin()
    {
        if(isGoalReached[0] && isGoalReached[1] && isGoalReached[2] && isGoalReached[3] && isGoalReached[4])
        {
            Debug.Log("All goals reached! You win!");
        }
    }
    public void GiveGoalScore()
    {
        score+= (int)(lastScoreTime-Time.time + 1000);
    }
    public void GiveScore(int _score)
    {
        score += _score;
    }

}
