using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class ObjectPool : ScriptableObject
{
    public GameObject objectToPool;
    private List<GameObject> Pool;
    public int pooledAmount;
    public bool canGrow;
    public bool isInitialized = false;

    public UnityEngine.Object PooledObjectPrefab
    {
        get
        {
            var instance = PrefabUtility.InstantiatePrefab(objectToPool) as GameObject;
            //var instance = GameObject.Instantiate(obj);
            var prefab = PrefabUtility.GetPrefabParent(instance);
            PrefabType a = PrefabUtility.GetPrefabType(instance);//.ToString();
            Debug.Log(instance.ToString() + " | prefab: " + prefab.ToString() + " | type: " + a);
            GameObject.DestroyImmediate(instance);
            return prefab;
        }
    }

    public float FarthestX()
    {
        var min = float.MaxValue;
        foreach (var obj in Pool)
        {
            if (obj.activeInHierarchy && obj.transform.localPosition.x < min)
            {
                //Debug.Log(
                //    string.Format
                //        ("Found object that is active AND has local x position ({0}) which is less than current min ({1})"
                //        , obj.transform.localPosition.x
                //        , min)
                //        );
                min = obj.transform.localPosition.x;
            }
        }

        // Has max value actually been set? if not then set it to 0.
        var r = min == float.MaxValue ? 0 : min;
        //Debug.Log(string.Format("{0} - returning {1}", ExceptionUtils.GetCurrentClassAndMethod(this, ""), r));
        return r;
    }

    public void Initialize()
    {
        if (Pool == null)
        {
            Pool = new List<GameObject>();
        }
        for (int i = 0; i < pooledAmount; i++)
        {
            AddObjectToPool();
        }
        isInitialized = true;
    }

    /// <summary>
    /// Destroys all instances that this pool has created, doesn't just deactivate them. It destroys their game objects.
    /// </summary>
    public void Destroy()
    {
        foreach (var obj in Pool)
        {
            // Remove the object from the game.
            GameObject.Destroy(obj);
        }
        // Null the reference of the Pool to claim back it's memory (when the GC runs).
        Pool.Clear();
        Pool = null;
    }
    
    /// <summary>
    /// Creates an instance of the pooled object and automatically sets its parent
    /// to the game object that has the same name as the tag on the gameobject.
    /// The GameObject is also deactivated.
    /// </summary>
    private void AddObjectToPool()
    {
        var go = Instantiate(objectToPool);
        Pool.Add(go);
        go.name += Pool.Count.ToString();
        var parent = GameObject.Find("Poolables");
        go.transform.SetParent(parent.transform);
        go.SetActive(false);
    }

    /// <summary>
    /// Get a Pooled object if any are available. Will be spawned with a zero position and rotation.
    /// </summary>
    /// <returns>A GameObject clone of <see cref="objectToPool"/>, or null if there are no objects left int the pool</returns>
    public GameObject GetObjectFromPool()
    {
        return GetObjectFromPool(Vector3.zero);
    }

    /// <summary>
    /// Get a Pooled object if any are available. Will be spawned with a zero rotation.
    /// </summary>
    /// <param name="position">The position that you want the object to be "spawned" at.</param>
    /// <returns>A GameObject clone of <see cref="objectToPool"/>, or null if there are no objects left int the pool</returns>
    private GameObject GetObjectFromPool(Vector3 position)
    {
        return GetObjectFromPool(position, Quaternion.identity);
    }

    /// <summary>
    /// Get a Pooled object if any are available.
    /// </summary>
    /// <param name="position">The position that you want the object to be "spawned" at.</param>
    /// <param name="rotation">The rotation that you want the object to be "spawned" at.</param>
    /// <returns>A GameObject clone of <see cref="objectToPool"/>, or null if there are no objects left int the pool</returns>
    public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
    {
        // Find an object in the pool that is not active.
        foreach (var obj in Pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                // Activate the object before returning it.
                obj.SetActive(true);
                return obj;
            }
        }
        // No more objects left in the pool!

        // Are we allow to add anymore?
        if (canGrow)
        {
            // Sure, why not! Go ahead, add another one!
            AddObjectToPool();
            // Now we have a spare object return it to the caller.
            return Pool[Pool.Count - 1];
        }
        else
            // Nope, can't grow, so return null.
            return null;
    }

    public void DeActivateAll()
    {
        foreach (var obj in Pool)
        {
            obj.SetActive(false);
        }
    }
}
