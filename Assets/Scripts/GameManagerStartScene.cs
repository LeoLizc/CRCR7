using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerStartScene : MonoBehaviour
{
    public static GameManagerStartScene Instance;


    void Awake()
    {
        Instance = this;
    }


    public void PlayButton()
    {
        GameManager.Instance.ChangeState(GameManager.GameState.running);
        SceneManager.LoadScene("Game");
    }
}
