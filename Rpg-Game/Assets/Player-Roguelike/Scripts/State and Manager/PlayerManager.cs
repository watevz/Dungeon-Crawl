using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour {

    #region singleton
    public static PlayerManager instance;

    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("more than one playerManager instance");

        instance = this;
    }

    #endregion
    public GameObject player;
    public PlayerState state;

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
