using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC : MonoBehaviour
{
    public ParticleSystem particle;
    private Collider2D col;

    [Header("ʱ�����")]
    [SerializeField] private float timeFreezeDuration = 2f; // ʱ����ͣ��ʱ��

    void Awake()
    {
        // �������Ӳ���ʱ������Ӱ��
        var main = particle.main;
        main.simulationSpace = ParticleSystemSimulationSpace.World;
        main.useUnscaledTime = true; // �ؼ����ã�

        col = GetComponent<Collider2D>();
        col.enabled = true;
    }

    void Start()
    {
        StartCoroutine(TimeFreezeRoutine());
    }

    IEnumerator TimeFreezeRoutine()
    {
        // ��ͣ��Ϸʱ��
        Time.timeScale = 0f;

        // ʹ����ʵʱ�������Ӳ���
        float startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup - startTime < timeFreezeDuration)
        {
            // ��������˺���ʹ����ʵʱ������
            
            yield return new WaitForSecondsRealtime(0.1f); // ÿ0.1����һ��
        }

        // �ָ�ʱ��
        Time.timeScale = 1f;
        DealDamageToEnemies();
        SkillController.Instance.RestoreFilter();
        Destroy(gameObject);
    }

    void DealDamageToEnemies()
    {
        ContactFilter2D filter = new ContactFilter2D();
        Collider2D[] results = new Collider2D[10];

        int count = col.OverlapCollider(filter, results);
        for (int i = 0; i < count; i++)
        {
            Enemy enemy = results[i].GetComponent<Enemy>();
            if (enemy != null)
            {
                // ֱ����ɱ
                enemy.GetDamage(9999);
                DamageNumberController.instance.SpawnDamage(
                    9999,
                    enemy.transform.position
                );
            }
        }
    }
}

