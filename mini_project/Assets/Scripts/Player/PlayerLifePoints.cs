using UnityEngine;
using UnityEngine.UI;

public class PlayerLifePoints : MonoBehaviour
{
    private Text showPlayerLivePoints;
    public PayerMouvements player;
    int x = 50;
    private static string SUFIX = "PlayerLifePoints: ";
    private int calculatePercentage;
    // Start is called before the first frame update
    private void Start() {
        showPlayerLivePoints = GetComponent<Text>();
        calculatePercentage = player.playerLifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        showPlayerLivePoints.text = SUFIX + player.playerLifePoints;
        if(player.playerLifePoints <= calculatePercentage * 0.5
            && player.playerLifePoints > calculatePercentage * 0.25)
            showPlayerLivePoints.color = Color.yellow;

        if(player.playerLifePoints <= calculatePercentage * 0.25)
            showPlayerLivePoints.color = Color.red;
        
        if (player.playerLifePoints <= 0) {
            showPlayerLivePoints.text = "YOUR DEAD :(";
        }
    }
}
