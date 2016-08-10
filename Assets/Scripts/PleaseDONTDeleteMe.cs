using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Dummy class to attach to objects that we do not want to be deleted within the editor.
/// </summary>
public class PleaseDONTDeleteMe : MonoBehaviour
{
    public Guid id = new Guid();
}