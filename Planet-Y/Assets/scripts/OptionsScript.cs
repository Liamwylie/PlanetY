using UnityEngine;

public class OptionsScript : MonoBehaviour
{
    void OnGUI()
    {
        const float Width = 100;
        const float Height = 50;


        Rect Back = new Rect(100 - (Width / 2), 500 - (Height / 2), Width, Height);

        if (GUI.Button(Back, "Back"))
        {
            Application.LoadLevel("Menu");
        }

    }
}