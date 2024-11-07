using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPickup : MonoBehaviour

{
    public int score = 1;
    private TMP_Text scoretxt;
    // Start is called before the first frame update
    void Start()
    {
        scoretxt = GameManager.instance.scoretxt;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.transform.GetComponent<Player>();

        if (player != null)
        {
           GameManager.instance.score += score;
           scoretxt.text = "score: " + GameManager.instance.score;
            Destroy(gameObject);

        }

        
    }

}
