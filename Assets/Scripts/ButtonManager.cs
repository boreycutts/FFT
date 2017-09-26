using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // Main Menu //
    public void Button_Play()
    {
        MoveUI.main_menu = false;
        MoveUI.select_video = true;
        MoveUI.store = false;
        MoveUI.settings = false;
        MoveUI.about = false;
    }

    public void Button_Store()
    {
        MoveUI.main_menu = false;
        MoveUI.select_video = false;
        MoveUI.store = true;
        MoveUI.settings = false;
        MoveUI.about = false;
    }

    public void Button_Settings()
    {
        MoveUI.main_menu = false;
        MoveUI.select_video = false;
        MoveUI.store = false;
        MoveUI.settings = true;
        MoveUI.about = false;
    }

    public void Button_About()
    {
        MoveUI.main_menu = false;
        MoveUI.select_video = false;
        MoveUI.store = false;
        MoveUI.settings = false;
        MoveUI.about = true;
    }

    public void Button_Back()
    {
        MoveUI.main_menu = true;
        MoveUI.select_video = false;
        MoveUI.store = false;
        MoveUI.settings = false;
        MoveUI.about = false;
    }

    public void Button_Start()
    {
        SceneManager.LoadScene("Mobile_MainGame");
    }

    // Store Buttons
    public void Button_Default()
    {
        MoveStoreModels.player_default = true;
        MoveStoreModels.player_8bit = false;
        MoveStoreModels.player_midway = false;
    }

    public void Button_8Bit()
    {
        MoveStoreModels.player_default = false;
        MoveStoreModels.player_8bit = true;
        MoveStoreModels.player_midway = false;
    }

    public void Button_Midway()
    {
        MoveStoreModels.player_default = false;
        MoveStoreModels.player_8bit = false;
        MoveStoreModels.player_midway = true;
    }

    public void Button_Red1()
    {
        PlayerColor.color1 = 0;
    }
    public void Button_Orange1()
    {
        PlayerColor.color1 = 1;
    }
    public void Button_Yellow1()
    {
        PlayerColor.color1 = 2;
    }
    public void Button_Green1()
    {
        PlayerColor.color1 = 3;
    }
    public void Button_Blue1()
    {
        PlayerColor.color1 = 4;
    }
    public void Button_Indigo1()
    {
        PlayerColor.color1 = 5;
    }
    public void Button_Violet1()
    {
        PlayerColor.color1 = 6;
    }
    public void Button_White1()
    {
        PlayerColor.color1 = 7;
    }
    public void Button_LightGrey1()
    {
        PlayerColor.color1 = 8;
    }
    public void Button_DarkGrey1()
    {
        PlayerColor.color1 = 9;
    }
    public void Button_Black1()
    {
        PlayerColor.color1 = 10;
    }

    public void Button_Red2()
    {
        PlayerColor.color2 = 0;
    }
    public void Button_Orange2()
    {
        PlayerColor.color2 = 1;
    }
    public void Button_Yellow2()
    {
        PlayerColor.color2 = 2;
    }
    public void Button_Green2()
    {
        PlayerColor.color2 = 3;
    }
    public void Button_Blue2()
    {
        PlayerColor.color2 = 4;
    }
    public void Button_Indigo2()
    {
        PlayerColor.color2 = 5;
    }
    public void Button_Violet2()
    {
        PlayerColor.color2 = 6;
    }
    public void Button_White2()
    {
        PlayerColor.color2 = 7;
    }
    public void Button_LightGrey2()
    {
        PlayerColor.color2 = 8;
    }
    public void Button_DarkGrey2()
    {
        PlayerColor.color2 = 9;
    }
    public void Button_Black2()
    {
        PlayerColor.color2 = 10;
    }

    public void Button_Ship()
    {
        MoveStore.ship = true;
        MoveStore.color = false;
    }

    public void Button_Color()
    {
        MoveStore.ship = false;
        MoveStore.color = true;
    }
    // In Game Menus
    public void Button_KeepGoing()
    {
        GameOver.keep_going = true;
    }

    public void Button_LetsGetIt()
    {
        SelectNextVideo.video_chosen = true;
        PlayerScore.score = 2000;
    }

    public void Button_Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void Button_MainMenu()
    {
        SelectNextVideo.play_video = false;
        GameOver.keep_going = false;
        SelectNextVideo.video_chosen = false;
        SimplePlayback.video_played = false;
        SceneManager.LoadScene("MainMenu");
    }
}