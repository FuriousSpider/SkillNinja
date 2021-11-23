using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject soldier;
    public GameObject dagger;
    public GameObject laserBase;
    public GameObject spikes;
    public GameObject bomb;

    Dictionary<Zone, long> spawnZones;

    Zone map;
    float margin;
    long startTime;
    int gameNumber;
    public static bool isGameActive;

    TimeManager timeManager;
    //TODO: REMOVE ADS MANAGER -> now we have singleton
    private AdsManager.OnAdFinished onAdFinished;

    void Start() {
        spawnZones = new Dictionary<Zone, long>();
        timeManager = new TimeManager(Values.ENEMY_SPAWN_INTERVAL_START, Values.ENEMY_SPAWN_INTERVAL_END);

        isGameActive = false;
        MenuHandler.INSTANCE.Enable();
        gameNumber = 0;
        onAdFinished = new AdsManager.OnAdFinished(this.OnAdFinished);
        AdsManager.INSTANCE.SetOnAdFinishedListener(onAdFinished);
    }

    void Update() {
        if (isGameActive) {
            if (timeManager.HasIntervalPassed()) {
                spawnEnemy();
                timeManager.DecreaseIntervalBy(Values.ENEMY_SPAWN_INTERVAL_STEP);
            }

            CalculateScore();
        }
    }

    public void StartGame() {
        calculateMapCoordinates();
        generateSpawnZones();

        initSpawnTimer();
        initScore();
        removeInstantiatedEnemies();
        resetPlayer();
        isGameActive = true;
    }

    public void StopGame() {
        isGameActive = false;
        gameNumber++;

        if (gameNumber % 7 - 3 == 0) {
            MenuHandler.INSTANCE.Disable();
            AdsManager.INSTANCE.ShowInterstitialAd();
        }
    }

    private void initSpawnTimer() {
        timeManager.Start();
    }

    private void initScore() {
        startTime = timeManager.Now();
    }

    private void removeInstantiatedEnemies() {
        GameObject[] soldiers = GameObject.FindGameObjectsWithTag(Values.TAG_SOLDIER);
        foreach(GameObject enemy in soldiers) {
            Destroy(enemy);
        }

        GameObject[] daggers = GameObject.FindGameObjectsWithTag(Values.TAG_DAGGER);
        foreach(GameObject enemy in daggers) {
            Destroy(enemy);
        }

        GameObject[] laserBases = GameObject.FindGameObjectsWithTag(Values.TAG_LASER_BASE);
        foreach(GameObject enemy in laserBases) {
            Destroy(enemy);
        }

        GameObject[] lasers = GameObject.FindGameObjectsWithTag(Values.TAG_LASER);
        foreach(GameObject enemy in lasers) {
            Destroy(enemy);
        }

        GameObject[] spikes = GameObject.FindGameObjectsWithTag(Values.TAG_SPIKES);
        foreach(GameObject enemy in spikes) {
            Destroy(enemy);
        }

        GameObject[] bombs = GameObject.FindGameObjectsWithTag(Values.TAG_BOMB);
        foreach(GameObject enemy in bombs) {
            Destroy(enemy);
        }
    }

    private void resetPlayer() {
        player.GetComponent<PlayerCollision>().ResetPlayer();
    }

    private void calculateMapCoordinates() {
        Camera camera = Camera.main;
        Vector3 leftBottom = camera.ViewportToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));
        Vector3 rightTop = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));

        map = new Zone(leftBottom.x, rightTop.x, leftBottom.y, rightTop.y);

        margin = map.GetWidth() * Values.MAP_MARGIN_PERCENTAGE / 100;
    }

    private void generateSpawnZones() {
        spawnZones.Add(new Zone(map.GetMinX() + margin, map.GetMaxX() - margin, map.GetYByFraction(3f/4f), map.GetMaxY() - margin), Utils.GetCurrentTime());
        spawnZones.Add(new Zone(map.GetMinX() + margin, map.GetHorizontalCenter(), map.GetYByFraction(1f/4f), map.GetYByFraction(3f/4f)), Utils.GetCurrentTime());
        spawnZones.Add(new Zone(map.GetHorizontalCenter(), map.GetMaxX() - margin, map.GetYByFraction(1f/4f), map.GetYByFraction(3f/4f)), Utils.GetCurrentTime());
        spawnZones.Add(new Zone(map.GetMinX() + margin, map.GetMaxX() - margin, map.GetMinY() + margin, map.GetYByFraction(1f/4f)), Utils.GetCurrentTime());
    }

    private void spawnEnemy() {
        List<string> notSpawnedEnemyTypes = new List<string>();

        if (GameObject.FindGameObjectsWithTag(Values.TAG_SOLDIER).Length == 0) {
            notSpawnedEnemyTypes.Add(Values.TAG_SOLDIER);
        }
        if (GameObject.FindGameObjectsWithTag(Values.TAG_LASER_BASE).Length == 0) {
            notSpawnedEnemyTypes.Add(Values.TAG_LASER_BASE);
        }
        if (GameObject.FindGameObjectsWithTag(Values.TAG_SPIKES).Length == 0) {
            notSpawnedEnemyTypes.Add(Values.TAG_SPIKES);
        }
        if (GameObject.FindGameObjectsWithTag(Values.TAG_BOMB).Length == 0) {
            notSpawnedEnemyTypes.Add(Values.TAG_BOMB);
        }

        if (!notSpawnedEnemyTypes.Any()) {
            return;
        } else {
            notSpawnedEnemyTypes.Shuffle();
        }

        List<Zone> availableZones = GetAvailableZones();

        if (!availableZones.Any()) {
            return;
        }

        int index = Random.Range(0, notSpawnedEnemyTypes.Count - 1);
        int zoneIndex = Random.Range(0, availableZones.Count - 1);

        switch (notSpawnedEnemyTypes[index]) {
            case Values.TAG_SOLDIER:
                List<Zone> daggerZones = new List<Zone>(spawnZones.Keys.ToList());
                availableZones.Shuffle();

                GameObject enemyInstance = Instantiate(soldier, RandomManager.GetRandomPositionForZone(availableZones[0]), Quaternion.identity);
                daggerZones.Remove(availableZones[0]);

                for (int i = 0; i < spawnZones.Count - 1; i++) {
                    GameObject daggerInstance = Instantiate(dagger, RandomManager.GetRandomPositionForZone(daggerZones[i]), Quaternion.identity);

                    daggerInstance.GetComponent<DaggerHandler>().SetTarget(enemyInstance);
                }

                spawnZones[availableZones[0]] = Utils.GetFutureTime(Values.ENEMY_SOLDIER_IDLE_TIME);

                break;
            case Values.TAG_LASER_BASE:
                Instantiate(laserBase, RandomManager.GetRandomPositionForZone(availableZones[zoneIndex]), Quaternion.identity);
                spawnZones[availableZones[zoneIndex]] = Utils.GetFutureTime(Values.ENEMY_LASER_IDLE_TIME + Values.ENEMY_LASER_ACTIVE_TIME);
                break;
            case Values.TAG_SPIKES:
                GameObject objSpikes = Instantiate(spikes, availableZones[zoneIndex].GetCenter(), Quaternion.identity);
                objSpikes.GetComponent<SpriteRenderer>().size = availableZones[zoneIndex].GetSize();
                spawnZones[availableZones[zoneIndex]] = Utils.GetFutureTime(Values.ENEMY_SPIKES_IDLE_TIME + Values.ENEMY_SPIKES_ACTIVE_TIME);
                break;
            case Values.TAG_BOMB:
                Instantiate(bomb, RandomManager.GetRandomPositionForZone(availableZones[zoneIndex]), Quaternion.identity);
                spawnZones[availableZones[zoneIndex]] = Utils.GetFutureTime(Values.ENEMY_BOMB_ACTIVE_TIME + Values.ENEMY_BOMB_EXPLOSION_ACTIVE_TIME);
                break;
        }
    }

    private List<Zone> GetAvailableZones() {
        List<Zone> list = new List<Zone>();

        foreach (KeyValuePair<Zone, long> element in spawnZones) {
            if (Utils.IsAfter(element.Value)) {
                list.Add(element.Key);
            }
        }

        return list;
    }

    private void CalculateScore() {
        ScoreHandler.score = (timeManager.Now() - startTime) / 1000;
    }

    private void OnAdFinished() {
        MenuHandler.INSTANCE.Enable();
    }
}
