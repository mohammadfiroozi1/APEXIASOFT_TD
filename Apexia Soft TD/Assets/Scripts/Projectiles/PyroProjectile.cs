using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyroProjectile : Projectile
{
    [SerializeField] ProjectileHitEffectPool hitEffectPool;
    [SerializeField] AoeProjectileData projectileData;
    [SerializeField] LayerMask enemylayer;
    ProjectileHitEffect hitEffect;

    public override void Initialize(Transform target, float moveSpeed)
    {
        base.Initialize(target, moveSpeed);
    }


    public override void Update()
    {
        base.Update();
        MoveToTarget(target);
        StartCoroutine(DestroyProjectile());

    }
    public override void MoveToTarget(Transform target)
    {
        base.MoveToTarget(target);
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position + new Vector3(0, 1f, 0), moveSpeed * Time.deltaTime); ;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.gameObject.transform == target)
        {
            var enemies = Physics.OverlapSphere(transform.position, projectileData.damageRadius, enemylayer);
            foreach (var enemy in enemies)
            {
                var targetEnemy = enemy.gameObject.GetComponent<Enemies>();
                targetEnemy.takeDmg(GetDamageAmount());
                hitEffect = hitEffectPool.pool.Get();
                hitEffect.transform.position = target.transform.position + new Vector3(0, 1f, 0);
                StartCoroutine(DestroyHitEffect());
                data.projectilePool.OnReleaseObject(this);
            }


        }
    }



    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(1.5f);
        data.projectilePool.OnReleaseObject(this);

    }
    IEnumerator DestroyHitEffect()
    {
        yield return new WaitForSeconds(0.05f);
        hitEffectPool.OnReleaseObject(hitEffect);

    }
}
