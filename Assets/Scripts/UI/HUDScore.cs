using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts.PlayerScripts;

public class HUDScore : MonoBehaviour
{
    private Text txt;

    // Use this for initialization
    void Start ()
    {
        txt = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var score = "Not Implemented";//Player.Current.score;
        txt.text = "Score: " + score.ToString();
	}
}
