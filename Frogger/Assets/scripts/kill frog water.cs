using UnityEngine;

public class killfrogwater : MonoBehaviour
{
    public PlayerController controller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (collision.transform.parent == null)
                {controller.Die(); }else
                {
                    

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
