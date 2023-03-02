using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    private int bounce;
    private GameManager manager;
    [SerializeField] private AudioClip ouch;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameManager.instance;
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("OnHitSound").GetComponent<AudioSource>().PlayOneShot(ouch);

        int index = Random.Range(0, 2);
        if(index > 0)
        {
            bounce = -100;
        }
        else
        {
            bounce = 100;
        }

        manager.Takedamage();
        GameObject.Find("Space Man").GetComponent<Rigidbody2D>().AddForce(new Vector2(bounce, 5), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
