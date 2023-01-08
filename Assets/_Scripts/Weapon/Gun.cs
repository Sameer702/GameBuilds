using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//deals with everything to do with the guns and their logic

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;

    public int maxAmmo = 20;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public int magazines;
    public AudioSource emptyMagazine;


    public Camera fpscam;
    public Animator animator;
    public Text ammoDisplay;


    private float nextTimeToFire = 0f;


    void Start()
    {   
        currentAmmo = maxAmmo;
    }


    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        ammoDisplay.gameObject.SetActive(true);

    }

    //checks if the player is shooting and also manages the guns ammo
    void Update()
    {
        ammoDisplay.text = currentAmmo.ToString() + "/" + magazines;

        if (magazines == 0)
        {
            currentAmmo = 0;
            if (Input.GetButton("Fire1"))
            {
                emptyMagazine.Play();
            }
            return;
        }

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

    //reloads gun
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
        magazines--;
    }

    //shoot mechanic
    void Shoot()
    {
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
        ammoDisplay.text = currentAmmo.ToString();

    }
}
