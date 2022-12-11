using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser_sc : MonoBehaviour
{
    [SerializeField]
    private float speed = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -5.0f) {
            Destroy(this.gameObject);
        }
    }
}
