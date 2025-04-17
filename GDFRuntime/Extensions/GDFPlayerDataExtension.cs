using System;
using System.Reflection;
using GDFFoundation;

namespace GDFRuntime
{
    static public class GDFPlayerDataExtension
    {
        static readonly FieldInfo _reference;
        static readonly FieldInfo _account;
        static readonly FieldInfo _gameSave;
        static readonly FieldInfo _syncTime;
        static readonly FieldInfo _syncCommit;
        static readonly FieldInfo _dataVersion;
        static readonly FieldInfo _creation;
        static readonly FieldInfo _modification;

        static GDFPlayerDataExtension()
        {
            Type type = typeof(GDFPlayerData);

            _reference = type.GetField("_reference", BindingFlags.Instance | BindingFlags.NonPublic);
            _account = type.GetField("_account", BindingFlags.Instance | BindingFlags.NonPublic);
            _gameSave = type.GetField("_gameSave", BindingFlags.Instance | BindingFlags.NonPublic);
            _syncTime = type.GetField("_syncTime", BindingFlags.Instance | BindingFlags.NonPublic);
            _syncCommit = type.GetField("_syncCommit", BindingFlags.Instance | BindingFlags.NonPublic);
            _dataVersion = type.GetField("_dataVersion", BindingFlags.Instance | BindingFlags.NonPublic);
            _creation = type.GetField("_creation", BindingFlags.Instance | BindingFlags.NonPublic);
            _modification = type.GetField("_modification", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        static public void ProtectedFill(this GDFPlayerData self, GDFPlayerDataStorage storage)
        {
            _reference.SetValue(self, storage.Reference);
            _account.SetValue(self, storage.Account);
            _gameSave.SetValue(self, storage.GameSave);
            _syncTime.SetValue(self, storage.SyncDateTime);
            _syncCommit.SetValue(self, storage.SyncCommit);
            _dataVersion.SetValue(self, storage.DataVersion);
            _creation.SetValue(self, storage.Creation);
            _modification.SetValue(self, storage.Modification);
        }
    }
}
