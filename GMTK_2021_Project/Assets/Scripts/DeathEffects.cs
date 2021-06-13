using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] string deathSoundName;
    GameManager game;
    HealthStat healthStat;

    void Awake()
    {
        game = FindObjectOfType<GameManager>();
        healthStat = GetComponent<HealthStat>();
        if(healthStat != null)
        {
            healthStat.OnUnitKilled += PlayDeathEffects;
        }
    }

    void PlayDeathEffects()
    {
        Instantiate(deathParticles, transform.position, transform.rotation);
        AudioManager.instance.PlaySound(deathSoundName);
            game.addPoints();
    }


}
