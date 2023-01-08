using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//deals with melee combat

public class WeaponController : MonoBehaviour
{
    public GameObject Sword, Pistol;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public bool isAttacking = false;

    public float damage = 25f;
    public float range = 6f;

    public Camera fpscam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Sword.activeSelf)
        {
            if (CanAttack)
            {
                Attack();
                SwordAttack();
            }
        }
    }


    public void SwordAttack()
    {
        Debug.Log("Sword");
        isAttacking = true;
        CanAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

    void Attack()
    {
        Debug.Log("Gun");
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.takeDamage(damage);
            }
        }
    }
}
