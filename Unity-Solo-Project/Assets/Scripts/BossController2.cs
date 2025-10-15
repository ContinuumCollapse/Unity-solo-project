using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System.Collections;

public class BossController2 : MonoBehaviour
{
    GameObject Portal;
    NavMeshAgent agent;
    public GameObject Spider;
    public GameObject Spider2;
    public Transform SPAWNPOINT;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 500;
    public int maxhealth = 9999999;
    void Start()
    {
        Portal = GameObject.FindGameObjectWithTag("exit");
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

        if (health <= 50)
        {
            health += 999999;
            Portal.SetActive(true);
            //Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(Rage());
            StopCoroutine(Cooldown());
        }
       


    }

    IEnumerator Rage()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(Spider2, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider2, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider2, SPAWNPOINT.position, SPAWNPOINT.rotation);

        StartCoroutine(Rage());
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
    }
    private void OnCollisionStay(Collision collision) //enter is once every collison, stay is constant while collision is true
    {
        if (collision.gameObject.tag == "Hazard2")
        {
            health--;
        }
    }
}
