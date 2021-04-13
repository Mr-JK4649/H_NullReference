using Chronos;
using UnityEngine;
using UnityEngine.UI;

public class ClockAnim : MonoBehaviour
{
    [SerializeField] private GlobalClock g_clock;
    [SerializeField] private float speed;
    [SerializeField] private float speedMultiplier;
    [SerializeField] private Image image;
    private Color origin_Color;
    private float alpha = 0;
    private float origin_Speed;

    private void Start()
    {
        origin_Color = image.color;
        origin_Speed = speed;
    }

    private void FixedUpdate()
    {
        if (g_clock.timeScale == 1)
        {
            alpha -= Time.deltaTime / 2;
            if (alpha < 0.15) alpha = 0.15f;

            speed = origin_Speed;
        }
        else { alpha = 1; speed = origin_Speed * speedMultiplier; }

        image.color = new Color(origin_Color.r, origin_Color.g, origin_Color.b, alpha);
        RotateClock();
    }

    private void RotateClock() {
        this.gameObject.transform.Rotate(0, speed * g_clock.timeScale, 0);
    }
}
