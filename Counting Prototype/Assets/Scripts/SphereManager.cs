using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    [SerializeField] Material[] materialColours = new Material[4];

    public static float margin = 5.0f;

    public static float minX = -15.0f;
    public static float maxX = 15.0f;
    public static float minZ = -5.0f;
    public static float maxZ = 5.0f;
    float startingY = 25.0f;

    const int maxSpheres = 30;
    GameObject[] spheres = new GameObject[maxSpheres];
    int countSpheres;

    private void Awake()
    {
        PrepareSpheres();
        countSpheres = maxSpheres;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateSphere", 2.0f, 2.0f);
    }

    void GenerateSphere()
    {
        countSpheres--;
        spheres[countSpheres].transform.Translate(RandomPosition());
        spheres[countSpheres].GetComponent<MeshRenderer>().material = RandomColour();
        spheres[countSpheres].SetActive(true);

        // Stop the invoke when running out of spheres
        if (countSpheres == 0)
        {
            CancelInvoke("GenerateSphere");
        }
    }
    
    Material RandomColour()
    {
        int randomIndex = Random.Range(0, 4);
        return materialColours[randomIndex];
    }
    Vector3 RandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float z = Random.Range(minZ, maxZ);
        return new Vector3(x, startingY, z);
    }

    // fill in the spheres array
    void PrepareSpheres()
    {
        for (int i = 0; i < maxSpheres; i++)
        {
            spheres[i] = Instantiate(spherePrefab);
            spheres[i].SetActive(false);
        }
    }
}
