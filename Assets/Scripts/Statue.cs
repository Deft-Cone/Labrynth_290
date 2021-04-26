using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public GameObject player;
    public AudioClip[] stoneSounds;

    private NavMeshAgent nav;
    private AudioSource sound;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        anim.GetComponent<Animator>();
    }

    public void footstep(int _num)
    {
        sound.clip = stoneSounds[_num];
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("velocity", nav.velocity.magnitude);
        // anim.SetBool("isWalking", true);
        
        nav.SetDestination(player.transform.position);
        
    }
}
