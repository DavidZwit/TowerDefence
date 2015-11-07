using UnityEngine;
using System.Collections;

public class BulletBase : MonoBehaviour {
    int bulletSpeed = 50;
    int lifeTime = 100;

	void FixedUpdate () {

        lifeTime--;
        if (lifeTime <= 0) Destroy(this.gameObject);
        transform.Translate(transform.right * bulletSpeed);
	}
}
