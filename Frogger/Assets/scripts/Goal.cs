using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] int goalIndex;

    [SerializeField] bool activeExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        if (!activeExit) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.isGoalReached[goalIndex] = true;
            gameManager.CheckForWin();
            gameManager.GiveGoalScore();
            collision.transform.position = new Vector3(0, 0, 0);
            activeExit = false;
            this.GetComponent<SpriteRenderer>().color = Color.hotPink;
            Debug.Log("Goal reached!");
        }

    }
}
