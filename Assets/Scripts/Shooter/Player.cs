using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : DamageableCharacter
{
    // its access level: public or private
    // its type: int (5, 8, 36, etc.), float (2.5f, 3.7f, etc.)
    // its name: speed, playerSpeed --- Speed, PlayerSpeed
    // optional: give it an initial value
    public bool canMove = true;
    public float speed = 0f;
    public GameObject bullet;
    public int dmg;
    public float bulletspeed = 400;
    public Transform spawnPos;
    public float bulletoffset = 0.5f;
    

    private float horizontalInput;
    private float verticalInput;
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
        }
        Shooting();
    }

    public void Movement()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        characterController.Move(movement);
    }
       

    void Shooting()
    {
        //if I press SPACE
        //Create a bullet
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Create a bullet
            GameObject spawnedbullet = Instantiate(bullet,spawnPos.position + spawnPos.forward*bulletoffset, spawnPos.rotation);
            spawnedbullet.GetComponent<Bullet>().Initialize(spawnPos.forward, spawnPos.position, bulletspeed, dmg);
        }
    }

}
