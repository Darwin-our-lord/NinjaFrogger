using UnityEngine;

public class spawnerbil : MonoBehaviour
{
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
        wait = 5;
        move = Random.Range(0, 3);
        wait = wait + move;
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }
    private void Update()
    {
 
        time += Time.deltaTime;
        if (time > wait)
        {
            Debug.Log($"you wait {wait}");
            time = 0;
            SpawnZombie();
        }
    }
}
