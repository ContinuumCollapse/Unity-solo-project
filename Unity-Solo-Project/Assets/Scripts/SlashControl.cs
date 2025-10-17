using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SlashControl : MonoBehaviour
{
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = GameObject.Find("player").transform.position;
        StartCoroutine(Death());

    }

    // Update is called once per frame
    private void Update()
    {

        
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(10f);

        Destroy(gameObject);

    }
}
