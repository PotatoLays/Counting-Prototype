using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text counterText;
    private static int count = 0;
    private static int spheresCount = 0;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider collider)
    {
        SphereClass sphere = collider.GetComponent<SphereClass>();
        // when it is not a sphere
        if (sphere == null)
        {
            return;
        }

        if (!sphere.isCounted)
        {
            Material sphereMaterial = collider.GetComponent<MeshRenderer>().material;
            CheckSurface(gameObject, sphereMaterial);
            // mark the sphere that it got counted
            sphere.isCounted = true;
            spheresCount++;
            // update score
            counterText.text = "Spheres: " + spheresCount + "\nScore : " + count;
        }
    }

    void CheckSurface(GameObject surface, Material sphereMaterial)
    {
        // if it is hitting the floor: penalty
        if (surface.CompareTag("Floor"))
        {
            count += -2;
        }
        else
        {
            // colour box matching with sphere
            if (sphereMaterial.name == surface.GetComponent<MeshRenderer>().material.name) {
                count += 3;
            }
            // in another box
            else {
                count += 1;
            }
        }
    }
}
