using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManger : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    // Start is called before the first frame update
    private void Start()
    {
        PauseMenu.isOn = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            TogglePauseMenu();
            Debug.Log("askpause");
        }
    }
    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        PauseMenu.isOn = pauseMenu.activeSelf;
    }
}
