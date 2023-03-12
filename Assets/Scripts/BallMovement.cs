using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMovement : MonoBehaviour
{
    [SerializeField]
    float moveForce = 5;
    private bool didStart = false;
    Vector3 startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space) && !didStart)
        {
            StartMoving();
        }

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x >= 0 && pos.x <= 1 && pos.y >= 0 && pos.y <= 1 && pos.z > 0)
        {
            // Your object is in the range of the camera, you can apply your behaviour
            
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            LevelController.shared.lives -= 1;
            transform.position = startPosition;
            didStart = false;
            Movement.JumpToStart();
            if (LevelController.shared.lives == 0)
            {
                Destroy(this.gameObject);
                GameObject.Find("EventSystem").GetComponent<UIManager>().EndLevel();
            }
            
        }


    }

    void StartMoving()
    {

        int x = Random.Range(0, 2);
        float factor = x == 0 ? 1 : -1;

        GetComponent<Rigidbody2D>().AddForce(new Vector2(moveForce * factor, moveForce));
        didStart = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.tag == "Brick")
        {
            LevelController.shared.score += 1;
            Destroy(otherObject);
            Debug.Log(LevelController.shared.score);

            //Get Random Value
            int x = Random.Range(0, 0);
            if (x == 0)
            {
                //Method 1 to find the prefab from the assets (should be in the Resources folder)
                GameObject prefabObj = Resources.Load<GameObject>("Prefabs/obj_powerUp_long");                
                Instantiate(prefabObj,otherObject.transform.position, Quaternion.identity);

                //Method 2 to link between the code and the prefab as variable (not preffered in this case)
            }
        }
    }

    
}
