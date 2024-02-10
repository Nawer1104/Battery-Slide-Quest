using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batterty : MonoBehaviour
{
    public Enum type;

    public GameObject vfxFinish;

    public bool canMove;

    public float speed = 2;

    public Transform target;

    private bool hasCollided;

    private void Awake()
    {
        canMove = false;

        target = null;

        hasCollided = false;
    }

    private void Update()
    {
        if (!canMove && target == null) return;

        Vector3 destination = target.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
       
        if (distance <= 0.05)
        {
            canMove = false;
            GameObject vfx = Instantiate(vfxFinish, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
            target.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("Drop") && !target && !canMove && !hasCollided)
        {
            hasCollided = true;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<BoxCollider2D>().isTrigger = true;
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].FindTarget(gameObject);
            return;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        canMove = true;
    }
}
