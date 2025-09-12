
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; //variable para guardar la velocidad
    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //leer las teclas WASD o las flechas
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //creamos un vector para direccion del movimiento
        Vector3 direction = new Vector3(moveHorizontal, moveVertical, 0);

        transform.Translate(direction * speed * Time.deltaTime);

    }
    
    //funcion especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo //trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Print("prueba");
        if (other.CompareTag("collectable"))
        {
            score = score + 1;

            Destroy(other.gameObject);
            Debug.Log("Collected!!!");
            Debug.Log("Score: " + score);
        }

        if (score >= 3)
        {
            Debug.Log("Has Ganado!!!");
        }
    }
}
