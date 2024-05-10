using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDScript : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text diamondText;
    public GameObject pick;
    
    // Start is called before the first frame update
    void Start()
    {
        
        healthText.SetText("Health: " + pick.GetComponent<Move>().checkHealth());
        diamondText.SetText("Diamonds: " + pick.GetComponent<Move>().checkDiamonds());
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.SetText("Health: " + pick.GetComponent<Move>().checkHealth());
        diamondText.SetText("Diamonds: " + pick.GetComponent<Move>().checkDiamonds());
    }
}
