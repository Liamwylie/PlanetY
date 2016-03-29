using UnityEngine;

public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        const float Width = 100;
        const float Height = 50;


        Rect Start = new Rect(Screen.width / 2 - (Width / 2),(2 * Screen.height / 3) - (Height / 2),Width,Height);
        Rect Options = new Rect(Screen.width / 2 - (Width / 2), (2 * Screen.height / 2.5f) - (Height / 2), Width, Height);

        if (GUI.Button(Start, "Start"))
        {
            Application.LoadLevel("Level select");
        }

        if (GUI.Button(Options, "Options"))
        {
            Application.LoadLevel("Options");
        }
    }
}