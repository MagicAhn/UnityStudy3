using UnityEngine;
using System.Collections;

public class CubeMove : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate(new Vector3(0,0,0.01f));
    }
}
