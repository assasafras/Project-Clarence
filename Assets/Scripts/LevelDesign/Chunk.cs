using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [Serializable]
    public class Chunk : ScriptableObject
    {
        [SerializeField]
        private List<Piece> pieces;
        public List<Piece> Pieces
        {
            get { return pieces; }
            private set
            {
                pieces = value;
            }
        }

        void OnEnable()
        {
            if (Pieces == null)
                Pieces = new List<Piece>();
        }

        public void LoadAllPiecesIntoScene()
        {
            foreach (var piece in Pieces)
            {
                piece.LoadIntoScene();
            }
        }
    }
}
