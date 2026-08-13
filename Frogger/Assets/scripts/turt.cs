using UnityEngine;

public class turt : MonoBehaviour
{
    float bilx = 0;
    int size = Random.Range(3, 7);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(size, transform.localScale.y, transform.localScale.z);
        bilx = transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
        else { bilx = bilx + bil1.carspeed / 4; }
        transform.position = new Vector3(bilx, transform.position.y, transform.position.z);
    }
}
