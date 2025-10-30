using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossControllerFinal : MonoBehaviour
{
    GameObject Portal;
    GameObject musicboxtwo;
    GameObject musicbox;
    NavMeshAgent agent;
    public GameObject Spider;
    public GameObject shock;
    public GameObject slash;
    public GameObject Boss;
    public GameObject MiniBoss;
    public Transform SPAWNPOINT;
    public Transform SPAWNPOINT2;
    public bool phaseTriggered;
    public AudioSource slashSpeaker;
    public AudioSource shockSpeaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 1000;
    public int maxhealth = 1500;
    void Start()
    {
        Portal = GameObject.FindGameObjectWithTag("exit");
        musicboxtwo = GameObject.FindGameObjectWithTag("musicbox2");
        musicbox = GameObject.FindGameObjectWithTag("MUSICBOX");
        agent = GetComponent<NavMeshAgent>();
        Portal.SetActive(false);
        musicboxtwo.SetActive(false);
        if (health >= 1)
        {
            StartCoroutine(Cooldown());
            StartCoroutine(Cooldown2());
        }
    }

    // Update is called once per frame
    private void Update()
    {
        agent.destination = GameObject.Find("player").transform.position;

        if (!phaseTriggered && health <= 50)
        {
            phaseTriggered = true;
            StartCoroutine(Rage());
            StartCoroutine(Phase());

        }
        if (health <= 0)
        {
            Portal.SetActive(true);
            Destroy(gameObject);
            musicboxtwo.SetActive(false);
            //Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }



    }

    IEnumerator Rage()
    {
        health += 100;
        
        yield return new WaitForSeconds(120f);
        
       
        StartCoroutine(Rage());
    }
    IEnumerator Phase()
    {
        Instantiate(Boss, SPAWNPOINT.position, SPAWNPOINT.rotation);
        health += 1450;
        musicbox.SetActive(false);
        musicboxtwo.SetActive(true);
        yield return new WaitForSeconds(10000000f);
    }
    IEnumerator Cooldown()
    {
        if (!phaseTriggered)
        {
            yield return new WaitForSeconds(10f);

            Instantiate(shock, SPAWNPOINT.position, SPAWNPOINT.rotation);
            Instantiate(shock, SPAWNPOINT.position, SPAWNPOINT.rotation);
            shockSpeaker.Play();
            yield return new WaitForSeconds(10);
            StartCoroutine(Cooldown());
        }
           
    }
    IEnumerator Cooldown2()
    {
       
        yield return new WaitForSeconds(5f);

        Instantiate(shock, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        shockSpeaker.Play();
        slashSpeaker.Play();
        yield return new WaitForSeconds(3f);

        StartCoroutine(Cooldown2());
     
            
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
