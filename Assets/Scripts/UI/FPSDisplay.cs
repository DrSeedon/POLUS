using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour
{

    public int avgFrameRate;
    public Text displayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float current;
        current = (int)(1f / Time.unscaledDeltaTime); 
        avgFrameRate = (int)current;
        displayText.text = avgFrameRate.ToString() + " FPS";
    }
}
