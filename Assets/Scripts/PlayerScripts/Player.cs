using Assets.Scripts.Utils;
using Assets.Scripts.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.PlayerScripts
{
    public partial class Player : MonoBehaviour
    {
        //private PlayerController controller;
        //public static PlayerController Controller { get { return (Current == null) ? null : Current; } }

        public static Player Current { get; private set; }

        void Awake()
        {
            Current = this;
            Debug.Log("Player.Awake() Current: " + ((Current == null) ? "null" : Current.name));
            Shield = GetComponent<Shield>();
            HP = GetComponent<HitPoints>();
            PrimaryWeapon = GetComponent<BaseWeapon>();
        }

        public void OnDestroy()
        {
            Current = null;
        }
    }
}
