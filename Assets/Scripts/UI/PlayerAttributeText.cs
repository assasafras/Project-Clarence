using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAttributeText : MonoBehaviour {

    Text t;
    BasicBitchPlayer p;
	// Use this for initialization
	void Awake ()
    {
        t = gameObject.GetComponent<Text>();
        p = GameObject.Find("Player").GetComponent<BasicBitchPlayer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //t.text = p.GetAttributeString();
	}
}
