using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

enum EnemyState 
{
    idle,
    run,
    attack
}

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyState enemyState = EnemyState.idle;
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;
    [SerializeField] private float speedEnemy = 2f;
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private float chaseRange = 10f; // отвечает за дистанцию, на которой враг начнет преследовать игрока

    [SerializeField] private TMP_Text healthEnemyText;
    [SerializeField] private int maxHealthEnemy = 100;
    [SerializeField] private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealthEnemy;
    }

    public void TakeDamage(int damageCount) 
    {
        currentHealth -= damageCount;

        if (currentHealth <= 0) 
        {
            NextLevel();
            Destroy(gameObject);
        }
        healthEnemyText.text = currentHealth.ToString();
    }

    public void NextLevel() 
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene(next);
        }
    }

    private void Update()
    {
        float distancePlayer = Vector3.Distance(transform.position, player.position);

        switch (enemyState) 
        {
            case EnemyState.idle:
                if (distancePlayer <= chaseRange) 
                {
                    ChangeDistance(EnemyState.run);
                }
                break;

            case EnemyState.run:
                if (distancePlayer <= attackRange)
                {
                    ChangeDistance(EnemyState.attack);
                }

                else 
                {
                    Vector3 moveDirection = (player.position - transform.position).normalized;
                    transform.forward = new Vector3(moveDirection.x, 0, moveDirection.z);

                    transform.position += transform.forward * speedEnemy * Time.deltaTime;
                }
                break;

            case EnemyState.attack:

                anim.SetBool("isAttack", true);
                break;
        }
    }

    void ChangeDistance(EnemyState newState) 
    {
        enemyState = newState;

        if (newState == EnemyState.run) 
        {
            anim.SetBool("isRunning", true);
        }
    }
}
