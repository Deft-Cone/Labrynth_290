using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Player;
    public float Speed;
    public bool isLooking;


    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        Ray playerGaze = new Ray(Player.transform.position, Player.transform.forward);

        if(Physics.Raycast(playerGaze, out Hit))
        {
            if(Hit.collider.tag.Equals("Enemy"))
            {
                Speed = 0f;
            }
            else
            {
                Speed = 5f;
            }
        }

        transform.position = Vector3.MoveTowards (transform.position, Player.transform.position, Speed * Time.deltaTime);
    }

}
