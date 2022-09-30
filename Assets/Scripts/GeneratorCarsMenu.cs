using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorCarsMenu : MonoBehaviour
{
    [SerializeField] private List<GameObject> generators;

    [SerializeField] float velocity, velocity2;
    public string pattern;
    private int step;
    private float nextActionTime = 0.0f, nextActionTime2 = 0.0f;
    [SerializeField] private float period, perio2;
    private GameObject[] cars;

    [Header("Diference")]
    [SerializeField] private float difference;


    void Awake()
    {
        loadObjectsFolder(" ", ref cars);
    }

    private void Update()
    {
        float time = Time.time;
        if ( time > nextActionTime)
        {
            nextActionTime = time + period;
            //Debug.Log("generar");
            if (GameManager.Instance.velocity > difference && GameManager.Instance.state == GameManager.GameState.start)
            {
                generatePlatform();
            }
        }
        if (time > nextActionTime2 && GameManager.Instance.state == GameManager.GameState.start)
        {
            nextActionTime2 = time + perio2;
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

        private void generatePlatform()
    {
        string[] steps = pattern.Split(';');
        string next = steps[step%steps.Length];
        foreach(string gen in next.Split(','))
        {
            int numberOfCar = Random.Range(0, cars.Length);
            Debug.Log(cars[numberOfCar]);
            generators[(int.Parse(gen)%generators.Count)].GetComponent<PlatformGenerator>().generatePlatform(cars[numberOfCar], GameManager.Instance.velocity - difference);
        }
        step++;
    }
}
