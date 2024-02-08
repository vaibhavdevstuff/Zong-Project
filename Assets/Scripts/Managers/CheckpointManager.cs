using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Transform CurrentCheckpont;
    public Transform PreviousCheckpont;

    [Space]
    public List<Transform> olderCheckpoints = new List<Transform>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddNewCheckPoint(Transform newCheckpoint)
    {
        if (olderCheckpoints.Count > 0 && olderCheckpoints.Contains(newCheckpoint)) return;
        if (CurrentCheckpont == newCheckpoint || PreviousCheckpont == newCheckpoint) return;

        if(PreviousCheckpont != null)
        {
            olderCheckpoints.Add(PreviousCheckpont);
        }

        if(CurrentCheckpont != null )
        {
            PreviousCheckpont = CurrentCheckpont;
        }

        CurrentCheckpont = newCheckpoint;
    }

    public void GotoPreviousCheckpoint(GameObject gotoObject)
    {
        if (!gotoObject) return;
        if (!CurrentCheckpont && !PreviousCheckpont) return;

        Transform gotoCheckpoint = CurrentCheckpont;

        if (PreviousCheckpont)
        {
            CurrentCheckpont = PreviousCheckpont;
            PreviousCheckpont = null;
            gotoCheckpoint = CurrentCheckpont;
        }

        gotoObject.SetActive(false);
        gotoObject.transform.position = gotoCheckpoint.position;
        gotoObject.SetActive(true);

    }







}
