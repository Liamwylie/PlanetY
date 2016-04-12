using UnityEngine;

public class LevelSelectScript : MonoBehaviour
{
  public int Mob;
  public int Com;
  public int Ult;
    string sMob = "0";
    string sCom = "0";
    string sUlt = "0";
    void Start()
    {
        Mob = 0;
        Com = 0;
        Ult = 0;
    }


    public int returnMob()
    {
        return (Mob);
    }
    public int returnCom()
    {
        return (Com);
    }
    public int returnUlt()
    {
        return (Ult);
    }

    void OnGUI()
    {
        if (Mob == 0)
        {
            sMob = "Boost";
        }
        if (Mob == 1)
        {
            sMob = "Triple Jump";
        }
        if (Mob == 2)
        {
            sMob = "Teleport";
        }
        if (Mob == 3)
        {
            sMob = "Grapple hook";
        }
        if (Com == 0)
        {
            sCom = "Blaster";
        }
        if (Com == 1)
        {
            sCom = "Sniper";
        }
        if (Com == 2)
        {
            sCom = "Grenade launcher";
        }
        if (Com == 3)
        {
            sCom = "Mines";
        }
        if (Com == 4)
        {
            sCom = "Laser";
        }
        if (Ult == 0)
        {
            sUlt = "Invincibilty";
        }
        if (Ult == 1)
        {
            sUlt = "Time Shift";
        }
        if (Ult == 2)
        {
            sUlt = "Flight";
        }

        const float Width = 100;
        const float Height = 50;
        const float SWidth = 25;
        const float SHeight = 25;

        Rect Back = new Rect(100 - (Width / 2), 500 - (Height / 2), Width, Height);
        Rect Level1= new Rect(300 - (Width / 2), 500 - (Height / 2), Width, Height);
        Rect Level2 = new Rect(450 - (Width / 2), 500 - (Height / 2), Width, Height);
        Rect Level3 = new Rect(600 - (Width / 2), 500 - (Height / 2), Width, Height);
        Rect Level4 = new Rect(750 - (Width / 2), 500 - (Height / 2), Width, Height);
        Rect Level5 = new Rect(900 - (Width / 2), 500 - (Height / 2), Width, Height);

        Rect MobilityL = new Rect(850 - (SWidth / 2), 200 - (SHeight / 2), SWidth, SHeight);
        Rect MobilityR = new Rect(900 - (SWidth / 2), 200 - (SHeight / 2), SWidth, SHeight);

        Rect CombatL = new Rect(850 - (SWidth / 2), 250 - (SHeight / 2), SWidth, SHeight);
        Rect CombatR = new Rect(900 - (SWidth / 2), 250 - (SHeight / 2), SWidth, SHeight);

        Rect UltimateL = new Rect(850 - (SWidth / 2), 300 - (SHeight / 2), SWidth, SHeight);
        Rect UltimateR = new Rect(900 - (SWidth / 2), 300 - (SHeight / 2), SWidth, SHeight);

        GUI.Label(new Rect(750, 190, 100, 100), sMob);
        GUI.Label(new Rect(750, 240, 100, 100), sCom);
        GUI.Label(new Rect(750, 290, 100, 100), sUlt);


        if (GUI.Button(Level1, "Level 1"))
        {
           Application.LoadLevel("Level 1");
        }
        if (GUI.Button(Level2, "Level 2"))
        {
            Application.LoadLevel("Menu");
        }
        if (GUI.Button(Level3, "Level 3"))
        {
            Application.LoadLevel("Menu");
        }
        if (GUI.Button(Level4, "Level 4"))
        {
            Application.LoadLevel("Menu");
        }
        if (GUI.Button(Level5, "Level 5"))
        {
            Application.LoadLevel("Menu");
        }

        if (GUI.Button(MobilityL, "<"))
        {
            if (Mob > 0)
            {
                Mob--;
            }
        }
        if (GUI.Button(MobilityR, ">"))
        {
            if (Mob < 3)
            {
                Mob++;
            }
        }



        if (GUI.Button(CombatL, "<"))
        {
            if (Com > 0)
            {
                Com--;
            }
        }
        if (GUI.Button(CombatR, ">"))
        {
            if (Com < 4)
            {
                Com++;
            }
        
        }



        if (GUI.Button(UltimateL, "<"))
        {
            if (Ult > 0)
            {
                Ult--;
            }
          
        }
        if (GUI.Button(UltimateR, ">"))
        {
            if (Ult < 2)
            {
                Ult++;
            }
          
        }
    }
}