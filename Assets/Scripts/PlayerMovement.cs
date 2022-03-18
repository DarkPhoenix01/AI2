using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerMovement : MonoBehaviour
{
    
    NavMeshAgent player;    
    
    void Start()
    {
        player = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        ClickMovement();
    }


    void ClickMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                player.destination = hit.point;
            }
        }
    }
}