using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        if (screenPos.x > 1)
        {
            Destroy(gameObject);
            return;
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamagable damagable = other.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.Damage(1);
            Destroy(gameObject);
        }
    }
};