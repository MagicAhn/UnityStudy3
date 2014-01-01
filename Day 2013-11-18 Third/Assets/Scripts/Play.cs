using System;
using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour
{
    public Texture2D BackTexture2D;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, BackTexture2D.width, BackTexture2D.height), BackTexture2D);
    }
}
