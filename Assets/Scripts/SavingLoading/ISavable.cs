using UnityEngine;

namespace SavingLoading
{
    public interface ISavable
    {
        object CaptureState();

        void RestoreData(object state);
    }
}