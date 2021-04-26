using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject player;

    private NavMeshAgent Nav;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Nav.SetDestination(player.transform.position);
    }
}
