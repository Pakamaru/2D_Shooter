using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxMagazine { get; set; }
    public int curMagazine { get; set; }
    public float AttackSpeed { get; set; }
    public float ReloadSpeed { get; set; }
    private float reloadTimer;
    public bool Reloading { get; set; }
    private bool shooting;
    [SerializeField]
    private GameObject bullet;

    public void SetVars(int mag, float aS, float rS)
    {
        MaxMagazine = mag;
        AttackSpeed = aS;
        ReloadSpeed = rS;

        curMagazine = MaxMagazine;
    }

    public float GetAS()
    {
        return AttackSpeed;
    }
    public float GetRS()
    {
        return ReloadSpeed;
    }

    public void Shoot()
    {
        if (!shooting)
            StartCoroutine("Shooter");
    }

    public IEnumerator Shooter()
    {
        shooting = true;
        bool bullets = curMagazine == 0 ? false : true;
        if (bullets)
        {
            GameObject bullet_ = Instantiate(bullet, transform.parent.transform) as GameObject;
            curMagazine--;
            if (gameObject.GetComponents<PlayerBasicGun>().Length > 0)
                GetComponentInParent<PlayerUI>().SetAmmo(curMagazine, MaxMagazine);
        }
        else
        {
            Reloading = true;
            StartCoroutine(Reload(ReloadSpeed));
        }
        yield return new WaitForSeconds(AttackSpeed);
        shooting = false;
    }
    public IEnumerator Reload(float time)
    {
        yield return new WaitForSeconds(time);
        Reloading = false;
        curMagazine = MaxMagazine;
        if (gameObject.GetComponents<PlayerBasicGun>().Length > 0)
            GetComponentInParent<PlayerUI>().SetAmmo(curMagazine, MaxMagazine);
        //Play sound
    }

    private void Start()
    {
        reloadTimer = ReloadSpeed;
    }

    private void Update()
    {
        if (reloadTimer > 0 && Reloading)
        {
            reloadTimer -= Time.deltaTime;
        }
    }
}
