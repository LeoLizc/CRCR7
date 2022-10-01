using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Customizable")]
    [SerializeField] private float acceleration;
    [SerializeField] private float deacceleration;
    [SerializeField] private float timeDeacceleration;
    [SerializeField] private float initialVelocity;
    [SerializeField] private float maxVelocity;

    [Header("State")]
    public float velocity;

    public GameState state;

    private void Awake()
    {
        Instance = this;
        state = GameState.start;
    }
    // Start is called before the first frame update
    void Start()
    {
        velocity = initialVelocity;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case GameState.start:
                break;
            case GameState.running:
                velocity = Mathf.Min(velocity + Time.fixedDeltaTime * acceleration, maxVelocity);
                break;
            case GameState.crashed:

                velocity = Mathf.Max(0, velocity - Time.fixedDeltaTime * deacceleration);
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        state = newState;
        switch (state)
        {
            case GameState.start:
                break;
            case GameState.running:
                break;
            case GameState.crashed:
                deacceleration = velocity / timeDeacceleration;
                break;
            default:
                break;
        }
    }

    public enum GameState
    {
        start,
        running,
        crashed
    }
}
