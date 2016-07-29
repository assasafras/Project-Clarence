using UnityEngine;
using System.Collections;

/// <summary>
/// Moves a gameobject at the player's speed.
/// Should be the child of a container game object.
/// </summary>
public class MovingPart : MonoBehaviour
{

    public float setBackAmount;

    protected BasicBitchPlayer player;
    protected GameObject parentGO;

	// Use this for initialization
	void Start ()
    {
        player = BasicBitchPlayer.current;
        parentGO = this.transform.parent.gameObject;
    }
	
	// Update is called once per frame
	protected void Update ()
    {
        // Move this object based on the player's movespeed.
        this.transform.Translate(player.MoveSpeed * Time.deltaTime, 0, 0);
        if(transform.localPosition.x > 8)
        {
            this.gameObject.SetActive(false);//SetBack();
        }
    }

    public void SetBack()
    {
        transform.Translate(Random.Range(-setBackAmount - 6, -setBackAmount), 0, 0);
    }
}
