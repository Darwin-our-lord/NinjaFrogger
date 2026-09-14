using UnityEngine;

public class spawnerbil : MonoBehaviour
{
    float turt_usyg = 0f;
    public GameObject zombiePrefab;
    public Transform spawnPoint;
    public float wait = 5;
    float time = 0;
    float move = 0;
    private void Start()
    {
    }
    void SpawnZombie()
    {
        turt_usyg++;
        if (turt_usyg >= 5) { turt_usyg = 0; }
        wait = 5;
        move = Random.Range(0, 3);
        wait = wait + move;
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
        turt turle = zombiePrefab.GetComponent<turt>();
        turle.turt_usymndlig = turt_usyg;

    }
    private void Update()
    {
 
        time += Time.deltaTime;
        if (time > wait)
        {
            time = 0;
            SpawnZombie();
        }
    }
}
