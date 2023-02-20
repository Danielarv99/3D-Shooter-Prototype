using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameObject bullet;
    public float speed;
    public Camera mainCamera;
    public GameObject bulletSpawn;
    public int bulletAmount = 12;
    public bool isReloading = false;
    private float rayLongitud = 100f;
    public LayerMask suelo;
    public AudioSource shot;
    public AudioSource reloadSound;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        PlayerRotation();
    }

    void Update()
    {
        Shot();
        
    }

    //Movimiento del jugador
    void Movement() 
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        playerRb.velocity = new Vector3 (horizontalInput * speed , playerRb.velocity.y , verticalInput * speed) * Time.deltaTime;
    }

    void PlayerRotation()
    {
        Ray laser = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit golpe;
        if (Physics.Raycast(laser , out golpe , rayLongitud , suelo))
        {
            Vector3 mousePosition = golpe.point - transform.position;
            mousePosition.y = 0f;

            Quaternion rotacionJugador = Quaternion.LookRotation (mousePosition);
            playerRb.MoveRotation(rotacionJugador);
        }

    }

    //Disparar
    void Shot()
    {   

        if (Input.GetMouseButtonDown(0) && !isReloading && bulletAmount > 0)
        {
            Instantiate(bullet , bulletSpawn.transform.position , transform.rotation);
            bulletAmount --;
            shot.Play();
            
        } else if (Input.GetMouseButtonDown(0) && bulletAmount==0)
        {
            reloadSound.Play();
            isReloading=true;
            Invoke("Reload", 2);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            reloadSound.Play();
            isReloading=true;
            Invoke("Reload", 2);
        }
        
    }


    void Reload()
    {
        bulletAmount = 12;
        isReloading = false;

    }
}
