using Assets.Scripts.Events;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    /// <summary>
    /// Manages loading and unloading chunks at runtime.
    /// </summary>
    public class ChunkManager : MonoBehaviour, ISubscriber
    {
        public ObjectPoolManager poolManager;
        /// <summary>
        /// Set from within editor.
        /// </summary>
        public List<Chunk> chunks;

        void OnEnable()
        {
            SubscribeToEvents();
        }

        public void OnDestroy()
        {
            Debug.Log("OnDestroy Called!");
        }

        void OnDisable()
        {
            Debug.Log("OnDisable Called!");
            UnsubscribeFromEvents();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                LoadSpecificChunk(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                LoadSpecificChunk(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                LoadSpecificChunk(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                LoadRandomChunk();
            }
        }

        void ObjectPoolsInitializedHandler(object sender, ObjectPoolsInitializedEventArgs e)
        {
            Debug.Log(ExceptionUtils.GetCurrentMethod());
            // For shits and giggles load a random chunk!
            LoadRandomChunk();
        }

        public void LoadRandomChunk()
        {
            var i = Random.Range(0, chunks.Count - 1);
            LoadSpecificChunk(i);
        }

        public void LoadSpecificChunk(int index)
        {
            //Debug.Log(ExceptionUtils.GetCurrentMethod() + "(" + index + ")");
            var selectedChunk = chunks[index];

            var max = ObjectPoolList.FarthestX(poolManager.ObjectPooler);
            var offset = new Vector3(max, 0);
            foreach (var piece in selectedChunk.Pieces)
            {
                // Figure out which pool to get the object from
                var name = piece.Prefab.name;
                var pool = poolManager.ObjectPooler.GetPoolByName(name);

                //Debug.Log(string.Format("{0} - max being set to {1}", ExceptionUtils.GetCurrentClass(this) + "." + ExceptionUtils.GetCurrentMethod(), max));
                
                // Now add in all objects required to fill out the chunk.
                // Also note that the objects will (should) be parented to 
                // appropriate objects so it should just be a matter of applying the transforms
                foreach (var t in piece.Transforms)
                {
                    var instance = pool.GetObjectFromPool();
                    if (instance == null)
                    {
                        Debug.Log("Oh crap! We ran out of " + pool.objectToPool.name + "'s!");
                        return;
                    }
                    // Set the instanced game object's local transform
                    instance.transform.localPosition = (t.Position + offset);
                    instance.transform.localRotation = t.Rotation;
                    instance.transform.localScale = t.Scale;
                    //Debug.Log(string.Format("Creating instance {0} at local position: {1}", instance.name, instance.transform.localPosition));
                }
            }
        }

        public void SubscribeToEvents()
        {
            poolManager.RaiseObjectPoolsInitialized += ObjectPoolsInitializedHandler;
        }

        public void UnsubscribeFromEvents()
        {
            poolManager.RaiseObjectPoolsInitialized -= ObjectPoolsInitializedHandler;
        }
    }
}
