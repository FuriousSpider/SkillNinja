using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsHandler : MonoBehaviour
{
    public void SetLanguageToEnglish() {
        PlayerPrefs.SetInt(PREF_LANGUAGE, PREF_LANGUAGE_ENGLISH);
        PlayerPrefs.Save();
    }

    public void SetLanguageToPolish() {
        PlayerPrefs.SetInt(PREF_LANGUAGE, PREF_LANGUAGE_POLISH);
        PlayerPrefs.Save();
    }

    public static bool IsLanguageEnglish() {
        return !PlayerPrefs.HasKey(PREF_LANGUAGE) || PlayerPrefs.GetInt(PREF_LANGUAGE) == PREF_LANGUAGE_ENGLISH;
    }

    public static void SetBestScore(int score) {
        if (!PlayerPrefs.HasKey(PREF_SCORE) || PlayerPrefs.GetInt(PREF_SCORE) < score) {
            PlayerPrefs.SetInt(PREF_SCORE, score);
        }
    }

    public static int GetBestScore() {
        if (!PlayerPrefs.HasKey(PREF_SCORE)) {
            return 0;
        } else {
            return PlayerPrefs.GetInt(PREF_SCORE);
        }
    }

    public static void SetMusic(float musicVolume) {
        PlayerPrefs.SetFloat(PREF_MUSIC, musicVolume);
    }

    public static float GetMusicVolume() {
        if (!PlayerPrefs.HasKey(PREF_MUSIC)) {
            return Values.MUSIC_MAX_VOLUME;
        } else {
            return PlayerPrefs.GetFloat(PREF_MUSIC);
        }
    }

    public static void SetSounds(float soundsVolume) {
        PlayerPrefs.SetFloat(PREF_SOUNDS, soundsVolume);
    }

    public static float GetSoundsVolume() {
        if (!PlayerPrefs.HasKey(PREF_SOUNDS)) {
            return Values.SOUNDS_MAX_VOLUME;
        } else {
            return PlayerPrefs.GetFloat(PREF_SOUNDS);
        }
    }

    public const string PREF_LANGUAGE = "Language";
    public const int PREF_LANGUAGE_ENGLISH = 0;
    public const int PREF_LANGUAGE_POLISH = 1;

    public const string PREF_SCORE = "Score";

    public const string PREF_MUSIC = "Music";
    public const string PREF_SOUNDS = "Sounds";
}
