using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    static GameObject player;
    static Vector3 startPosition;    
    bool didActivateLongPowerUp = false;

    [SerializeField]
    float speed = 3;
    // Start is called before the first frame update
    void Start()
    {

        Movement.player = this.gameObject;
        Movement.startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(hMove, 0) * Time.deltaTime * speed);

        int bricksCount = GameObject.FindGameObjectsWithTag("Brick").Length;
        if (bricksCount == 0) {
            Debug.Log("You Won");
        }

        if (Input.GetKeyDown(KeyCode.Return) && didActivateLongPowerUp)
        {
            GetComponent<Animator>().SetTrigger("shrink");
        }

    }

    public static void JumpToStart()
    {
        player.transform.position = startPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "PowerUp")
        {
            didActivateLongPowerUp = true;
            GetComponent<Animator>().SetTrigger("grow");

            Destroy(otherObject);
        }
    }
}
