using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class Arayuz : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI textBullet;
    public TextMeshProUGUI textHp;
    GameObject oyuncu;

    void Start()
    {
        //panel = GetComponent<GameObject>();
        oyuncu = GameObject.Find("Whiteclown N Hallin");
    }

    // Update is called once per frame
    void Update()
    {
        textBullet.text = oyuncu.GetComponent<ShootController>().GetSarzor().ToString() + "/" + oyuncu.GetComponent<ShootController>().GetCephane().ToString();
        textHp.text = "HP:" + oyuncu.GetComponent<CharacterMovement>().GetHP().ToString();
        Pause();
        Exit();

    }
    public void Pause()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            panel.SetActive(true);
            Time.timeScale = 0;
        }
        /* else if (Input.GetKey(KeyCode.Escape))
         {
             Resume();
         }*/


    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;
        panel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
