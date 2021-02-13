using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1Behavior : MonoBehaviour
{
    public GameObject laser;
    public float rotationSpeed = 30f;

    private Animator _animator;
    private Transform _player;

    private void Update()
    {
        float rotAngle = this.transform.eulerAngles.z;
        if (rotAngle > 180f)
            rotAngle = -(360f - rotAngle);

        float angle = Vector2.SignedAngle(Vector2.down, new Vector2(_player.position.x - this.transform.position.x, _player.position.y - this.transform.position.y));
        angle -= rotAngle;

        this.transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime * Mathf.Sign(angle)));
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _animator = GetComponent<Animator>();

        //_animator.Play("Gun1Reloading");
        //Instantiate(laser, transform.position, transform.rotation);
    }
}
