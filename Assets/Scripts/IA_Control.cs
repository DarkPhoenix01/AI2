using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Control : MonoBehaviour
{
    
    Transform player;
    NavMeshAgent IA;

    public Transform[] CheckPointsList;
    public int CheckPointNumber;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        IA = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < 10f)
        {
            IA.destination = player.position;
            IA.speed=7;

            if(Vector3.Distance(transform.position, player.position) < 3f)
            {
                Debug.Log("Ataque");
            }
        }else
        {
            IA.destination = CheckPointsList[CheckPointNumber].position;
            IA.speed=4;
            if(Vector3.Distance(transform.position, CheckPointsList[CheckPointNumber].position) < 3f)
            {
                
                if(CheckPointNumber < CheckPointsList.Length-1)
                {
                    CheckPointNumber++;

                }else{

                    CheckPointNumber=0;
                }
                StartCoroutine(WaitOnCheckPoint());
            }
        }
    }

    IEnumerator WaitOnCheckPoint()
    {
        IA.speed=0;
        yield return new WaitForSeconds(Random.Range(1f,3f));
        IA.speed=4;
        
    }
}