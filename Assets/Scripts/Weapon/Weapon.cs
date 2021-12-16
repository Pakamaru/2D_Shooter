using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int MaxMagazine { get; set; }
    protected int curMagazine;
    public float AttackSpeed { get; set; }
    public float ReloadSpeed { get; set; }
    protected float reloadTimer;
    public bool Reloading { get; set; }
    protected bool shooting;
    [SerializeField]
    protected GameObject bullet;

    public void SetVars(GameObject par, int mag, float aS, float rS)
    {
        MaxMagazine = mag;
        AttackSpeed = aS;
        ReloadSpeed = rS;

        curMagazine = MaxMagazine;
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
