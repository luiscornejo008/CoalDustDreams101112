using UnityEngine;
using System.Collections;

public class spikeScript : MonoBehaviour
{
    public AudioClip collectedClip;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D co)
    {

        GameObject pick = GameObject.FindWithTag("Player");

        if (co.name == "Dopey Joe")
        {
            pick.GetComponent<Move>().getHit(1);
            

        }
    }
}
