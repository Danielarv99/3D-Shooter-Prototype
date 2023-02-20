using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy enemyInstance;
    public static int enemiesKilled;
    public GameObject target;
    private Rigidbody enemyRb;
    private NavMeshAgent IA;
    public Transform targetPosition;
    public GameObject bullet;
    public ParticleSystem explosion;
    public float shotSpeed;
    public GameObject life;
    public AudioSource shot;

    // Start is called before the first frame update

    void Awake()
    {
        enemyInstance = this;
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform;
        enemyRb = GetComponent<Rigidbody>();
        IA = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        InvokeRepeating("Shot", 1, shotSpeed);
    }

    // Update is called once per frame

    void FixedUpdate()
    {   Vector3 lookAt = targetPosition.position - transform.position;
        Quaternion enemyLook = Quaternion.LookRotation(lookAt);
        enemyRb.MoveRotation(enemyLook);
        EnemyMovement();
    }
    void Update()
    {


    }

    void EnemyMovement()
    {
        IA.SetDestination(targetPosition.position);
    }

    void Shot()
    {
        Instantiate(bullet , transform.position , transform.rotation);
        shot.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemiesKilled++;
            HealthSpawner();
            explosion.Play();
            Destroy(gameObject, 0.1f);
            Destroy(other.gameObject, 0.1f);

        }
    }

    void HealthSpawner()
    {
        int i = Random.Range (1,5);
        if (i == 1)
        {
            Instantiate(life, transform.position, life.transform.rotation);

        }
    }
}
