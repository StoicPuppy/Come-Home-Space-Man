using UnityEngine;

public class FruitPickUp : MonoBehaviour
{
    private GameManager manager;
   

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.TotalNumberFruit++;
        manager.NumberOfFruit++;
        manager.FruitCount.text = "Fruits : " + manager.NumberOfFruit.ToString();
        
        if (gameObject.tag == "Melon")
        {
            manager.PlayParticle(0, gameObject);
        }
        else if (gameObject.tag == "Pineapple")
        {
            manager.PlayParticle(1, gameObject);
        }
        else if (gameObject.tag == "Strawberry")
        {
            manager.PlayParticle(2, gameObject);
        }
        

        Destroy(gameObject);
    }

}
