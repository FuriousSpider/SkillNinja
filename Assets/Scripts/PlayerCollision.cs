using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public GameObject levelManager;
    public GameObject menu;
    public Animator animator;
    public AudioClip[] audioClips;

    AudioSource audioSource;

    bool isPlayerDead;

    void Start() {
        audioSource = gameObject.AddComponent<AudioSource>();
        isPlayerDead = false;
    }

    void OnTriggerEnter2D(Collider2D col) {
        string tag = col.gameObject.tag;

        if (tag == Values.TAG_LASER) {
            StopGame();
        } else if (tag == Values.TAG_EXPLOSION) {
            StopGame();
        } else if (tag == Values.TAG_SOLDIER && col.gameObject.GetComponent<SoldierMovement>().GetState() == SoldierMovement.State.ACTIVE) {
            StopGame();
        } else if (tag == Values.TAG_SPIKES && col.gameObject.GetComponent<SpikesHandler>().GetState() == SpikesHandler.State.ACTIVE) {
            StopGame();
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        string tag = col.gameObject.tag;

        if (tag == Values.TAG_SPIKES && col.gameObject.GetComponent<SpikesHandler>().GetState() == SpikesHandler.State.ACTIVE) {
            StopGame();
        } else if (tag == Values.TAG_EXPLOSION) {
            StopGame();
        }
    }

    void OnTriggerExit2D(Collider2D col) {
        string tag = col.gameObject.tag;
        
        if (tag == Values.TAG_SPIKES && col.gameObject.GetComponent<SpikesHandler>().GetState() == SpikesHandler.State.ACTIVE) {
            StopGame();
        } else if (tag == Values.TAG_EXPLOSION) {
            StopGame();
        }
    }

    private void StopGame() {
        if (!IsPlayerDead()) {
            isPlayerDead = true;
            if (!audioSource.isPlaying) {
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length - 1)], 0.5f);
            }
            MenuHandler menuHandler = menu.GetComponent<MenuHandler>();
            menuHandler.Show();
            LevelManager levelManagerScript = levelManager.GetComponent<LevelManager>();
            levelManagerScript.StopGame();
            animator.SetBool("isDead", true);
        }
    }

    private bool IsPlayerDead() {
        return isPlayerDead;
    }

    public void ResetPlayer() {
        animator.SetBool("isDead", false);
        isPlayerDead = false;
    }
}
