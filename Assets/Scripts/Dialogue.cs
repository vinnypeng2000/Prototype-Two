using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue   
{
    public string name; 
    public Sprite avatar;
    public AudioSource source;

    [TextArea(4, 15)]
    public string[] sentences;

}
