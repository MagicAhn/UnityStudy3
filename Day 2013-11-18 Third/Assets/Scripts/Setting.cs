using System;
using UnityEngine;
using System.Collections;

public class Setting : MonoBehaviour
{
    private Single _backVolumn;
    private Single _foreVolumn;
    private AudioSource[] _audioSources;

    // Use this for initialization
    void Start()
    {
        _audioSources = this.gameObject.GetComponents<AudioSource>();
        _backVolumn = PlayerPrefs.GetFloat("BackgroundVolumn");
        _foreVolumn = PlayerPrefs.GetFloat("ForegroundVolumn");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUILayout.Window(0, new Rect(100, 100, 300, 100), ShowWindow, "Setting");
    }

    protected void ShowWindow(Int32 windowId)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Background Volume");
        Single _backVolumn1 = GUILayout.HorizontalSlider(_backVolumn, 0.0f, 1.0f, GUILayout.Width(100));
        GUILayout.EndHorizontal();

        if (_backVolumn1 != _backVolumn)
        {
            _backVolumn = _backVolumn1;
            _audioSources[0].volume = _backVolumn;
            _audioSources[0].Play();
            PlayerPrefs.SetFloat("BackgroundVolumn", _backVolumn);
        }

        GUILayout.BeginHorizontal();
        GUILayout.Label("Foregrond Volumn");
        Single _foreVolumn1 = GUILayout.HorizontalSlider(_foreVolumn, 0.0f, 1.0f, GUILayout.Width(100));
        GUILayout.EndHorizontal();

        if (_foreVolumn1 != _foreVolumn)
        {
            _foreVolumn = _foreVolumn1;
            _audioSources[1].volume = _foreVolumn;
            _audioSources[1].Play();
            PlayerPrefs.SetFloat("ForegroundVolumn", _foreVolumn);
            Debug.Log(_audioSources[1].clip);
        }

        if (GUILayout.Button("Return", GUILayout.Width(100)))
        {
            Application.LoadLevel(0);
        }
    }
}
