using UnityEngine;

public class turt2 : MonoBehaviour
{
    float bilx = 0;
    bool turt_disapear = false;
    public float wait = 3;
    float time = 0;
    bool tr = true;
    public static int turt2_usymndlig = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bilx = transform.position.x;
        switch(turt2_usymndlig)
        {
            case 0:
                {
                    turt2_usymndlig++;
                    break;
                }
            case 1:
                turt2_usymndlig++;
                break;
            case 2:
                turt2_usymndlig++;
                break;
            case 3:
                turt2_usymndlig++;
                break;
            case 4:
                turt2_usymndlig++;
                break;
            case 5:
                turt2_usymndlig=0;
                turt_disapear=true;
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
            else if (tr == true){
                
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                Debug.Log("ikke forsvinde");
                Color color = sr.color;
                color.a = 1f;
                sr.color = color;
            }
        }
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
        else { bilx = bilx - bil1.carspeed / 4; }
        transform.position = new Vector3(bilx, transform.position.y, transform.position.z);
    }
}
