using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public RawImage compassImage;
    public Transform player;
    [SerializeField] GameObject iconPrefab;
    List<QuestMarker> questMarkers= new List<QuestMarker>();
    float compassUnit;
    public float maxDistance = 200f;
    public QuestMarker one;
    public QuestMarker two;

    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;
        AddQuestMarker(one);
        AddQuestMarker(two);
    }
    void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f); 

        foreach(QuestMarker marker in questMarkers)
        {
            marker.image.rectTransform.anchoredPosition = GetPosOnCompass(marker);
          
            float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
            float scale = 0f;
            if(dst< maxDistance)
            {
                scale = 1f - (dst / maxDistance);
                marker.image.rectTransform.localScale = Vector3.one * scale;
            }
        }


    }

    public void AddQuestMarker(QuestMarker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;
        questMarkers.Add(marker);
    }

    Vector2 GetPosOnCompass(QuestMarker marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        return new Vector2((compassUnit * angle)-100f, 0f);   //-100 add to formula to correct display - why?
    }
}
