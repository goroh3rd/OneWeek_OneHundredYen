using UnityEngine;
using System.Collections.Generic;

public class Thrower : MonoBehaviour
{
    [SerializeField] ProjectileTrajectory projectileTrajectory;
    [SerializeField] Transform launchPosition;
    [SerializeField] List<GameObject> products = new();
    Vector3 mousePos = new();
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        float launchAngle = Vector3.Angle(Vector3.right, mousePos - launchPosition.position);
        float launchSpeed = Vector3.Distance(launchPosition.position, mousePos) * 1.5f;
        projectileTrajectory.DrawTrajectory(launchPosition, launchAngle, launchSpeed);
        if (Input.GetMouseButtonDown(0))
        {
            ThrowProduct(launchAngle, launchSpeed);
        }
    }
    GameObject ThrowProduct(float angle, float speed)
    {
        GameObject product = Instantiate(products[Random.Range(0, products.Count)], launchPosition.position, Quaternion.identity);
        product.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(speed * Mathf.Cos(angle * Mathf.Deg2Rad), speed * Mathf.Sin(angle * Mathf.Deg2Rad));
        return product;
    }
}
