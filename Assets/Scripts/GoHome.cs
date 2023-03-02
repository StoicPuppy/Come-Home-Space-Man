using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.CanGoHome();
        if (manager.HasEnoughFruit == true)
        {
            manager.NextLevel();
        }
    }
}
