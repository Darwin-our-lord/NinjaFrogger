using UnityEngine;

public class CarMove : MonoBehaviour
{
    [SerializeField] float carspeed = 0.1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.position = new Vector3(transform.position.x + carspeed / 2, transform.position.y, transform.position.z);
        }
    }
}
