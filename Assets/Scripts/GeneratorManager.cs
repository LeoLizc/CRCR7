using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> generators;
    [SerializeField] private GameObject platform;
    [SerializeField] float velocity;
    public string pattern;
    private int step;
    private float nextActionTime = 0.0f;
    [SerializeField] private float period;

    // Start is called before the first frame update
    void Start()
    {
        //step = 0;
        //InvokeRepeating("generatePlatform", 2, 2);
    }

    private void Update()
    {
        float time = Time.time;
        if ( time > nextActionTime)
        {
            nextActionTime = time + period;
            //Debug.Log("generar");
            generatePlatform();
        }
    }

    private void generatePlatform()
    {
        string[] steps = pattern.Split(';');
        string next = steps[step%steps.Length];
        foreach(string gen in next.Split(','))
        {
            generators[int.Parse(gen)].GetComponent<PlatformGenerator>().generatePlatform(platform, velocity);
        }
        step++;
    }
}
