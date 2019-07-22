using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public GameObject bullet_explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        var check = Instantiate(bullet_explosion, transform.position, gameObject.transform.rotation);
        check.GetComponent<Animator>().enabled = true;
        Destroy(check, 1);

        if (coll.gameObject.tag == "WALL_normal" ||  coll.gameObject.tag == "BaseBlock")
        {
            
            Destroy(coll.gameObject);
        }

        Destroy(gameObject);
    }
}
