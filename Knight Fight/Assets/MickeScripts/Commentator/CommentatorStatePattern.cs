using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentatorStatePattern : MonoBehaviour
{
    // **** STATE DECLARATIONS **** //
    private CommentatorAbstractClass currentState;

    [HideInInspector] public CommentatorInactiveState inactiveState;
    [HideInInspector] public CommentatorIntroducingState introducingState;
    [HideInInspector] public CommentatorSilentState silentState;
    [HideInInspector] public CommentatorSpeakingState speakingState;

    // **** COMMENTATOR GENERAL VARIABLES **** //
    [HideInInspector] public float hiddenCooldownTimer = 0.0f;
    [HideInInspector] public bool allowedToSpeak = false;

    // **** COMMENTATOR COOLDOWN VARIABLES **** //
    [Header("Speaking Frequency")]

    [HideInInspector] public bool boredComment = false;
    [HideInInspector] public bool deathComment = false;
    [HideInInspector] public bool victoryComment = false;

    [Header("Guaranteed Silence Duration Between Comments")]
    public float hardSilenceTimer = 5.0f;

    [Header("Soft Silence Duration Between Comments")]
    public float silencePostIntro = 10.0f;
    public float speakingCooldown = 5.0f;


    void Awake()
    {
        inactiveState = new CommentatorInactiveState(this);
        introducingState = new CommentatorIntroducingState(this);
        silentState = new CommentatorSilentState(this);
        speakingState = new CommentatorSpeakingState(this);
    }

    void Start()
    {
        currentState = inactiveState;
    }

    void LateUpdate()
    {
        currentState.Execute();
    }

    public void ChangeState(CommentatorAbstractClass newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter();
    }
}