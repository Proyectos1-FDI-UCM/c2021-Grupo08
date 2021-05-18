using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f, speed= 0f, maxHealth = 200f;
    public Animator animator;
    private float cooldown = 0f;
    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Enemy1>()) // No tenemos script del enemigo 1 todavía -> Hito 2
        {
            health -= 75;
        }
    }
    */
    public LifeBar healthBar;

    void Awake()
    {
        health = maxHealth;

    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        animator.SetBool("Hurt", true);
        if (Time.time >= cooldown)
        {
            cooldown = (Time.time + 1f);
            animator.SetBool("Hurt", false);
        }

    }
    void Update()
    {
        if (health<=0)
        {
            GameManager.GetInstance().GameOver();
        }
    }

}
