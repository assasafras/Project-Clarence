using UnityEngine;
using System.Collections;
using Assets.Scripts.PlayerScripts;
using Assets.Scripts.Interfaces;
using System;

/// <summary>
/// Moves a gameobject at the player's speed.
/// Should be the child of a container game object.
/// </summary>
public class MovingPart : MonoBehaviour, ISubscriber
{
    public float maxSetback;
    public float minSetBack;
	// Update is called once per frame
	protected void Update ()
    {
        if(transform.localPosition.x > 1)
        {
            this.gameObject.SetActive(false);// SetBack();
        }
    }

    private void SetBack()
    {
        transform.Translate(new Vector3(UnityEngine.Random.Range(maxSetback, minSetBack), 0, 0), Space.World);
        var randomXRotation = UnityEngine.Random.Range(0, 9) * 30;
        transform.localEulerAngles = new Vector3(randomXRotation, 0, 0);
    }

    void OnEnable()
    {
        SubscribeToEvents();
    }
    void OnDisable()
    {
        UnsubscribeFromEvents();
    }
    public void SubscribeToEvents()
    {
        Debug.Log(name + ".SubscribeToEvents() Called");
        Player.Current.OnMoved += OnPlayerMovedHandler;
    }

    public void UnsubscribeFromEvents()
    {
        Player.Current.OnMoved -= OnPlayerMovedHandler;
    }

    private void OnPlayerMovedHandler(float distance)
    {
        //Debug.Log(name + " - Notified of player movement, moving myself also!");
        // Move this object based on the distance "moved" by the player this frame.
        transform.Translate(new Vector3(distance, 0, 0), Space.World);
    }
}
