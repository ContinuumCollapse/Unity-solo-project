using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class BossController2 : MonoBehaviour
{
    GameObject Portal;
    GameObject musicboxtwo;
    GameObject musicbox;
    NavMeshAgent agent;
    public GameObject Spider;
    public GameObject slash;
    public GameObject MiniBoss;
    public Transform SPAWNPOINT;
    public Transform SPAWNPOINT2;
    public bool phaseTriggered;
    public AudioSource summonSpeaker;
    public AudioSource slashSpeaker;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int health = 250;
    public int maxhealth = 550;
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
            StartCoroutine(Rage2());
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
        yield return new WaitForSeconds(2f);

        Instantiate(MiniBoss, SPAWNPOINT.position, SPAWNPOINT.rotation);
        summonSpeaker.Play();
        yield return new WaitForSeconds(5f);
        
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        slashSpeaker.Play();
        yield return new WaitForSeconds(200f);

        StartCoroutine(Rage());
    }
    IEnumerator Rage2()
    {

        yield return new WaitForSeconds(9f);
        
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        slashSpeaker.Play();
        yield return new WaitForSeconds(5f);

        StartCoroutine(Rage2());
    }
    IEnumerator Phase()
    {
        StopCoroutine(Cooldown());
        StopCoroutine(Cooldown());
        StopCoroutine(Cooldown());
        health += 500;
        musicbox.SetActive(false);
        musicboxtwo.SetActive(true);
        yield return new WaitForSeconds(10000000f);
    }
    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(15f);

        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        summonSpeaker.Play();
        yield return new WaitForSeconds(20f);

        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        Instantiate(Spider, SPAWNPOINT.position, SPAWNPOINT.rotation);
        summonSpeaker.Play();
        StartCoroutine(Cooldown());
    }
    IEnumerator Cooldown2()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(slash, SPAWNPOINT2.position, SPAWNPOINT2.rotation);
        slashSpeaker.Play();
        yield return new WaitForSeconds(1f);


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
