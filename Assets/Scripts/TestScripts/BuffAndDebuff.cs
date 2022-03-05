using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffAndDebuff : MonoBehaviour
{
    Animator playerAnim;
    GameObject player;
    PlatformLooping platformLooping;
    float speedAdjustment;

    void Start()
    {
        player = GameObject.Find("Player");
        playerAnim = player.GetComponent<Animator>();

        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        platformLooping = FindObjectOfType<PlatformLooping>().GetComponent<PlatformLooping>();

        if (tag == "Basic Buff")
            speedAdjustment = platformLooping.speed / 10;
        if (tag == "Basic Debuff")
            speedAdjustment = platformLooping.speed / -10;
    }

    void FixedUpdate()
    {
        transform.parent.position += Vector3.back * platformLooping.speed;

        if (player.transform.position.z > transform.parent.position.z + 10f)
            Destroy(transform.parent.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (speedAdjustment >= 0)
            {
                if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("HitBuff"))
                    playerAnim.SetTrigger("hitBuff");
            }
            else
            {
                if (!playerAnim.GetCurrentAnimatorStateInfo(0).IsName("HitDebuff"))
                    playerAnim.SetTrigger("hitDebuff");
            }

            platformLooping.speed += speedAdjustment;
            Destroy(transform.parent.gameObject);
        }
    }
}
