using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 20;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;


    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public Animator animator;


    private float nextTimeToFire = 0f;


    void Start()
    {
        currentAmmo = maxAmmo;
    }


    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime -.25f);
        animator.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);


        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

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
