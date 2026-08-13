using UnityEngine;

public class bil1 : MonoBehaviour
{
    public static float carspeed = 0.1f;
    float bilx = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bilx = transform.position.x; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= 10)
        {
            Destroy(gameObject);
        } else { bilx = bilx + carspeed/2; }
        transform.position = new Vector3(bilx, transform.position.y,transform.position.z);
    }
}
