using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    [SerializeField] private ShipMovement ship;
    public event EventHandler OnPlayerCorrectCheckpoint;
    public event EventHandler OnPlayerWrongCheckpoint;

    private List<CheckpointSingle> checkpointSingles;
    private int nextCheckpointSingleIndex;

    private void Awake()
    {
        Transform checkpointsTransform = transform.Find("Checkpoints");

        checkpointSingles = new List<CheckpointSingle>();
        foreach (Transform checkpointSingleTransform in checkpointsTransform)
        {
            CheckpointSingle checkpointSingle = checkpointSingleTransform.GetComponent<CheckpointSingle>();

            checkpointSingle.SetTrackCheckpoints(this);

            checkpointSingles.Add(checkpointSingle);
        }

        nextCheckpointSingleIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpointSingle)
    {
        if (checkpointSingles.IndexOf(checkpointSingle) == nextCheckpointSingleIndex)
        {
            Debug.Log("correct");
            nextCheckpointSingleIndex = (nextCheckpointSingleIndex + 1) % checkpointSingles.Count;
            OnPlayerCorrectCheckpoint?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSingle = checkpointSingles[nextCheckpointSingleIndex];
            correctCheckpointSingle.Hide();
            ship.SetFuel(1.0f);
        }
        else
        {
            Debug.Log("Incorrectt");
            OnPlayerWrongCheckpoint?.Invoke(this, EventArgs.Empty);

            CheckpointSingle correctCheckpointSingle = checkpointSingles[nextCheckpointSingleIndex];
            correctCheckpointSingle.Show();
        }
    }
}
