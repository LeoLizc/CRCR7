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
    private GameObject[] cars, poderes;

    [Header("Diference")]
    [SerializeField] private float difference;

    // Start is called before the first frame update
    void Awake()
    {
        //step = 0;
        //InvokeRepeating("generatePlatform", 2, 2);
        loadObjectsFolder("Poderes_car", ref poderes);
        loadObjectsFolder("cars_obstacles", ref cars);
    }

    private void Update()
    {
        float time = Time.time;
        if ( time > nextActionTime)
        {
            nextActionTime = time + period/(GameManager.Instance.velocity/9.5f);
            //Debug.Log("generar");
            if (GameManager.Instance.velocity > difference && GameManager.Instance.state == GameManager.GameState.running)
            {
                generatePlatform();
            }
            if(GameManager.Instance.velocity > 0)
            {
                generateStreet();
            }
                
        }
        if (time > nextActionTime2 && GameManager.Instance.state == GameManager.GameState.running)
        {
            nextActionTime2 = time + perio2;
            //Debug.Log("generar");
            generatePower();
        }
    }

    void loadObjectsFolder(string folder, ref GameObject[] dest)
    {
        object[] loaded = Resources.LoadAll(folder, typeof(GameObject));
        dest = new GameObject[loaded.Length];
        for (int x = 0; x < loaded.Length; x++)
        {
            dest[x] = (GameObject)loaded[x];
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
            int numberOfCar = Random.Range(0, cars.Length);
            generators[int.Parse(gen)].GetComponent<PlatformGenerator>().generatePlatform(cars[numberOfCar], GameManager.Instance.velocity - difference);
        }
        step++;
    }

    private void generateStreet()
    {
        if (streetGenerator)
        {
            streetGenerator.GetComponent<PlatformGenerator>().generatePlatform(street, GameManager.Instance.velocity);
        }
    }
}
