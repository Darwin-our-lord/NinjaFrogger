using UnityEngine;

public class turt : MonoBehaviour
{
    float bilx = 0;

    [SerializeField] float carspeed = 0.1f;
    bool turt_disapear = false;
    public float wait = 3;
    float time = 0;
    bool tr = true;
    public static int turt_usymndlig = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        bilx = transform.position.x;
        switch (turt_usymndlig)
        {
            case 0:
                {
                turt_usymndlig++;
                break;
                }
            case 1:
                turt_usymndlig++;
                break;
            case 2:
                turt_usymndlig++;
                Destroy(gameObject);
                break;
            case 3:
                turt_usymndlig = 0;
                turt_disapear = true;
                break;
            case 4:
                turt_usymndlig++;
                break;
            case 5:
                turt_usymndlig++;
                break;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (turt_disapear == true)
        {
            time += Time.deltaTime;
            if (time > wait)
            {
                tr = !tr;
                Debug.Log("forsvinder");
                time = 0;
                // chat
                SpriteRenderer sr = GetComponent<SpriteRenderer>();

                Color color = sr.color;
                color.a = 0.5f;
                sr.color = color;

            }
            else if (tr == true)
            {

                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                Debug.Log("ikke forsvinde");
                Color color = sr.color;
                color.a = 1f;
                sr.color = color;
            }
        }
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
