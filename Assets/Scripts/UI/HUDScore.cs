using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUDScore : MonoBehaviour
{
    private BasicBitchPlayer player;
    private Text txt;

    // Use this for initialization
    void Start ()
    {
        txt = gameObject.GetComponent<Text>();
        player = BasicBitchPlayer.current;
	}
	
	// Update is called once per frame
	void Update ()
    {
        var curr = BasicBitchPlayer.current;
        var score = curr.score;
        txt.text = "Score: " + score.ToString();
	}
}
