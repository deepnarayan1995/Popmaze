using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public StarLife life;
    public MenuManager GM;


    public AllSoundFx sound;
    public GameObject MainmenuCameraPosition;
    public GameObject CatagoryCameraposition;
    public GameObject MainMenuCanvas;
    public GameObject CatagoryCanvas;

    void Start()
    {
        Camera.main.transform.position = MainmenuCameraPosition.transform.position;
    }


    public void PlayButtonClick()
    {
        GM.SaveGameMenu();
        Camera.main.transform.position = CatagoryCameraposition.transform.position;
        MainMenuCanvas.SetActive(false);
        CatagoryCanvas.SetActive(true);
    }

    public void LoadnextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
