using Assets.Scripts.Events;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    /// <summary>
    /// This class managaes initializing object pools at runtime.
    /// </summary>
    public class ObjectPoolManager : MonoBehaviour
    {
        public ObjectPoolList ObjectPooler;

        public delegate void ObjectPoolsInitializedHandler(object sender, ObjectPoolsInitializedEventArgs e);

        public event ObjectPoolsInitializedHandler RaiseObjectPoolsInitialized = delegate { };
        /// <summary>
        /// Called when the game starts regardless of if the object is enabled or disabled.
        /// Tears down any game objects created through Chunks, cleaning up for play mode.
        /// </summary>
        void Awake()
        {
            CleanUpScene();
            foreach (var pool in ObjectPooler.ObjectPools)
            {
                pool.Initialize();
            }
            RaiseObjectPoolsInitialized(this, new ObjectPoolsInitializedEventArgs());
        }

        private void CleanUpScene()
        {
            //foreach (var pool in ObjectPooler.ObjectPools)
            //{
            //    var tag = pool.objectToPool.tag;
            //    var o = GameObject.FindObjectsOfType<PleaseDONTDeleteMe>();
            var parent = GameObject.Find("Poolables");
            while (parent.gameObject.transform.childCount > 0)
            {
                var t = parent.gameObject.transform.GetChild(0);
                var go = t.gameObject;
                DestroyImmediate(go);
            }
            //}
        }

        /// <summary>
        /// Called when this object is destroyed (so at the end of the game ideally).
        /// Causes all pools held in the Object Pooler to self destruct, cleaning up ready for
        /// edit mode.
        /// </summary>
        void OnDestroy()
        {
            foreach (var pool in ObjectPooler.ObjectPools)
            {
                pool.Destroy();
            }
        }
    }
}
