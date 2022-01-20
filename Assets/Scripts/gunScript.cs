using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunScript : MonoBehaviour
{
    public int ammo;
    public GameObject gunAnimObject;
    private Animation gunAnim;
    private bool canshoot;
    private float muzzleTime;
    public bool hasGun;
    private GameObject gunParentObject;

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
        if (hasGun)
        {
            gunParentObject.SetActive(true);
        }
        else
        {
            gunParentObject.SetActive(false);
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
        kickGO.localRotation = Quaternion.Euler(kickGO.localRotation.eulerAngles - new Vector3(kickUp, Random.Range(-kickSideways, kickSideways), 0));
        gunAnim.Play();
        ammo = ammo - 1;
        canshoot = false;
        muzzleTime = 0.05f;
        StartCoroutine("gunCooldown");
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
}
