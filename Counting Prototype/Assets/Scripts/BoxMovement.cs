using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    float speed = 10.0f;
    Rigidbody boxesRB;
    float verticalInput;
    float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        boxesRB = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if ((verticalInput < 0 && transform.position.z > SphereManager.minZ - SphereManager.margin)
            || (verticalInput > 0 && transform.position.z < SphereManager.maxZ + SphereManager.margin))
        {
            boxesRB.AddForce(Vector3.forward * verticalInput * speed, ForceMode.Impulse);
        }

        if ((horizontalInput < 0 && transform.position.x > SphereManager.minX - SphereManager.margin)
            || (horizontalInput > 0 && transform.position.x < SphereManager.maxX + SphereManager.margin))
        {
            boxesRB.AddForce(Vector3.right * horizontalInput * speed, ForceMode.Impulse);
        }
    }
}
