/*
 * Keegan Graf
 * Updated 4/23/2023
 * Antonio Massa
 * Updated 05/08/2023
 */
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI_V2 : MonoBehaviour
{
    #region private variables
    private EnemyRef reference;
    private Animator animator;
    private float attackDistance;
    private float pathUpdateDeadline;
    private bool inRange = false;
    private PlayerHealth health;
    #endregion

    #region Serialized variable
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float attackDelay = 10;
    [SerializeField]
    private float attackTime = 10;
    #endregion

    private void Awake()
    {
        reference= GetComponent<EnemyRef>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        attackDistance = reference.navMeshagent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        updateEnemyState();
    }

    private void updateEnemyState()
    {
        updateTargetRange();
        if (inRange)
        {
            TargetLock();
            if(attackTime >= attackDelay)
            {
                Attacking();
            }
        }
        else
        {
            UpdatePath();
        }
        attackTime += Time.deltaTime;
    }


    private void TargetLock()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
        if(animator != null)
        {
            if(attackTime > 1.7f) 
            {
                animator.SetBool("Attacking", false);
            }
            animator.SetBool("Walking", false);
        }
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + reference.pathUpdateDelay;
            reference.navMeshagent.SetDestination(target.position);
        }
        if(animator != null)
        {
            animator.SetBool("Attacking", false);
            animator.SetBool("Walking", true);
        }
    }

    private void Attacking()
    {
        if (animator != null)
        {
            animator.SetBool("Attacking", true);
        }
        if(reference!= null)
        {
            health.TakeDamage(reference.damage);
        }
        attackTime = 0.0f;
    }

    private void updateTargetRange()
    {
        inRange = Vector3.Distance(transform.position, target.position) <= attackDistance;
    }
}
