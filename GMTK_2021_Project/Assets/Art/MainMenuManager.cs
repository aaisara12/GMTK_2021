using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{

    public void quit(){
        Application.Quit();
    }
    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void onVolumeChange(float value){
        AudioListener.volume = value;
    }
}
