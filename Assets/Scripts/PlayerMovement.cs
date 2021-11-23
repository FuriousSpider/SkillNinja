using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public AudioClip[] audioClip;

    AudioSource audioSource;
    Vector3 moveToPosition;
    bool facingLeft;
    Zone map;
    float margin;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        facingLeft = true;

        ResetPlayer();
    }

    void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, moveToPosition, Time.deltaTime * speed);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && LevelManager.isGameActive) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // if (mousePosition.x < map.GetMinX() + margin) {
            //     mousePosition.x = map.GetMinX() + margin;
            // } else if (mousePosition.x > map.GetMaxX() - margin) {
            //     mousePosition.x = map.GetMaxX() - margin;
            // }
            
            // if (mousePosition.y < map.GetMinY() + margin) {
            //     mousePosition.y = map.GetMinY() + margin;
            // } else if (mousePosition.y > map.GetMaxY() - margin) {
            //     mousePosition.y = map.GetMaxY() - margin;
            // }

            moveToPosition = mousePosition;
            moveToPosition.z = 0;

            Flip(moveToPosition.x - transform.position.x < 0);
        }
        
        if (!IsDestinationReached() && !audioSource.isPlaying) {
            audioSource.PlayOneShot(audioClip[Random.Range(0, audioClip.Length - 1)], 0.5f);
        }
    }

    void Flip(bool changeToFaceLeft) {
        if (facingLeft != changeToFaceLeft) {
            facingLeft = changeToFaceLeft;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    private void calculateMapCoordinates() {
        Camera camera = Camera.main;
        Vector3 leftBottom = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 rightTop = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        map = new Zone(leftBottom.x, rightTop.x, leftBottom.y, rightTop.y);

        margin = map.GetWidth() * Values.MAP_MARGIN_PERCENTAGE / 100;
    }

    private bool IsDestinationReached() {
        return (((int) transform.position.x) == ((int) moveToPosition.x)) && (((int) transform.position.y) == ((int) moveToPosition.y));
    }

    public void ResetPlayer() {
        transform.position = new Vector3(0, 0, 0);
        moveToPosition = transform.position;
        
        calculateMapCoordinates();
    }
}