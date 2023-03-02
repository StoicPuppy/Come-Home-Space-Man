using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGFX : MonoBehaviour
{
    private Dropdown dropdown;
    private string[] gfxNames;

    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        gfxNames = QualitySettings.names;
        List<string> dropOptions = new List<string>();
        foreach (string s in gfxNames)
        {
            dropOptions.Add(s);
        }
        dropdown.AddOptions(dropOptions);
        dropdown.value = QualitySettings.GetQualityLevel();

    }

    public void SetGraphics()
    {
        QualitySettings.SetQualityLevel(dropdown.value, true);
    }
}
