using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> generators;
    [SerializeField] private GameObject streetGenerator;

    [SerializeField] private GameObject street;
    [SerializeField] float velocity, velocity2;
    [SerializeField] float streetVelocity;
    public string pattern;
    private int step;
    private float nextActionTime = 0.0f, nextActionTime2 = 0.0f;
    [SerializeField] private float period, perio2;
    private GameObject[] Cars, poderes;

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
            generateStreet();
            LoadSuperObjects();
            generatePower();
        }
        if (time > nextActionTime2)
        {
            nextActionTime2 = time + perio2;
            //Debug.Log("generar");
            LoadSuperObjects();
            generatePower();
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

    void LoadSuperObjects()
    {
        object[] loadedCars = Resources.LoadAll("Poderes_car", typeof(GameObject));
        poderes = new GameObject[loadedCars.Length];
        for (int x = 0; x < loadedCars.Length; x++)
        {
            poderes[x] = (GameObject)loadedCars[x];
        }
    }


    private void generatePower()
    {

        int Num =Random.Range(0, poderes.Length);
        generators[(int)(Random.Range(0, 6))].GetComponent<PlatformGenerator>().generatePlatform(poderes[Num], velocity2);

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

    private void generateStreet()
    {
        if (streetGenerator)
        {
            streetGenerator.GetComponent<PlatformGenerator>().generatePlatform(street, streetVelocity);
        }
    }
}
