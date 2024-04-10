using UnityEngine;
using System.Collections;

public class diamondScript : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D co)
    {
        
        Debug.Log("score is at " + " point");
        if (co.name == "diamond")
        {
            Destroy(gameObject);
        }
    }
}
