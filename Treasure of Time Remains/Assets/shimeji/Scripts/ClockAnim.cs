using Chronos;
using UnityEngine;
using UnityEngine.UI;

public class ClockAnim : MonoBehaviour
{
    private GlobalClock[] g_clock;
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Image image;
    [SerializeField] private ParticleSystem rewindParticle;
    [SerializeField] private GameObject stopAnimation;
    private Color origin_Color;
    private float alpha = 0;
    private float origin_Speed;

    private void Start()
    {
        origin_Color = image.color;
        origin_Speed = speed;
        g_clock = GameObject.Find("Timekeeper").GetComponents<GlobalClock>();
    }

    private void FixedUpdate()
    {
        float timeS = g_clock[1].timeScale;

        if (timeS == 1)
        {
            //徐々に透明に
            alpha -= Time.deltaTime / 2;
            if (alpha < 0.15) alpha = 0.15f;

            //時計の速度をデフォルトに
            speed = origin_Speed;

            if (rewindParticle && rewindParticle.isPlaying) rewindParticle.Stop();
            if (stopAnimation && stopAnimation.activeSelf) stopAnimation.SetActive(false);
        }
        else {

            //不透明に
            alpha = 1;

            //反時計回りに高速回転
            speed = origin_Speed * speedMultiplier;

            //パーティクルシステム
            if (rewindParticle && timeS == -2 && !rewindParticle.isPlaying)
                rewindParticle.Play();
            if (stopAnimation && timeS == 0 && !stopAnimation.activeSelf)
                stopAnimation.SetActive(true);
        }

        image.color = new Color(origin_Color.r, origin_Color.g, origin_Color.b, alpha);
        RotateClock();
    }

    private void RotateClock() {
        this.gameObject.transform.Rotate(0, speed * g_clock[1].timeScale, 0);
    }
}
