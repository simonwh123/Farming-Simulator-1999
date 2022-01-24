using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gunScript : MonoBehaviour
{
    public int ammo;
    public GameObject gunAnimObject;
    private Animation gunAnim;
    private bool canshoot;
    private float muzzleTime;
    public bool hasGun;
    private GameObject gunParentObject;
    public GameObject ammoText;

    [Header("Kickback")]
    public Transform kickGO;
    public float kickUp = 0.5f;
    public float kickSideways = 0.5f;

    [Header("Muzzle-Flash")]
    public GameObject muzzleFlash;

    // Start is called before the first frame update
    void Start()
    {
        gunParentObject = GameObject.Find("GunParent");
        gunAnim = gunAnimObject.GetComponent<Animation>();
        canshoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0 && canshoot && hasGun)
        {
            fireGun();
        }
    }

    private void FixedUpdate()
    {


        //Ammo UI
        ammoText.GetComponent<TextMeshProUGUI>().text = ammo + "/7";

        if (hasGun)
        {
            gunParentObject.SetActive(true);
            ammoText.SetActive(true);

        }
        else
        {
            gunParentObject.SetActive(false);
            ammoText.SetActive(false);
        }

        muzzleTime = muzzleTime - Time.deltaTime;

        if (muzzleTime > 0)
        {
            muzzleFlash.SetActive(true);
        }
        else
        {
            muzzleFlash.SetActive(false);
        }
    }

    public void fireGun()
    {
        int layerMask = 1 << 7;
        kickGO.localRotation = Quaternion.Euler(kickGO.localRotation.eulerAngles - new Vector3(kickUp, Random.Range(-kickSideways, kickSideways), 0));
        gunAnim.Play();
        ammo = ammo - 1;
        canshoot = false;
        muzzleTime = 0.05f;
        StartCoroutine("gunCooldown");

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                hit.collider.GetComponent<EnemyScript>().hitSound.Play();
                hit.collider.GetComponent<EnemyScript>().die();
                hit.rigidbody.AddExplosionForce(500f, transform.position, 50f);
            }

        }
    }

    IEnumerator gunCooldown()
    {
        yield return new WaitForSeconds(2);
        canshoot = true;
    }

    public void pickupAmmo()
    {
        ammo = ammo + 1;
    }

    public void pickupGun()
    {
        hasGun = true;
    }
}
