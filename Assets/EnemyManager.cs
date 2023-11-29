using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Enemy[] enemies = GetComponentsInChildren<Enemy>();
        foreach (Enemy e in enemies)
        {
            e.player = this.player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
