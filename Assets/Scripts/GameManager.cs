using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Customizable")]
    [SerializeField] private float acceleration;
    [SerializeField] private float deacceleration;
    [SerializeField] private float initialVelocity;
    [SerializeField] private float maxVelocity;

    [Header("State")]
    public float velocity;

    public GameState state;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        velocity = initialVelocity;
        state = GameState.running;
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case GameState.running:
                velocity += Mathf.Min(Time.fixedDeltaTime * acceleration, maxVelocity);
                break;
            case GameState.crashed:
                velocity = Mathf.Max(0, velocity - Time.fixedDeltaTime * deacceleration);
                break;
        }
    }

    public void ChangeState(GameState newState)
    {
        state = newState;
    }

    public enum GameState
    {
        running,
        crashed
    }
}
