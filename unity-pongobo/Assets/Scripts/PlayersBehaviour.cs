using UnityEngine;

public class PlayersBehaviour : MonoBehaviour
{
    public float speed;
    public bool up;
    public KeyCode key;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //definindo a coordenada y do vetor
        float yMovement = speed * Time.deltaTime;

        //manipulação do sentido
        if(up && transform.position.y >= 4.33 || up && Input.GetKeyDown(key))
            up = false;
        else if(transform.position.y <= - 4.33 || Input.GetKeyDown(key))
            up = true;

        //troca de sentido
        if(up)
            transform.Translate(new Vector3(0, yMovement, 0));
        else
            transform.Translate(new Vector3(0, -yMovement, -0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ball")
        {
            speed *= 1.05f;
        }
    }
}
