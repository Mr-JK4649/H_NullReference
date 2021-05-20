using UnityEngine;
using UnityEngine.UI;

public class OrbPointOnDisplay : MonoBehaviour
{
    private float count = 0;
    private Text thisText;
    private Color this_Color;

    private void Start()
    {
        thisText = GetComponent<Text>();
        this_Color = thisText.color;
    }

    private void FixedUpdate()
    {
        this.transform.position += new Vector3(0, 0.1f, 0);

        count += Time.deltaTime;
        if (count > 0.5f) Destroy(this.gameObject);

        //transform.rotation = transform.parent.rotation;


        float alpha = 1 - count * 2;
        this_Color.a = alpha;
        thisText.color = this_Color;
    }
}
