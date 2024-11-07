using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHit : MonoBehaviour
{
    [Tooltip("Place that player teleports to")]
    public Transform teleportLocation;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();

        if (player != null)
        {
            player.canMove = false;
            other.transform.position = new Vector3(teleportLocation.position.x, player.transform.position.y, player.transform.position.z);
            StartCoroutine(DelayMove(player));
        }

        Enemy enemy = other.transform.GetComponent<Enemy>();
        if (enemy != null)
        {
            Destroy(enemy.gameObject);
        }
    }

    IEnumerator DelayMove(Player player)
    {
        yield return new WaitForSeconds(.05f);
        player.canMove = true;
    }
}
