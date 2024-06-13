using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EnemyState 
{
    idle,
    run,
    attack
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState enemyState = EnemyState.idle;

    [SerializeField] private Transform target;
    [SerializeField] private Animator anim;
    [SerializeField] private float speedEnemy = 2f;
    [SerializeField] private float attackRange = 3f;
    //[SerializeField] private float chaseRange = 15f; // отвечает за дистанцию, на которой враг начнет преследовать игрока

    [SerializeField] private TMP_Text healthEnemyText;
    [SerializeField] private int maxHealthEnemy = 100;
    public int currentHealth;

    [SerializeField] private GameObject finishWindow;

    [SerializeField] private EnemsDied enemsDied;

    private void Start()
    {
        currentHealth = maxHealthEnemy;
        finishWindow.SetActive(false);
    }

    public void TakeDamage(int damageCount) 
    {
        currentHealth -= damageCount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);

            enemsDied.ZombiesDied();

            if (enemsDied.enemsAlive <= 0) 
            {
                ShowFinishWindow();
            }
        }

        healthEnemyText.text = currentHealth.ToString();
    }

    private void Update()
    {
        float distancePlayer = Vector3.Distance(target.position, transform.position);

        switch (enemyState) 
        {
            case EnemyState.idle:
                /*if (distancePlayer <= chaseRange) 
                {
                    ChangeDistance(EnemyState.run);
                }*/
                break;

            case EnemyState.run:
                if (distancePlayer <= attackRange)
                {
                    ChangeDistance(EnemyState.attack);
                }

                else 
                {
                    Vector3 moveDirection = (target.position - transform.position).normalized;
                    transform.forward = new Vector3(moveDirection.x, 0, moveDirection.z);

                    transform.position += transform.forward * speedEnemy * Time.deltaTime;
                }
                break;

            case EnemyState.attack:

                anim.SetBool("isAttack", true);
                break;
        }
    }

    public void ChangeDistance(EnemyState newState) 
    {
        enemyState = newState;

        if (newState == EnemyState.run) 
        {
            anim.SetBool("isRunning", true);
        }
    }

    public void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
        FindAnyObjectByType<TankController>().enabled = false;
    }

    
}
