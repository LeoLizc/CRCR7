using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorManager : MonoBehaviour
{
    [Header("Generators")]
    [SerializeField] private List<GameObject> generators;
    [SerializeField] private GameObject streetGenerator;

    [Header("Models")]
    [SerializeField] private GameObject street;
    [SerializeField] private string obstaclePath;

    [Header("Personalization")]
    public string pattern;
    // If true, the pattern will repeate indefinitely, Otherwise it will generate a instances randomly
    public bool repet_Pattern = false;

    [SerializeField] float velocity2;
    public float separation;
    [SerializeField] private float power_period; //time in seconds Between each PowerUp

    //#################################### - RELATED TO GAME MANAGER LOGIC - ######################################
    public bool use_Game_Manager = false;
    public bool notUseGameManager { get => !use_Game_Manager; }
    //---------------------------------------------------------------------------------------------------------
    [ConditionalHide("notUseGameManager")] 
    [Header("Custom Config")]
    [SerializeField] float velocity;

    //---------------------------------------------------------------------------------------------------------
    [Header("Using Game Manager")]
    [ConditionalHide("use_Game_Manager")] [SerializeField] private float difference;
    [ConditionalHide("use_Game_Manager")] [SerializeField] float streetVelocity;

    //#################################### - Private components - ######################################
    private int step;
    private float nextActionTime = 0.0f, nextActionTime2 = 0.0f;
    private GameObject[] cars, poderes;

    // Start is called before the first frame update
    void Awake()
    {
        //step = 0;
        //InvokeRepeating("generatePlatform", 2, 2);
        loadObjectsFolder("Poderes_car", ref poderes);
        loadObjectsFolder(obstaclePath, ref cars);
    }

    private void Update()
    {
        float time = Time.time;
        if ( time > nextActionTime)
        {
            nextActionTime = time + separation/(use_Game_Manager ? GameManager.Instance.velocity : 1);
            //Debug.Log("generar");
            if (!use_Game_Manager || GameManager.Instance.velocity > difference && GameManager.Instance.state == GameManager.GameState.running)
            {
                generatePlatform();
            }
            if(use_Game_Manager && GameManager.Instance.velocity > 0)
            {
                generateStreet();
            }
                
        }
        if (time > nextActionTime2 && use_Game_Manager && GameManager.Instance.state == GameManager.GameState.running)
        {
            nextActionTime2 = time + power_period;
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
            generators[int.Parse(gen)%generators.Count].GetComponent<PlatformGenerator>()
                .generatePlatform(cars[numberOfCar],
                (use_Game_Manager? GameManager.Instance.velocity - difference : velocity));
        }
        step++;
        if (!repet_Pattern && step> steps.Length)
        {
            pattern= RandomGenP();
            step = 0;
        }
    }

    private void generateStreet()
    {
        if (streetGenerator)
        {
            streetGenerator.GetComponent<PlatformGenerator>().generatePlatform(street, GameManager.Instance.velocity);
        }
    }
    public string RandomGenP()
    {
        string patron = "";
        int i, k, R = 0;
        int[] no;
        bool s = true;
        no = new int[5];
        i = Random.Range(10, 20);
        for (int j = 0; j < i; j++)
        {
            k = Random.Range(1, 4);
            for (int l = 0; l < k; l++)
            {
                while (s)
                {
                    R = Random.Range(0, 6);
                    s = false;
                    for (int ni = 0; ni < l; ni++)
                    {
                        if (no[ni] == R)
                            s = true;
                    }
                }
                patron = patron + R + ",";
                no[l] = R;
                s = true;
            }
            patron = patron.Remove(patron.Length - 1);
            patron = patron + ";";
        }
        patron = patron.Remove(patron.Length - 1);
        return patron;
    }
}
