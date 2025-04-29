using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JC : MonoBehaviour
{
    public ParticleSystem particle;
    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    void Start()
    {
        StartCoroutine(CheckParticleCompletion());
    }

    IEnumerator CheckParticleCompletion()
    {
        while (particle.IsAlive())
        {
            yield return null; // µÈ´ýÏÂÒ»Ö¡
            Time.timeScale = 0f;
        }
        SkillController.Instance.RestoreFilter();
        Time.timeScale = 1f;
        Destroy(gameObject);
    }
}
