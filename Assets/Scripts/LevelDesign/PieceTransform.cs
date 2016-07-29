using System;
using UnityEngine;

namespace Assets.Scripts.LevelDesign
{
    [Serializable]
    public class PieceTransform
    {

        [SerializeField, HideInInspector]
        private Vector3 position;
        public Vector3 Position { get { return position; } private set { position = value; } }

        [SerializeField, HideInInspector]
        private Vector3 scale;
        public Vector3 Scale { get { return scale; } private set { scale = value; } }

        public Vector3 EulerAngles
        {
            get { return Rotation.eulerAngles; }
        }

        [SerializeField, HideInInspector]
        private Quaternion rotation;
        public Quaternion Rotation { get { return rotation; } private set { rotation = value; } }

        //[SerializeField, HideInInspector]
        //private UnityEngine.Object prefab;
        //public UnityEngine.Object Prefab { get { return prefab; } private set { prefab = value; } }

        // Constructors, constructors everywhere...
        public PieceTransform(/*UnityEngine.Object piece,*/ Vector3 pos) : this(/*piece,*/ pos, Quaternion.identity) { }
        public PieceTransform(/*UnityEngine.Object piece,*/ Vector3 pos, Quaternion rot) : this(/*piece,*/ pos, rot, Vector3.one) { }
        public PieceTransform(/*UnityEngine.Object piece,*/ Vector3 pos, Quaternion rot, Vector3 scale)
        {
            //this.prefab      = piece;
            this.position = pos;
            this.rotation = rot;
            this.scale = scale;
        }
        public PieceTransform(/*UnityEngine.Object piece,*/ PieceTransform ct)
            : this(/*piece,*/ ct.Position, ct.Rotation, ct.Scale)
        { }
        public PieceTransform(UnityEngine.Object piece, Transform t)
            : this(/*piece,*/ t.localPosition, t.localRotation, t.localScale)
        { }

        //public ChunkTransform(ChunkTransform ct)
        //: this(/*ct.Prefab,*/ ct.Position, ct.Rotation, ct.Scale) { }

        public PieceTransform(GameObject go)
            : this
                (go.transform.localPosition
                  , go.transform.localRotation
                  , go.transform.localScale
                 )
        { }

        // Constructors finished!

        static PieceTransform DeepClone(PieceTransform ct)
        {
            return new PieceTransform(ct);
        }
    }
}
