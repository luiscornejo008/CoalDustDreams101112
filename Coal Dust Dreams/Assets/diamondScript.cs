using UnityEngine;
using System.Collections;

public class diamondScript : MonoBehaviour
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
            pick.GetComponent<Move>().getMoney(1);
            Destroy(gameObject);

        }
    }
}
