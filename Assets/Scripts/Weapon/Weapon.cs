using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected int magazine;
    protected float AttackSpeed { get; set; }
    protected float ShootRange { get; set; }
    protected float ReloadSpeed { get; set; }
    protected float reloadTimer;
    protected bool Reloading { get; set; }
    protected bool shooting;
    [SerializeField]
    protected GameObject bullet;

    public void SetVars(GameObject par, int mag, float aS, float rS)
    {
        magazine = mag;
        AttackSpeed = aS;
        ReloadSpeed = rS;
    }

    public void Shoot()
    {
        if (!shooting)
            StartCoroutine("Shooter");
    }

    public IEnumerator Shooter()
    {
        shooting = true;
        bool bullets = CheckForBullets();
        if (bullets)
        {
            GameObject bullet_ = Instantiate(bullet, transform.parent.transform) as GameObject;
            magazine--;
        }
        else
        {
            //Reload
            Reloading = true;
            StartCoroutine("Reload", ReloadSpeed);
        }
        yield return new WaitForSeconds(AttackSpeed);
        shooting = false;
    }
    public void Reload()
    {
        //yield return new WaitForSeconds(reloadSpeed);
        Reloading = false;
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
        else
        {

        }
    }

    private bool CheckForBullets()
    {
        if (magazine == 0)
            return false;
        return true;
    }
}
