using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Monster : MonoBehaviour
{
    private NavMeshAgent AI_Agent;
    private GameObject Player;
    public GameObject Panel_GaveOver;

    void Start()
    {
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        AI_Agent.SetDestination(Player.transform.position);
        float Dist_Player = Vector3.Distance(Player.transform.position, gameObject.transform.position);
        if (Dist_Player < 2)
        {
            Player.SetActive(false);
            Panel_GaveOver.SetActive(true);
        }
    }
}
