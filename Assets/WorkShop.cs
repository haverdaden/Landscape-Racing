using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkShop : MonoBehaviour
{
    public SaveSystem SaveSystem;

    public void Continue()
    {
        SceneManager.LoadScene(PlayerValues.Player.level);
    }
}
