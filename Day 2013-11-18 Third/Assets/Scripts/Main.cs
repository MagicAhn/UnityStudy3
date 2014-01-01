using System;
using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour
{
    private AudioSource[] _audioSources;
    public Texture2D MainPic;

    private enum Audio
    {
        Main,
        Play,
        Quit,
        Setting
    }
    // Use this for initialization
    void Start()
    {
        _audioSources = this.gameObject.GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0,0,MainPic.width,MainPic.height),MainPic);
        GUILayout.Window(0, new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 100, 100), DrawWindow, "Main Menu");
    }

    void DrawWindow(Int32 windowId)
    {
        if (GUILayout.Button("Start", new GUILayoutOption[] {GUILayout.Width(80), GUILayout.Height(20)}))
        {
            StartCoroutine(AsynLoad((Int32) Audio.Play, "levelPlay"));
        }
        if (GUILayout.Button("Setting", new GUILayoutOption[] {GUILayout.Width(80), GUILayout.Height(20)}))
        {
            StartCoroutine(AsynLoad((Int32)Audio.Setting, "levelSetting"));
        }
        if (GUILayout.Button("Quit", new GUILayoutOption[] {GUILayout.Width(80), GUILayout.Height(20)}))
        {
            StartCoroutine(AsynLoad((Int32)Audio.Quit, ""));
        }
    }

    IEnumerator AsynLoad(Int32 audioIndex,String levelName)
    {
        _audioSources[audioIndex].Play();

        yield return new WaitForSeconds(1.3f);

        Debug.Log(levelName);

        if (String.IsNullOrEmpty(levelName))
        {
            Application.Quit();
        }
        else
        {
            Application.LoadLevel(levelName);
        }
    }
}
//链接: http://pan.baidu.com/s/1d3Mrq 密码: hcfw