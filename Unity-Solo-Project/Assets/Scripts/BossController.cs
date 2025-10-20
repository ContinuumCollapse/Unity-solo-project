using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossController : MonoBehaviour
{
    GameObject Portal;
    GameObject musicbox;
    NavMeshAgent agent;
    public GameObject Spider;
    public Transform SPAWNPOINT;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 150;
    public int maxhealth = 150;
    void Start()
    {
        Portal = GameObject.FindGameObjectWithTag("exit");
        musicbox = GameObject.FindGameObjectWithTag("MUSICBOX");
        agent = GetComponent<NavMeshAgent>();
        Portal.SetActive(false);
        if (health >= 1)
        {
            StartCoroutine(Cooldown());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;

        if (health <= 0)
        {
            musicbox.SetActive(false);
            Portal.SetActive(true);
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }
       


    }

    
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(10f);
        
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);

        yield return new WaitForSeconds(15f);

        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        
        StartCoroutine(Cooldown());
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
