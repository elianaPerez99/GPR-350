using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeTimeScale : MonoBehaviour
{
    //variables
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && Time.timeScale > .1f)
        {
            Time.timeScale -= .1f;
            text.text = "Time Scale: " + System.Math.Round(Time.timeScale, 1).ToString() + "x";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 0;
            text.text = "Time Scale: " + System.Math.Round(Time.timeScale, 1).ToString() + "x";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale += .1f;
            text.text = "Time Scale: " + System.Math.Round(Time.timeScale, 1).ToString() + "x";
        }
    }
}
