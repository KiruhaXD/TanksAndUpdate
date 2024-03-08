using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TowerController : MonoBehaviour
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

    private void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        float rotateTower = hor * speedRotateTower * Time.deltaTime;

        // для данной модели у нас стоит направление forward,
        // т.к у нас изначально моделька стоит под углом 90 градусов и башня крутилась неверно когда я использовал направление Vector3.up
        // также я поставил знак "-" для того чтобы направление башни соответстовавало нажатию нужных клавиш влево и вправо
        tower.Rotate(-Vector3.forward, rotateTower);

        if (Input.GetKeyDown(KeyCode.Space) && !isReloading) 
        {
            Fier();
        }  
    }

    public void Fier()
    {
        if (!isReloading)
        {
            textReload.text = "Reloading...";

            GameObject fireEffect = Instantiate(fireEffectPrefab, firePoint.position, firePoint.rotation);
            Destroy(fireEffect, 3f);

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
