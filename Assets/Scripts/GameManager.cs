using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public static GameManager inst;
    private AudioSource thisAudio;
    [SerializeField] int phase = 1;
    [SerializeField] bool roomCleaned;
    [SerializeField] TextMeshPro roomCleanedTask;
    [SerializeField] int foodEaten;
    [SerializeField] bool mealTaken;
    [SerializeField] TextMeshPro mealTakenTask;
    [SerializeField] bool workDone;
    [SerializeField] TextMeshPro workDoneTask;
    [SerializeField] bool showerTaken;
    [SerializeField] TextMeshPro showerTakenTask;
    [SerializeField] GameObject[] phasesObjList;
    [SerializeField] TextMeshPro calendarDay;

    [SerializeField] Transform xrOrigin;
    [SerializeField] Transform initPos;
    [SerializeField] TextMeshPro sleepPrompt;

    void Awake() {
        // Will only load scene when restart game. And will destroy on load
        GameManager.inst = this;
        thisAudio = GetComponent<AudioSource>();
        phasesObjList[0].SetActive(true);
        phasesObjList[1].SetActive(false);
        phasesObjList[2].SetActive(false);
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.A)) {
        //     ResetTask(roomCleanedTask);
        //     LoadNextPhase();
        // }
    }

    public void OnRoomCleaned() {
        roomCleaned = true;
        MarkTaskAsDone(roomCleanedTask);
        // On fulfilled, reflect on UI + SFX
        thisAudio.Play();
    }

    public void OnFoodEaten() {
        foodEaten += 1;
        mealTaken = foodEaten == 2;

        if (mealTaken) {
            MarkTaskAsDone(mealTakenTask);
            // UI + SFX feedback
            thisAudio.Play();
        }
    }

    public void OnWorkDone() {
        workDone = true;
        MarkTaskAsDone(workDoneTask);
        // On fulfilled, reflect on UI + SFX
        thisAudio.Play();
    }
    
    public void OnShowerTaken() {
        showerTaken = true;
        MarkTaskAsDone(showerTakenTask);
        // On fulfilled, reflect on UI + SFX
        thisAudio.Play();
    }

    public bool CanSleep() {
        return roomCleaned && mealTaken && workDone && showerTaken;
    }

    public void LoadNextPhase() {
        if (phase == 3) {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
            return;
        }

        phase++;
        SetCalendarDay(phase);
        for (int i = 0; i < phasesObjList.Length; i++) {
            phasesObjList[i].SetActive(phase == i + 1);
        }
        // Screen Fade Animation
        foodEaten = 0;
        roomCleaned = mealTaken = workDone = showerTaken = false;
        ResetTask(roomCleanedTask);
        ResetTask(mealTakenTask);
        ResetTask(workDoneTask);
        ResetTask(showerTakenTask);
        sleepPrompt.text = "";

        xrOrigin.position = initPos.position;
        xrOrigin.rotation = initPos.rotation;
    }

    public void SetCalendarDay(int phase) {
        switch (phase) {
            case 1:
                calendarDay.text = "1";
                break;
            case 2:
                calendarDay.text = "32";
                break;
            case 3:
                calendarDay.text = "187";
                break;
            default:
                break;
        }
    }

    public void MarkTaskAsDone(TextMeshPro task) {
        task.color = new Color32(16, 115, 0, 255);
        task.fontStyle = FontStyles.Strikethrough;
        if (this.CanSleep()) {
            // UI Prompt to Sleep
            sleepPrompt.text = "It's time to go to sleep.";
        }
    }

    public void ResetTask(TextMeshPro task) {
        task.color = Color.black;
        task.fontStyle = FontStyles.Bold;
    }
}
