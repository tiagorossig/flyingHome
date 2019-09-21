using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonInteract : MonoBehaviour
{

    public Slider volumeSlider;
    public AudioSource volumeAudio;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit(); //only works with a build
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

   
    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
}

