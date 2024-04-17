using UnityEngine;
using System.Collections;

public class boostScript : MonoBehaviour
{
    public AudioClip collectedClip;
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D co)
    {

        GameObject pick = GameObject.FindWithTag("Player");

        if (co.name == "pickaxe")
        {
            pick.GetComponent<Move>().getSuper();
            Destroy(gameObject);

        }
    }
}
