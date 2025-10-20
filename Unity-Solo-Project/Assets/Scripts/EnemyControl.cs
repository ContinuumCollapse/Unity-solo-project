using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 5;
    public int maxhealth = 5;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       

    }
    
        // Update is called once per frame
        private void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillZone")
        {
            health = 0;

        }

    }
    private void OnCollisionEnter(Collision collision) //enter is once every collison, stay is constant while collision is true
    {
        if (collision.gameObject.tag == "Hazard")
        {
            health--;
        }
       
        if (collision.gameObject.tag == "proj")
        {
            health--;

        }
        if (collision.gameObject.tag == "projSponge")
        {
            health -= 2;

        }
    }
    private void OnCollisionStay(Collision collision) //enter is once every collison, stay is constant while collision is true
    {
        if (collision.gameObject.tag == "Hazard2")
        {
            health--;
        }
    }
}
