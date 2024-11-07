using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 1;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();

        if (player != null)
        {
            player.OnHit(-health);
            Destroy(gameObject);

        }


    }


}
