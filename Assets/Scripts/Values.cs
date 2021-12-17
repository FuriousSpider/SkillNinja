using UnityEngine;

public static class Values
{
    public const string TAG_PLAYER = "Player";
    public const string TAG_SOLDIER = "Soldier";
    public const string TAG_DAGGER = "Dagger";
    public const string TAG_LASER_BASE = "LaserBase";
    public const string TAG_LASER = "Laser";
    public const string TAG_SPIKES = "Spikes";
    public const string TAG_BOMB = "Bomb";
    public const string TAG_EXPLOSION = "BombExplosion";
    public const string TAG_MENU = "Menu";
    public const string TAG_ADS = "Ads";

    public const float MAP_MARGIN_PERCENTAGE = 10.0f;
    public const float MAP_TOPBAR_OFFSET_PERCENTAGE = 15.0f;

    public const int MANAGER_SCREEN_MAIN_MENU = 0;
    public const int MANAGER_SCREEN_GAME = 1;
    public const int MANAGER_SCREEN_HELP = 2;
    public const int MANAGER_SCREEN_LANGUAGE = 3;

    public const int ENEMY_SOLDIER_NUMBER_OF_LIVES = 3;
    public const long ENEMY_SOLDIER_IDLE_TIME = 2000;

    public const long ENEMY_LASER_IDLE_TIME = 2000;
    public const long ENEMY_LASER_ACTIVE_TIME = 1000;
    public const int ENEMY_LASER_NUMBER_OF_BEAMS = 4;

    public const float ENEMY_LASER_BASE_TOP_OFFSET = 0.1f;
    public const float ENEMY_LASER_BASE_BOTTOM_OFFSET = 0.5f;
    public const float ENEMY_LASER_BASE_LEFT_OFFSET = 0.2f;
    public const float ENEMY_LASER_BASE_RIGHT_OFFSET = 0.2f;
    public const float ENEMY_LASER_BASE_LEFT_RIGHT_VERTICAL_OFFSET = 0.3f;

    public const long ENEMY_SPIKES_IDLE_TIME = 2000;
    public const long ENEMY_SPIKES_ACTIVE_TIME = 1000; 

    public const long ENEMY_BOMB_ACTIVE_TIME = 3000;
    public const long ENEMY_BOMB_EXPLOSION_ACTIVE_TIME = 200;

    public const int ENEMY_SPAWN_INTERVAL_START = 2000;
    public const int ENEMY_SPAWN_INTERVAL_END = 1000;
    public const int ENEMY_SPAWN_INTERVAL_STEP = 200;

    public const long TIME_NULL = 0;
}
