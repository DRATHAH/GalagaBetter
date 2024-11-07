using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 initialForce;
    public Vector3 origin;
    public int dmg = 1;

    bool canHit = true;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(initialForce);
        StartCoroutine(DeleteAfterTime());
    }

    private void OnCollisionEnter(Collision collision) // If it hits something
    {
        DamageableCharacter damageable = collision.gameObject.transform.root.GetComponent<DamageableCharacter>(); // If the thing hit can be damaged
        if (damageable && canHit)
        {
            canHit = false;
            damageable.OnHit(dmg);
        }

        Destroy(gameObject);
    }

    public void Initialize(Vector3 _spawnPoint, Vector3 _origin, float _initForceStr, int damage) // Set bullet stats
    {
        initialForce = _spawnPoint * _initForceStr;
        origin = _origin;
        dmg = damage;
    }

    private IEnumerator DeleteAfterTime()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
