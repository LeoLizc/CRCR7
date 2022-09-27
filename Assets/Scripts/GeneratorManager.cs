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
    private GameObject[] Cars;

    // Start is called before the first frame update
    void Awake()
    {
        //step = 0;
        //InvokeRepeating("generatePlatform", 2, 2);
        LoadObjects();
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


    void LoadObjects(){
        object[] loadedCars = Resources.LoadAll ("cars_obstacles", typeof(GameObject)) ;
        Cars = new GameObject[loadedCars.Length];
        for (int x = 0; x < loadedCars.Length; x++)
        {
            Cars [x] = (GameObject)loadedCars [x];
        }
    }


    private void generatePlatform()
    {
        string[] steps = pattern.Split(';');
        string next = steps[step%steps.Length];
        foreach(string gen in next.Split(','))
        {
            int numberOfCar = Random.Range(0, Cars.Length);
            generators[int.Parse(gen)].GetComponent<PlatformGenerator>().generatePlatform(Cars[numberOfCar], velocity);
        }
        step++;
    }
}
