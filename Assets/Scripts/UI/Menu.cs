using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    public GameObject menu;
    public GameObject stats;
    public GameObject exitPanel;

	// Use this for initialization
	void Start () {
        menu.SetActive(false);
        exitPanel.SetActive(false);

    }
	
    public void OnButtonMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    public void OnButtonBack()
    {
        menu.SetActive(false);
    }

    public void OnButtonExit()
    {
        OnButtonMenu();
        exitPanel.SetActive(true);               
    }

    public void OnButtonYes()
    {
        Application.Quit();
    }

    public void OnButtonNo()
    {       
        exitPanel.SetActive(false);
    }

}
