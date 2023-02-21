using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivate : MonoBehaviour
{
    public Animator eniani;
    public GameObject player;

    public void InActive()
    {
        eniani.SetBool("active", false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            player.GetComponent<PlayerController>().aHit(gameObject);
        }
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "player")
        {
            player.GetComponent<PlayerController>().aHit(gameObject);
        }
    }
}
