using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{

    PauseMenu pauseUI;
    [SerializeField] GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseUI = pauseMenu.GetComponent<PauseMenu>();
        Cursor.visible = false;
    }

    private void Update()
    {
        if (pauseUI == true)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
