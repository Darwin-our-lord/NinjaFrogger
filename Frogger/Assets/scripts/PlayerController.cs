using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int playerHealth = 3;
    [SerializeField] GameObject deathUI;
    public void Die()
    {
        Debug.Log("Player dead");
        playerHealth--;
        if (playerHealth <= 0)
        {
            Debug.Log("Game Over");
            deathUI.SetActive(true);
            Time.timeScale = 0f;
        }
        gameObject.transform.position = new Vector3(2, -4, 0);

    }
}
