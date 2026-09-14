using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    public void Die()
    {
        Debug.Log("Player dead");
        playerHealth--;
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
            // Implement game over logic here
        }
        gameObject.transform.position = new Vector3(2, -4, 0);

    }
}
