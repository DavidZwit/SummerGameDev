using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fpsdisplay : MonoBehaviour
{

    float FPS = 0.0f;
    Text t;

    void Awake()
    {
        t = this.transform.GetComponent<Text>();
    }

    void Update()
    {
        FPS = Mathf.Round( (1.0f / Time.deltaTime) );
        t.text = FPS.ToString();
    }

}