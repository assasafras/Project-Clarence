using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class LockedObject : MonoBehaviour
    {
        void OnDestroy()
        {
            Debug.Log("LockedObject OnDestroy called!");
            CancelInvoke();
            return;
        }
    }
}
