using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform tower;
    [SerializeField] private float speedRotateTower = 50f;

    [SerializeField] private GameObject fireEffectPrefab;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 10f;

    [SerializeField] private float delayBetweenShoots = 5.0f;
    private bool isReloading = false; // перезарядка орудия

    [SerializeField] private TMP_Text textReload;

    public void Fier()
    {
        if (!isReloading)
        {
            textReload.text = "Reloading...";

            GameObject fireEffect = Instantiate(fireEffectPrefab, firePoint.position, firePoint.rotation);
            Destroy(fireEffect, 2f);

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            bulletRb.AddForce(firePoint.up * fireForce, ForceMode.Impulse);

            Destroy(bullet, 3f);

            isReloading = true;
            Invoke("FinishReloading", delayBetweenShoots);

            StartCoroutine(UpdateReloadUI(delayBetweenShoots));
        }
    }

    public void FinishReloading()
    {
        isReloading = false;
    }

    public IEnumerator UpdateReloadUI(float reloadTime) // создаем корутину для UI-элементов перезарядки
    {
        float timer = 0f;

        while (timer < reloadTime)
        {
            textReload.text = "Reloading... " + (reloadTime - timer).ToString("0.0") + "s";
            yield return null;
            timer += Time.deltaTime;
        }

        textReload.text = "You ready!";
    }
}
