using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{
    //Missiles
    public GameObject missilePrefab;
    public float friction = 1f;
    public float acceleration = 10f;
    public float rotationSpeed = 100f;
    public float reloadDelay = 1.0f;
    public float bulletspeed = 20.0f;

    //AirTank
    private Rigidbody2D body;
    public GameObject PlayerGui;
    public int Holes = 0;
    public float Air = 1000;
    public float AirConsuming = 0.17f;

    private bool canShoot = true;
   
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Init(GameObject PlayerGui, float Air)
    {
        this.PlayerGui = PlayerGui;
        this.Air = Air;
    }

    // Update is called once per frame
    void Update()
    {
        String name = gameObject.name;
        int playerNumber = int.Parse(name.Substring(name.Length - 1, 1));
        Light playerLight = GetComponentInChildren<Light>();

        switch (playerNumber)
        {
            case 0:
                playerLight.color = Color.green;
                break;
            case 1:
                playerLight.color = Color.blue;
                break;
            case 2:
                playerLight.color = Color.red;
                break;
            case 3:
                playerLight.color = Color.yellow;
                break;
        }

        if (Air < 0)
        {
            Destroy(gameObject);
        }
        //Consumes Air
        Air = Air - ((AirConsuming + Holes * AirConsuming) * (10 * Time.deltaTime));
        GameObject.Find(PlayerGui.name + "/Canvas/AirHolder/Air").GetComponent<RectTransform>().sizeDelta = new Vector2(10,Air/10);
        //Updates Container
    }

    //For Closing holes
    public void CloseHole(int Number)
    {
        if (Holes >= Number)
            Holes -= Number;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!(col.collider.tag == "Wall"))
        {
            Holes++;
        }
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
            Vector3 missileSpawnPosition = transform.position + transform.up * 3;
            GameObject missile = Instantiate(missilePrefab, missileSpawnPosition, transform.rotation) as GameObject;
            Destroy(missile, 2f);
            missile.GetComponent<Rigidbody2D>().velocity = transform.up * bulletspeed;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadDelay);
        canShoot = true;
    }
}
