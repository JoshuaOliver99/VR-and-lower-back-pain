using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exerciser : MonoBehaviour
{
    [Header("References")]
    [SerializeField] raaTrackers raaTracker;
    
    [Header("Settings")]
    [SerializeField] int numRepetitions = 10;
    [SerializeField] int manipulatedRep = 6;
    [SerializeField] bool manipulating;

    [Header("Data")]
    [SerializeField] int exercise = 1; // Movement direction (forward, lateral)
    [SerializeField] int repetition = 1;
    [SerializeField] int stage = 1; // Stage of repition

    [SerializeField] Vector3 headPos;
    [SerializeField] Vector3 AlteredheadPos;



    
    void Start()
    {
        headPos = raaTracker.transformHead.position;
        AlteredheadPos = raaTracker.transformHead.position;
    }

    void Update()
    {
        if (manipulating)
            manipulateData();

        if (Input.GetKeyDown(KeyCode.T))
            increaseStage();
    }

    void increaseStage()
    {
        stage++; // Increase stage

        // If (max stage)...
        if (stage > 3) 
        {
            stage = 1; // Reset stage
            repetition++; // Increase repetition

            // If (max repetition)...
            if (repetition > numRepetitions) 
            {
                repetition = 1; // Reset repetiton
                exercise++; // Increase exercise
            }
        }


        // If (in manipulated range)...
        if (repetition >= manipulatedRep)
            manipulating = true;
        else
            manipulating = false;
    }

    void manipulateData()
    {
        // Manipulate Transform data here...


        // NOTE: Testing
        AlteredheadPos *= 10;
    }

}