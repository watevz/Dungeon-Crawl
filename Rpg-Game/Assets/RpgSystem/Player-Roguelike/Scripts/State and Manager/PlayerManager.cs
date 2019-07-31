using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Interaction;


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
    public PlayerState playerState;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerState = new PlayerState();
    }

    public void SetFocus(Interactable targetInteractable)
    {
        if( playerState.focus != targetInteractable)
        {
            if( playerState.focus != null)
            {
                playerState.focus.DeFocused();
            }
            
            playerState.focus = targetInteractable;
            
        }

        targetInteractable.OnFocused(transform);
    }

    public void RemoveFocus()
    {
        if (playerState.focus != null)
        {
            playerState.focus.DeFocused();
        }

        playerState.focus = null;
    }
    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
