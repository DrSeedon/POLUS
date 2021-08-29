using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VersionShow : MonoBehaviour
{
    Text versionText;
    void Start()
    {
        versionText = GetComponent<Text>();
        versionText.text = "Version " + Application.version;
    }

}
