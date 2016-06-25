using UnityEngine;
using System.Collections;

public class MovingPart : MonoBehaviour
{

    public float setBackAmount;

    protected BasicBitchPlayer player;

	// Use this for initialization
	void Start ()
    {
        player = BasicBitchPlayer.current;
    }
	
	// Update is called once per frame
	protected void Update ()
    {
        this.transform.Translate(player.MoveSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x > 8)
        {
            SetBack();
        }
    }

    public void SetBack()
    {
        transform.Translate(Random.Range(-setBackAmount - 6, -setBackAmount), 0, 0);
    }
}
