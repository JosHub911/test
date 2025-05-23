using UnityEngine;

public class Ball : MonoBehaviour
{
    Vector3 velocity;
    Vector3 direction = new Vector3(1,2,0);
    float speed =2 ;

    Vector2 minScreen, maxScreen; 

    void Start()
    {
        direction = direction.normalized;
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero); 
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));   
    }
    
    // Update is called once per frame
    void Update()
    {
        velocity = direction * speed;
        transform.position += velocity * Time.deltaTime;

        if (transform.position.x + transform.localScale.x / 2 > maxScreen.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.x - transform.localScale.x / 2 < minScreen.x)
        {
            direction.x = -direction.x;
        }
        if (transform.position.y + transform.localScale.y / 2 > maxScreen.y)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y - transform.localScale.y / 2 < minScreen.y)
        {
            direction.y = -direction.y;
        }

    }

}
