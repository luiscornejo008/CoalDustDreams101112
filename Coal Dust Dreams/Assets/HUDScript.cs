using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TMP_Text healthText;
    public GameObject pick;
    
    // Start is called before the first frame update
    void Start()
    {
        
        healthText.SetText("Health: " + pick.GetComponent<Move>().checkHealth());
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.SetText("Health: " + pick.GetComponent<Move>().checkHealth());
    }
}
