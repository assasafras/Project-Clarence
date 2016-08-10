using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public enum Vector3Axis
    {
        X, Y, Z, IGNORE
    }
    [ExecuteInEditMode]
    public class TransformLink : MonoBehaviour
    {
        public GameObject linkedObject;
        public bool inheritPosition;
        public Vector3Axis positionMappingXAxis = Vector3Axis.X;
        public Vector3Axis positionMappingYAxis = Vector3Axis.Y;
        public Vector3Axis positionMappingZAxis = Vector3Axis.Z;
        public bool inheritRotation;
        public Vector3Axis rotationMappingXAxis = Vector3Axis.X;
        public Vector3Axis rotationMappingYAxis = Vector3Axis.Y;
        public Vector3Axis rotationMappingZAxis = Vector3Axis.Z;

        private Vector3 startRotation;
        private Vector3 startPosition;

        void Awake()
        {
            startPosition = transform.localPosition;
            startRotation = transform.eulerAngles;
        }

        void Update()
        {
            if (inheritPosition)
            {
                transform.localPosition = startPosition + MapPositionAxis(linkedObject.transform.localPosition);
            }
            if (inheritRotation)
            {
                transform.eulerAngles = startRotation + MapRotationAxis(linkedObject.transform.eulerAngles);
            }
        }

        private Vector3 MapPositionAxis(Vector3 vector)
        {
            var newVector = Vector3.zero;
            switch (positionMappingXAxis)
            {
                case Vector3Axis.X:
                    newVector.x = vector.x;
                    break;
                case Vector3Axis.Y:
                    newVector.x = vector.y;
                    break;
                case Vector3Axis.Z:
                    newVector.x = vector.z;
                    break;
            }

            switch (positionMappingYAxis)
            {
                case Vector3Axis.X:
                    newVector.y = vector.x;
                    break;
                case Vector3Axis.Y:
                    newVector.y = vector.y;
                    break;
                case Vector3Axis.Z:
                    newVector.y = vector.z;
                    break;
            }
            switch (positionMappingZAxis)
            {
                case Vector3Axis.X:
                    newVector.z = vector.x;
                    break;
                case Vector3Axis.Y:
                    newVector.z = vector.y;
                    break;
                case Vector3Axis.Z:
                    newVector.z = vector.z;
                    break;
            }
            return newVector;
        }

        private Vector3 MapRotationAxis(Vector3 vector)
        {

            var newVector = Vector3.zero;
            switch (rotationMappingXAxis)
            {
                case Vector3Axis.X:
                    Debug.Log("Mapping in X -> out X");
                    newVector.x = vector.x;
                    break;
                case Vector3Axis.Y:
                    Debug.Log("Mapping in X -> out Y");
                    newVector.y = vector.x;
                    break;
                case Vector3Axis.Z:
                    Debug.Log("Mapping in X -> out Z");
                    newVector.z = vector.x;
                    break;
            }

            switch (rotationMappingYAxis)
            {
                case Vector3Axis.X:
                    Debug.Log("Mapping in Y -> out X");
                    newVector.x = vector.y;
                    break;
                case Vector3Axis.Y:
                    Debug.Log("Mapping in Y -> out Y");
                    newVector.y = vector.y;
                    break;
                case Vector3Axis.Z:
                    Debug.Log("Mapping in Y -> out Z");
                    newVector.z = vector.y;
                    break;
            }
            switch (rotationMappingZAxis)
            {
                case Vector3Axis.X:
                    Debug.Log("Mapping in Z -> out X");
                    newVector.x = vector.z;
                    break;
                case Vector3Axis.Y:
                    Debug.Log("Mapping in Z -> out Y");
                    newVector.y = vector.z;
                    break;
                case Vector3Axis.Z:
                    Debug.Log("Mapping in Z -> out Z");
                    newVector.z = vector.z;
                    break;
            }
            Debug.Log("MapRotationAxis(" + vector + ") returning " + newVector);
            return newVector;
        }
    }
}
