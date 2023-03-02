using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetRes : MonoBehaviour
{
    private Dropdown dropdown;
    private Resolution[] resNames;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        resNames = Screen.resolutions;
        List<string> dropOptions = new List<string>();
        int i = 0;
        int pos = 0;
        Resolution currentRes = Screen.currentResolution;
        foreach(Resolution r in resNames)
        {
            string val = r.ToString();
            dropOptions.Add(val);
            if(r.width == currentRes.width && 
                r.height == currentRes.height &&
                r.refreshRate == currentRes.refreshRate)
            {
                pos = i;
            }
            i++;
        }
        dropdown.AddOptions(dropOptions);
        dropdown.value = pos;
    }

    public void SetResolution()
    {
        Resolution r = resNames[dropdown.value];
        Screen.SetResolution(r.width, r.height, Screen.fullScreenMode, r.refreshRate);
    }
}
