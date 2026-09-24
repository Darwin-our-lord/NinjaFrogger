using System.Collections;
using UnityEngine;

public class killfrogwater : MonoBehaviour
{
    public PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        StartCoroutine(killDelay(collision));
    }

    IEnumerator killDelay(Collider2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (collision.transform.parent == null)
                { controller.Die(); }
            }
        }
    }
}
