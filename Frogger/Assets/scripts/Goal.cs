using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int goalIndex;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isGoalReached[goalIndex] = true;
            gameManager.CheckForWin();
            gameManager.GiveGoalScore();
            collision.otherCollider.transform.position = new Vector3(0, 0, 0);
            Debug.Log("Goal reached!");
        }

    }
}
