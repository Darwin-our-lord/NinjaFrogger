using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int goalIndex;

    bool activeExit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!activeExit) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isGoalReached[goalIndex] = true;
            gameManager.CheckForWin();
            gameManager.GiveGoalScore();
            collision.otherCollider.transform.position = new Vector3(0, 0, 0);
            activeExit = false;
            this.GetComponent<SpriteRenderer>().color = Color.hotPink;
            Debug.Log("Goal reached!");
        }

    }
}
