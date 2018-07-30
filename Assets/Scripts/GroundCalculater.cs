using UnityEngine;
using TMPro;

public class GroundCalculater : MonoBehaviour {

    enum GroundMode {SHOP, WAIT, SHRINK, END};

    [Header("GameSettings")]
    public float RoundTime;
    public float intervalTime;
    public float shoppingTime;
    public float playerStatsTime;
    public Vector2[] scales;
    public float speed = 10f;

    [Header("GeneralSettings")]
    public Transform ground;
    public TextMeshProUGUI countdownAusgabe;
    public TextMeshProUGUI RundenAusgabe;
    public GameObject stats;
    public GameObject shop;

    private float scaleOffset;
    private float countdown;
    private float shoppingInterval;
    private float playerStatsIntveral;
    private float scale = 1f;
    private int roundCounter = 0;

    private GroundMode mode = GroundMode.SHOP;
    private int stage = 0;
    private Vector3 scalingVec;

    private void Start()
    {
        stats.SetActive(false);
        countdown = intervalTime;
        shoppingInterval = shoppingTime;
        playerStatsIntveral = playerStatsTime;
        scalingVec = new Vector3(speed, speed, speed);
        scaleOffset = speed / 10.0f;
        stats.GetComponent<StatController>().forceOpenStats();
    }

    // Update is called once per frame
    void Update() {
        switch(mode)
        {
            case GroundMode.SHOP:
                RundenAusgabe.text = "Runde: " + (roundCounter+1);
                if (shoppingTime < 0.0f)
                {
                    shop.SetActive(false);
                    stats.GetComponent<StatController>().revert();
                    mode = GroundMode.WAIT;
                    shoppingTime = shoppingInterval;
                }
                else
                {
                    shop.SetActive(true);
                    shoppingTime -= Time.deltaTime;
                    countdownAusgabe.text = "Shop Zeit: " + Mathf.Floor(shoppingTime + 1).ToString();
                }
                break;
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
                ground.gameObject.SetActive(false);   
                mode = GroundMode.SHOP;
                roundCounter++;
                stage = 0;
                ground.gameObject.SetActive(true);
                ground.localScale = new Vector3(1f, 1f, 1f);
                stats.GetComponent<StatController>().forceOpenStats();
                break;          
        }
    }
}
