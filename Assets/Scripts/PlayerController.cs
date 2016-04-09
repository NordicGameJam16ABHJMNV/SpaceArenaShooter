using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject missilePrefab;
    public float friction = 1f;
    public float acceleration = 10f;
    public float rotationSpeed = 100f;
    public float reloadDelay = 1.0f;

    private Rigidbody2D body;

    private bool canShoot = true;
   
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        //Movement is called by InputController script
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
        Move(new Vector2(xInput, yInput));
#endif
    }

    internal void Move(Vector2 input)
    {
        Vector2 direction = input.y * transform.up;

        body.rotation += rotationSpeed * -input.x * Time.deltaTime;

        body.velocity -= body.velocity * friction * Time.deltaTime;

        body.velocity += direction * acceleration * Time.deltaTime;
    }

    internal void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            StartCoroutine(Reload());
            Vector3 missileSpawnPosition = transform.position + transform.up * 2;
            GameObject missile = Instantiate(missilePrefab, missileSpawnPosition, transform.rotation) as GameObject;
            Destroy(missile, 2f);
            missile.GetComponent<Rigidbody2D>().velocity = transform.up * 20;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadDelay);
        canShoot = true;
    }
}
