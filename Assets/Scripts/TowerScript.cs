using UnityEngine;
using System.Collections;

public class TowerScript : FriendlyBase{
    [SerializeField]
    private GameObject bullets;
    private GameObject enemies;

    public override void StartBattle()
    {
        base.StartBattle();

        enemies = GameObject.Find("Enemies");
    }

    public override void StopWave()
    {
        base.StopWave();

        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform deleteChild = transform.GetChild(i);
            Destroy(deleteChild.transform.gameObject);
        }
    }

    void Update()
    {
        if (base.inBattle && Random.Range(0, 20) == 0)
        {
            for (int i = enemies.transform.childCount - 1; i >= 0; i-- )
            {
                GameObject bullet = Instantiate(bullets, new Vector2(transform.position.x, transform.position.y + 400), Quaternion.identity) as GameObject;
                bullet.transform.parent = transform;

                bullet.GetComponent<BulletScript>().Target = enemies.transform.GetChild(i);
            }
        } 
    }
}
