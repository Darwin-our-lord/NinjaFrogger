using UnityEngine;

public class PlayerTREE : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.SetParent(collision.transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.SetParent(null);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
