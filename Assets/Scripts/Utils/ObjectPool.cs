using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

[Serializable]
public class ObjectPool : ScriptableObject
{
    public GameObject objectToPool;
    private List<GameObject> Pool;
    public int pooledAmount;
    public bool canGrow;

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
    }

    private void AddObjectToPool()
    {
        Pool.Add(Instantiate(objectToPool));
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
        // Find an object in the pool that is active.
        foreach (var obj in Pool)
        {
            if (obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                return obj;
            }
        }
        // No more objects left in the pool!

        // Are we allow to add anymore?
        if (canGrow)
        {
            // Sure, why not! Go ahead and add another one!
            AddObjectToPool();
            // Now we have a spare object return oit to the caller.
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
