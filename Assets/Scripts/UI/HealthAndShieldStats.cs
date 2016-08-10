using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthAndShieldStats : MonoBehaviour {

    Text txt;
	// Use this for initialization
	void Start () {
        txt = gameObject.GetComponent<Text>();
        Debug.Log("Not currently implemented...");
    }
	
	// Update is called once per frame
	void Update ()
    {
        //var player = PlayerStats.current;
        //txt.text = "Health: " + player.HP.Remaining + " / " + player.HP.Total;
        //txt.text += "\nAlive: " + player.HP.Alive;
        //txt.text += "\nShield: " + player.Shield.Remaining + " / " + player.Shield.Total;
        //txt.text += "\nShield Active: " + player.Shield.Active;
        //txt.text += "\nShield Decay Rate: " + player.Shield.DecayRate;

    }
}
