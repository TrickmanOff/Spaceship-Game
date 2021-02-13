using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShipExplosions : MonoBehaviour
{
    public GameObject explosion;
    public float explosionCooldown;

    private PolygonCollider2D _collider;

    private float x1, x2, y1, y2;

    private void Start()
    {

        _collider = this.GetComponent<PolygonCollider2D>();

        StartCoroutine(IExplode());
    }


    IEnumerator IExplode()
    {
        for (; ; )
        {
            x1 = _collider.bounds.center.x - _collider.bounds.extents.x;
            x2 = _collider.bounds.center.x + _collider.bounds.extents.x;
            y1 = _collider.bounds.center.y - _collider.bounds.extents.y;
            y2 = Mathf.Min(9f, _collider.bounds.center.y + _collider.bounds.extents.y);

            if (y1 >= y2) break;

            Vector2 pnt = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
            while (!_collider.OverlapPoint(pnt))
                pnt = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));

            Instantiate(explosion, pnt, Quaternion.identity);
            yield return new WaitForSeconds(explosionCooldown);
        }
    }
}
