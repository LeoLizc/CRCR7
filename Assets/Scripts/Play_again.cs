using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play_again : MonoBehaviour
{

    public void play_again()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.running);
        SceneManager.LoadScene("Game");
    }    
}
