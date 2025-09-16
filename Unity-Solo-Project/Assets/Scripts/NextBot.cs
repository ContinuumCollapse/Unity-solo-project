using UnityEngine;
public class EnemyAI : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public float speed;

    void Update() 
    {
        Enemy.transform.position = Vector3.MoveTowards(Enemy.transform.position, Player.transform.position, speed);
    
    
    
    }
}

