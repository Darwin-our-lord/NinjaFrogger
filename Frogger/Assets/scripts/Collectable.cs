using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]int scoreValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject.FindObjectOfType<GameManager>().GiveScore(scoreValue);
            Destroy(gameObject);
        }

    }
}
