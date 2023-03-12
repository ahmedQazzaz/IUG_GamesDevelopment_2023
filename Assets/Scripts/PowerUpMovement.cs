using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 2;    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0, speed) * Time.deltaTime * -1);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (!(pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1 && pos.z > 0))
        {
            Destroy(gameObject);            
        }
    }
}
