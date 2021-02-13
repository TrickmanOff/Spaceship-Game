using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBossExplosions : StateMachineBehaviour
{
    public GameObject explosion;
    public float explosionCooldown;

    private PolygonCollider2D _collider;
    private float timer;

    private float x1, x2, y1, y2;

    void Explode()
    {
        x1 = _collider.bounds.center.x - _collider.bounds.extents.x;
        x2 = _collider.bounds.center.x + _collider.bounds.extents.x;
        y1 = _collider.bounds.center.y - _collider.bounds.extents.y;
        y2 = Mathf.Min(9f, _collider.bounds.center.y + _collider.bounds.extents.y);

        if (y1 >= y2) return;

        Vector2 pnt = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));
        while (!_collider.OverlapPoint(pnt))
            pnt = new Vector2(Random.Range(x1, x2), Random.Range(y1, y2));

        Instantiate(explosion, pnt, Quaternion.identity);
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<BossShipBehavior>().StopShooting();

        _collider = animator.GetComponent<PolygonCollider2D>();
        timer = explosionCooldown;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = explosionCooldown;
            Explode();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StopGameManager.instance.startSpawn();
        StopGameManager.instance.unfreezeDistance();
        Destroy(animator.gameObject);
    }
}
