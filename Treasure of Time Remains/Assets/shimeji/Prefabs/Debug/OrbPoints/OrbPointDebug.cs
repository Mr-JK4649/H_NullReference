using UnityEngine;
using UnityEngine.UI;

public class OrbPointDebug : MonoBehaviour
{

    private Slider _span;
    private Timerecover _timerecover;
    private Text _rangetext;

    private void Start()
    {
        _span = GameObject.Find("Span").GetComponent<Slider>();
        _rangetext = GameObject.Find("RangeText").GetComponent<Text>();
        _timerecover = GameObject.Find("ThirdPersonController").GetComponent<Timerecover>();
        _timerecover.isDebug = true;
    }

    private void FixedUpdate()
    {
        _timerecover.range = _span.value * 10f;
        _rangetext.text = _timerecover.range.ToString("0.0");
    }
}
