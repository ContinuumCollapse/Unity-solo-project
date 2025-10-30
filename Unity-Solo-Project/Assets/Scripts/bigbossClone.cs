using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossControllerFinalClone : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject slash;
    public Transform SPAWNPOINT;
    public Transform SPAWNPOINT2;
    public AudioSource slashSpeaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 600;
    public int maxhealth = 600;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (health >= 1)
        {
            StartCoroutine(Rage());
            StartCoroutine(Cooldown());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;

        if (health <= 0)
        {   
            Destroy(gameObject);
            //Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }

    IEnumerator Rage()
    {

        yield return new WaitForSeconds(2f);
        
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        slashSpeaker.Play();
        yield return new WaitForSeconds(3f);
        
       
        StartCoroutine(Rage());
    }
    IEnumerator Cooldown()
    {
       
        yield return new WaitForSeconds(2);

        Instantiate(slash, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(slash, SPAWNPOINT.position, SPAWNPOINT.rotation);
        slashSpeaker.Play();
        yield return new WaitForSeconds(2);
       
        StartCoroutine(Cooldown());

           
    }
    
    private void OnTriggerEnter(Collider other)
    {


    }
    private void OnCollisionEnter(Collision collision) //enter is once every collison, stay is constant while collision is true
    {

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
       
    }
}
