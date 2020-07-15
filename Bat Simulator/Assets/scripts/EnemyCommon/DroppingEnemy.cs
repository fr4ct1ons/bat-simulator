using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DroppingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject previewer;
    [SerializeField] private float previewerHeight;
    [SerializeField] private float timeToDestroyPreviewer = 1.0f;
    [SerializeField] private float damage;
    
    private void Start()
    {
        var temp = Instantiate(previewer, new Vector2(transform.position.x, previewerHeight), Quaternion.identity);
        Destroy(temp, timeToDestroyPreviewer);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Stats>(out Stats stats))
        {
            stats.SendDamage(damage);
        }
        Destroy(gameObject);
    }
}
