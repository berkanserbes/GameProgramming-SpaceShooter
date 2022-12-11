using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    private Player_sc player_sc;
    public float fireRate = 0.5f;
    public float nextFire = 0f;

    public GameObject EnemyLaserPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        player_sc = GameObject.Find("Player").GetComponent<Player_sc>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -5.4f) {
            float randomX = Random.Range(-14f, 14f);
            transform.position = new Vector3(randomX, 7.4f, 0);
        }
        if ( Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            EnemyFire();
        }
    }

    void EnemyFire() {
         Instantiate(EnemyLaserPrefab, transform.position+new Vector3(0, -1.2f, 0), Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            
            //TODO Damage the player
            Player_sc player = other.transform.GetComponent<Player_sc>();
            if (player != null) {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
        else if (other.tag == "Laser") {

            if (player_sc != null) {
                player_sc.AddScore(10);
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        Debug.Log("Hit: " + other.transform.name);
    }
}
