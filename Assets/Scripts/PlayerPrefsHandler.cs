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

    public void SetBestScore(int score) {
        if (!PlayerPrefs.HasKey(PREF_SCORE) || PlayerPrefs.GetInt(PREF_SCORE) < score) {
            PlayerPrefs.SetInt(PREF_SCORE, score);
        }
    }

    public static void SetMusic(int isMusicPlaying) {
        PlayerPrefs.SetInt(PREF_MUSIC, isMusicPlaying);
    }

    public static bool IsMusicPlaying() {
        return !PlayerPrefs.HasKey(PREF_MUSIC) || PlayerPrefs.GetInt(PREF_MUSIC) == PREF_MUSIC_ON;
    }

    public const string PREF_LANGUAGE = "Language";
    public const int PREF_LANGUAGE_ENGLISH = 0;
    public const int PREF_LANGUAGE_POLISH = 1;

    public const string PREF_SCORE = "Score";

    public const string PREF_MUSIC = "Music";
    public const int PREF_MUSIC_ON = 0;
    public const int PREF_MUSIC_OFF = 1;
}
