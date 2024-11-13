using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPickup : MonoBehaviour
{
    public enum PowerupType
    {
        shield,
    }
    public PowerupType type;
    public float duration;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();

        if (player)
        {
            player.GivePowerup(type, duration);
            Destroy(gameObject);
        }
    }
}
