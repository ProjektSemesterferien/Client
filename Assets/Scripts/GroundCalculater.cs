using UnityEngine;
using TMPro;

public class GroundCalculater : MonoBehaviour {

    enum GroundMode { WAIT, SHRINK, END};

    [Header("GameSettings")]
    public float RoundTime;
    public float intervalTime;
    public Transform ground;
    public Vector2[] scales;
    public TextMeshProUGUI countdownAusgabe;
    private float scaleOffset;

    private float countdown;
    private float scale = 1f;
    public float speed = 10f;

    private GroundMode mode = GroundMode.WAIT;
    private int stage = 0;
    private Vector3 scalingVec;

    private void Start()
    {
        countdown = intervalTime;
        scalingVec = new Vector3(speed, speed, speed);
        scaleOffset = speed / 10.0f;
    }

    // Update is called once per frame
    void Update() {
        switch(mode)
        {
            case GroundMode.WAIT:
                if (countdown < 0.0f)
                {
                    mode = GroundMode.SHRINK;
                    countdown = intervalTime;
                }
                else
                {
                    countdown -= Time.deltaTime;
                    countdownAusgabe.text = Mathf.Floor(countdown+1).ToString();
                }
                break;
            case GroundMode.SHRINK:
                countdownAusgabe.text = "Verkleinern";
                ground.localScale = ground.localScale - scalingVec * Time.deltaTime;
                if (Vector2.Distance(new Vector2(ground.localScale.x, ground.localScale.z), scales[stage]) < scaleOffset)
                {
                    stage++;
                    if (stage >= scales.Length)
                        mode = GroundMode.END;
                    else
                        mode = GroundMode.WAIT;
                }
                break;
            case GroundMode.END:
                countdownAusgabe.text = "Ende";
                ground.gameObject.SetActive(false);
                break;
        }
    }
}
