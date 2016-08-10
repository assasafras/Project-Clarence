using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor;
using Assets.Scripts.PlayerScripts;

[ExecuteInEditMode]
public abstract class HUDCustomBar : MonoBehaviour
{
    public GameObject target;
    public GameObject fill;

    /// <summary>
    /// The total width on the screen that all elements will occupy.
    /// Each element's width will be the totalWidth / totalElements (set in the Instantiate method).
    /// </summary>
    public int totalWidth;
    private int _totalWidth;

    /// <summary>
    /// The height of each element.
    /// </summary>
    public int height;


    /// <summary>
    /// The position of each image from the center of the screen.
    /// </summary>
    public Vector2 position;
    private Vector2 _position;

    /// <summary>
    /// The total number of elements that will exist.
    /// </summary>
    protected int totalElements;

    protected List<GameObject> fillImages;
    private int _previousTotalWidth;
    private int _previousHeight;
    private Vector2 _previousPosition;

    //[ExecuteInEditMode]
    void Awake()
    {
        //print("HUD Custom Bar - Awake Called!");
        Recreate();
    }
    void Start()
    {
        //print("HUD Custom Bar - Start Called!");
        Recreate();
    }

    protected void Recreate()
    {
        //print("HUD Custom Bar - Recreate Called!");
        DestroyElements();

        Instatiate();

        CreateElements();
    }

    private void DestroyElements()
    {
        //print("HUD Custom Bar - DestroyElements Called!");
        fillImages = null;
        while (transform.childCount != 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    protected virtual void Update()
    {
        // Have any dimensions changed?
        if (_previousTotalWidth != totalWidth
            || _previousHeight != height
            || _previousPosition.x != position.x
            || _previousPosition.y != position.y)
        {

            _previousTotalWidth = totalWidth;
            _previousHeight = height;
            _previousPosition.x = position.x;
            _previousPosition.y = position.y;
            _previousTotalWidth = totalWidth;
            Recreate();
        }
    }

    private void CreateElements()
    {
        //print("HUD Custom Bar - CreateElements Called!");
        // As placement of GUI elements is based off a 1920 x 1080 pixel screen we need to scale
        // width, height and the x and y anchor points to determine the correct position on a smaller
        // or larger screen. We do this by dividing the current width or height of the screen by 
        // 1920 or 1080 respectively.
        var screenScale = new Vector2(Screen.width / 1920f, Screen.height / 1080f);

        fillImages = new List<GameObject>();

        float elementHeight = Convert.ToSingle(height);

        var totalWidthFloat = totalWidth * screenScale.x;

        // Determine the width of every element.
        float elementWidth = totalWidthFloat / totalElements;

        // Shift the start position so elements appear centre aligned.
        float startX = -totalWidthFloat / 2;

        // instantiate an offset to be incremented everytime an element is created.
        var offsetX = 0f;

        _position.x = position.x * screenScale.x;
        _position.y = position.y * screenScale.y;

        // Layout all elements.
        for (int i = 0; i < totalElements; i++)
        {
            // Image objects are centre-aligned so move the x offset by half the element width.
            offsetX += elementWidth * 0.5f;

            // Create the image and set it's parent to be this object's transform.
            var img = GameObject.Instantiate(fill);
            img.transform.SetParent(this.gameObject.transform, false);

            fillImages.Add(img);

            var rt = img.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector3(startX + offsetX, _position.y);
            rt.sizeDelta = new Vector2(elementWidth, elementHeight);
            img.SetActive(true);

            offsetX += elementWidth * 0.5f;
        }
    }

    /// <summary>
    /// Used by extending classes to instantiate variables (called in Start event on object).
    /// Mostly useful for instantiating the total, which is used to create fill images.
    /// </summary>
    protected abstract void Instatiate();
}
