using System;
using System.Collections;
using System.Collections.Generic;
using GDFFoundation;
using GDFFoundation.Tasks;
using GDFUnity;
using NUnit.Framework;
using UnityEngine.TestTools;
using GDFUnity.Tests;
using System.Text.RegularExpressions;
using GDFRuntime;

public class PlayerDataTests
{
    [Test]
    public void CannotAddNull()
    {
        Assert.Throws<ArgumentNullException> (() => GDF.Player.Add(null));
    }

    [Test]
    public void CannotAddDeleteed()
    {
        GDFPlayerData data = new GDFTestPlayerData();
        
        data.Trashed = true;

        Assert.Throws<GDFException> (() => GDF.Player.Add(data));
    }

    [Test]
    public void CanAutoGenerateReferences()
    {
        GDFPlayerData data = new GDFTestPlayerData();
        GDF.Player.Add(data);

        Assert.NotNull(data.Reference);
        Assert.IsTrue(new Regex("^([A-F]|[0-9]){32}-([A-F]|[0-9]){8}-([A-F]|[0-9]){8}$").IsMatch(data.Reference));
    }

    [Test]
    public void CanAdd()
    {
        string reference = nameof(CanAdd);
        
        GDFPlayerData data = new GDFTestPlayerData();

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
    }

    [Test]
    public void AutoFillsDataOnAdd()
    {
        string reference = nameof(AutoFillsDataOnAdd);
        
        GDFPlayerData data = new GDFTestPlayerData();

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.Reference, reference);
        Assert.AreEqual(data.GameSave, GDF.Player.GameSave);
        Assert.AreEqual(data.Account, GDF.Authentication.Token.Account);
    }

    [Test]
    public void CannotAddSameObjectTwice()
    {
        GDFPlayerData data = new GDFTestPlayerData();

        GDF.Player.Add(nameof(CannotAddSameObjectTwice), data);

        Assert.Throws<GDFException> (() => GDF.Player.Add(data));
    }

    [Test]
    public void CannotAddAlreadyUsedReference()
    {
        string reference = nameof(CannotAddAlreadyUsedReference);

        GDFPlayerData data1 = new GDFTestPlayerData();
        GDFPlayerData data2 = new GDFTestPlayerData();

        GDF.Player.Add(reference, data1);
        
        Assert.Throws<GDFException> (() => GDF.Player.Add(reference, data2));
    }

    [Test]
    public void CanGetDataByReference()
    {
        string reference = nameof(CanGetDataByReference);
        
        GDFPlayerData data = new GDFTestPlayerData();
        
        GDF.Player.Add(reference, data);

        data = GDF.Player.Get(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.Reference, reference);
    }

    [Test]
    public void CanGetDataByType()
    {
        string reference = nameof(CanGetDataByType);
        
        GDFPlayerData data1 = new GDFTestPlayerData();
        GDF.Player.Add(reference + "_1", data1);
        
        GDFPlayerData data2 = new GDFTestPlayerData();
        GDF.Player.Add(reference + "_2", data2);

        List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
        
        Assert.IsNotNull(list);
        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(list[0].Reference, data1.Reference);
        Assert.AreEqual(list[1].Reference, data2.Reference);
    }

    [Test]
    public void CanGetDataByReferenceUsingParentType()
    {
        string reference = nameof(CanGetDataByReferenceUsingParentType);
        
        GDFTestChildPlayerData data = new GDFTestChildPlayerData();
        data.ChildInt = 12;
        
        GDF.Player.Add(reference, data);

        GDFTestChildPlayerData fromParent = GDF.Player.Get<GDFTestPlayerData>(reference) as GDFTestChildPlayerData;
        
        Assert.IsNotNull(fromParent);
        Assert.AreEqual(fromParent.Reference, reference);
        Assert.AreEqual(fromParent.ChildInt, data.ChildInt);
    }
    
    [Test]
    public void CanGetDataByTypeUsingParentType()
    {
        GDFTestChildPlayerData data = new GDFTestChildPlayerData();
        data.ChildInt = 1;
        GDF.Player.Add(data);

        data = new GDFTestChildPlayerData();
        data.ChildInt = 2;
        GDF.Player.Add(data);

        List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
        
        Assert.IsNotNull(list == null);
        Assert.AreEqual(list.Count, 2);
        
        foreach (GDFTestPlayerData item in list)
        {
            GDFTestChildPlayerData fromParent = item as GDFTestChildPlayerData;
        
            Assert.IsNotNull(fromParent);
            Assert.AreNotEqual(fromParent.ChildInt, 0);
        }
    }

    [Test]
    public void CannotGetUnexistingData()
    {
        Assert.IsNull(GDF.Player.Get(nameof(CannotGetUnexistingData)));
    }

    [Test]
    public void CannotGetNonGDFType()
    {
        Assert.Throws<GDFException>(() => GDF.Player.Get(typeof(string)));
    }

    [Test]
    public void CannotSetNull()
    {
        Assert.Throws<ArgumentNullException> (() => GDF.Player.AddToSaveQueue(null));
    }

    [Test]
    public void CanSet()
    {
        string reference = nameof(CanSet);
        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();

        data.TestString = value1;

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.Reference, reference);
        Assert.AreEqual(data.TestString, value1);

        data.TestString = value2;

        GDF.Player.AddToSaveQueue(data);
        Assert.AreEqual(data.Reference, reference);
        Assert.AreEqual(data.TestString, value2);
    }
    
    [Test]
    public void CanSetFromParentClass()
    {
        string reference = nameof(CanSetFromParentClass);
        string value = "Test value";
        
        GDFTestChildPlayerData data = new GDFTestChildPlayerData();
        data.ChildInt = 12;

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));

        GDFTestPlayerData parent = GDF.Player.Get<GDFTestPlayerData>(reference);
        Assert.IsNotNull(parent);
        Assert.AreEqual(parent.Reference, reference);

        parent.TestString = value;

        GDF.Player.AddToSaveQueue(parent);

        data = GDF.Player.Get<GDFTestChildPlayerData>(reference);

        Assert.AreEqual(data.Reference, reference);
        Assert.AreEqual(data.TestString, value);
        Assert.AreEqual(data.ChildInt, 12);
    }
    
    [Test]
    public void CanDelete()
    {
        string reference = nameof(CanDelete);
        string value = "value 1";
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;
        Assert.IsNull(GDF.Player.Get(reference));
        GDF.Player.Add(reference, data);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value);
        
        GDF.Player.Delete(data);

        Assert.IsNull(GDF.Player.Get(reference));
    }
    
    [Test]
    public void CanSetToDeleteed()
    {
        string reference = nameof(CanSetToDeleteed);
        string value = "value 1";
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;
        Assert.IsNull(GDF.Player.Get(reference));
        GDF.Player.Add(reference, data);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value);
        
        data.Trashed = true;

        GDF.Player.AddToSaveQueue(data);

        Assert.IsNull(GDF.Player.Get(reference));
    }
    
    [UnityTest]
    public IEnumerator CangetDataState()
    {
        string reference = nameof(CangetDataState);
        string value = "value 1";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;

        DataStateInfo state = GDF.Player.GetState(data);

        Assert.AreEqual(DataState.Unattached, state.state);

        GDF.Player.Add(reference, data);
        
        state = GDF.Player.GetState(data);

        Assert.AreEqual(true, state.state.HasFlag(DataState.Attached));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Savable));
        Assert.AreEqual(false, state.state.HasFlag(DataState.Syncable));

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        state = GDF.Player.GetState(data);
        
        Assert.AreEqual(true, state.state.HasFlag(DataState.Attached));
        Assert.AreEqual(false, state.state.HasFlag(DataState.Savable));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Syncable));

        GDF.Player.AddToSaveQueue(data);
        
        state = GDF.Player.GetState(data);
        
        Assert.AreEqual(true, state.state.HasFlag(DataState.Attached));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Savable));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Syncable));

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        state = GDF.Player.GetState(data);
        
        Assert.AreEqual(true, state.state.HasFlag(DataState.Attached));
        Assert.AreEqual(false, state.state.HasFlag(DataState.Savable));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Syncable));

        GDF.Player.Delete(data);
        
        state = GDF.Player.GetState(data);
        
        Assert.AreEqual(false, state.state.HasFlag(DataState.Attached));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Savable));
        Assert.AreEqual(true, state.state.HasFlag(DataState.Syncable));
    }

    [UnityTest]
    public IEnumerator CanChangeGameSave()
    {
        byte gameSave = GDF.Player.GameSave;

        UnityTask task = GDF.Player.LoadGameSave(1);
        Assert.AreEqual(gameSave, GDF.Player.GameSave);

        yield return WaitTask(task);

        Assert.AreEqual(1, GDF.Player.GameSave);
    }
    
    [UnityTest]
    public IEnumerator CanChangeBackToDefaultGameSave()
    {
        byte gameSave = GDF.Player.GameSave;

        UnityTask task = GDF.Player.LoadGameSave(1);
        Assert.AreEqual(gameSave, GDF.Player.GameSave);

        yield return WaitTask(task);

        Assert.AreEqual(1, GDF.Player.GameSave);

        task = GDF.Player.LoadCommonGameSave();
        
        yield return WaitTask(task);

        Assert.AreEqual(gameSave, GDF.Player.GameSave);
    }

    [Test]
    public void CannotUseInvalidGameSave()
    {
        Assert.Throws<GDFException> (() => GDF.Player.LoadGameSave(100));
    }

    [UnityTest]
    public IEnumerator CanOverrideDataWithGameSave()
    {
        string reference = nameof(CanOverrideDataWithGameSave);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        
        data.TestString = value1;

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;

        Assert.IsNotNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value2);

        task = GDF.Player.Save();
        yield return WaitTask(task);
        
        task = GDF.Player.LoadGameSave(0);
        yield return WaitTask(task);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);
    }

    [UnityTest]
    public IEnumerator CanOverrideDataListWithGameSave()
    {
        string value1 = "value 1";
        string value2 = "value 2";
        string value11 = "value 11";
        string value12 = "value 12";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(data);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(data);

        List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
        
        Assert.IsNotNull(list);
        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(list[0].TestString, value1);
        Assert.AreEqual(list[1].TestString, value2);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value11;
        GDF.Player.Add(data);
        
        data = new GDFTestPlayerData();
        data.TestString = value12;
        GDF.Player.Add(data);

        list = GDF.Player.Get<GDFTestPlayerData>();
        
        Assert.IsNotNull(list);
        Assert.AreEqual(list.Count, 2);
        Assert.AreEqual(list[0].TestString, value11);
        Assert.AreEqual(list[1].TestString, value12);
    }

    [UnityTest]
    public IEnumerator CannotOverrideDataFromDifferentType()
    {
        string reference = nameof(CannotOverrideDataFromDifferentType);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data1 = new GDFTestPlayerData();
        data1.TestString = value1;

        Assert.IsNull(GDF.Player.Get(reference));
        
        GDF.Player.Add(reference, data1);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data1, GDF.Player.Get(reference));
        Assert.AreEqual(data1.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        GDFTestChildPlayerData data2 = new GDFTestChildPlayerData();
        data2.TestString = value2;

        Assert.IsNotNull(GDF.Player.Get(reference));

        Assert.Throws<GDFException> (() => GDF.Player.Add(reference, data2));
    }

    [UnityTest]
    public IEnumerator CanGetFromDefaultGameSaveByReference()
    {
        string reference = nameof(CanGetFromDefaultGameSaveByReference);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        
        data.TestString = value1;

        Assert.IsNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;

        Assert.IsNotNull(GDF.Player.Get(reference));

        GDF.Player.Add(reference, data);

        GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        // Executes several times in order to make sure the cache is working correctly (or not)
        data1 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data1);
        Assert.AreEqual(data1.TestString, value1);
        
        Assert.IsNotNull(data2);
        Assert.AreEqual(data2.TestString, value2);
    }

    [UnityTest]
    public IEnumerator CanGetFromDefaultGameSaveByType()
    {
        string value1 = "value 1";
        string value2 = "value 2";
        string value11 = "value 11";
        string value12 = "value 12";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(data);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value11;
        GDF.Player.Add(data);
        
        data = new GDFTestPlayerData();
        data.TestString = value12;
        GDF.Player.Add(data);

        List<GDFTestPlayerData> data1 = GDF.Player.Get<GDFTestPlayerData>(defaultGameSave: true);
        List<GDFTestPlayerData> data2 = GDF.Player.Get<GDFTestPlayerData>();
        
        // Executes several times in order to make sure the cache is working correctly (or not)
        data1 = GDF.Player.Get<GDFTestPlayerData>(defaultGameSave: true);
        data2 = GDF.Player.Get<GDFTestPlayerData>();
        
        Assert.IsNotNull(data1);
        Assert.AreEqual(data1.Count, 2);
        Assert.AreEqual(data1[0].TestString, value1);
        Assert.AreEqual(data1[1].TestString, value2);
        
        Assert.IsNotNull(data2);
        Assert.AreEqual(data2.Count, 2);
        Assert.AreEqual(data2[0].TestString, value11);
        Assert.AreEqual(data2[1].TestString, value12);
    }

    [UnityTest]
    public IEnumerator CanSetOnDefaultGameSave()
    {
        string reference = nameof(CanSetOnDefaultGameSave);
        string value1 = "value 1";
        string value2 = "value 2";
        string value3 = "value 3";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(reference, data);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value2);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        data.TestString = value3;

        GDF.Player.AddToSaveQueue(data);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value2);

        data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value3);
    }

    [UnityTest]
    public IEnumerator CanDeleteOnGameSave()
    {
        string reference = nameof(CanDeleteOnGameSave);
        string value1 = "value 1";
        string value2 = "value 2";
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(reference, data);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value2);

        data.Trashed = true;

        GDF.Player.AddToSaveQueue(data);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        Assert.AreEqual(data.TestString, value1);
    }

    [UnityTest]
    public IEnumerator CanDeleteOnDefaultGameSave()
    {
        string reference = nameof(CanDeleteOnDefaultGameSave);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(reference, data);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value2);

        data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value1);

        data.Trashed = true;
        GDF.Player.AddToSaveQueue(data);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        Assert.IsNull(data);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        Assert.AreEqual(data.TestString, value2);
    }

    [UnityTest]
    public IEnumerator CanDeleteGameSave()
    {
        string reference1 = "1" + nameof(CanDeleteGameSave);
        string reference2 = "2" + nameof(CanDeleteGameSave);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data1 = new GDFTestPlayerData();
        data1.TestString = value1;
        GDF.Player.Add(reference1, data1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);
        
        GDFTestPlayerData data2 = new GDFTestPlayerData();
        data2.TestString = value2;
        GDF.Player.Add(reference2, data2);

        task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.DeleteGameSave();
        yield return WaitTask(task);

        Assert.IsNull(GDF.Player.Get(reference2));

        data2 = new GDFTestPlayerData();

        GDF.Player.Add(reference2, data2);

        Assert.IsNotNull(GDF.Player.Get(reference2));
    }

    [UnityTest]
    public IEnumerator KnowsIfThereAreDataToSave()
    {
        string reference = nameof(KnowsIfThereAreDataToSave);
        string value = "value 1";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;

        Assert.AreEqual(false, GDF.Player.HasDataToSave);

        GDF.Player.Add(reference, data);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSave);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);

        GDF.Player.Delete(data);

        Assert.AreEqual(true, GDF.Player.HasDataToSave);

        task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
    }

    [UnityTest]
    public IEnumerator KnowsIfThereAreDataToSync()
    {
        string reference = nameof(KnowsIfThereAreDataToSync);
        string value = "value 1";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;

        Assert.AreEqual(false, GDF.Player.HasDataToSync);

        GDF.Player.Add(reference, data);

        Assert.AreEqual(false, GDF.Player.HasDataToSync);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSync);

        GDF.Player.Delete(data);

        task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSync);
    }

    [Test]
    public void HasConsistentMemoryAddressesOnData()
    {
        string reference = nameof(KnowsIfThereAreDataToSync);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;

        GDF.Player.Add(reference, data);

        Assert.AreEqual(data, GDF.Player.Get(reference));
        
        GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
        GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.AreEqual(data1, data);
        Assert.AreEqual(data2, data);

        data.TestString = value2;
        
        Assert.AreEqual(data1.TestString, value2);
        Assert.AreEqual(data2.TestString, value2);

        GDF.Player.AddToSaveQueue(data);
        
        Assert.AreEqual(data1.TestString, value2);
        Assert.AreEqual(data2.TestString, value2);
    }

    [UnityTest]
    public IEnumerator DeleteingOverrideReplacesMemoryWithDefault()
    {
        string reference = nameof(DeleteingOverrideReplacesMemoryWithDefault);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(reference, data);

        GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data1);
        Assert.AreEqual(data1.TestString, value2);

        GDFTestPlayerData data2 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        Assert.IsNotNull(data2);
        Assert.AreEqual(data2.TestString, value1);

        Assert.AreNotEqual(data1, data2);

        GDF.Player.Delete(data1);
        
        Assert.AreEqual(data1.TestString, data2.TestString);
        Assert.AreNotEqual(data1, data2);

        data2 = GDF.Player.Get<GDFTestPlayerData>(reference, true);
        
        Assert.AreEqual(data1, data2);
        
        data2 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.AreEqual(data1, data2);
    }

    [UnityTest]
    public IEnumerator ReloadingResetsMemory()
    {
        string reference = nameof(ReloadingResetsMemory);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        data.TestString = value2;

        GDF.Player.AddToSaveQueue(data);

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        Assert.AreEqual(data.TestString, value2);

        GDFTestPlayerData data1 = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data1);
        Assert.AreEqual(data1.TestString, value1);
        
        Assert.AreNotEqual(data, data1);
    }

    [UnityTest]
    public IEnumerator CanPurgeData()
    {
        string reference = nameof(CanPurgeData);
        string value1 = "value 1";
        string value2 = "value 2";

        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);

        Assert.AreEqual(true, GDF.Player.HasDataToSave);
        Assert.AreEqual(false, GDF.Player.HasDataToSync);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);

        data.TestString = value2;
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);

        GDF.Player.AddToSaveQueue(data);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);
        
        task = GDF.Player.LoadGameSave(1);
        yield return WaitTask(task);
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);

        data = new GDFTestPlayerData();
        data.TestString = value2;
        GDF.Player.Add(reference, data);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);
        
        task = GDF.Player.Purge();
        yield return WaitTask(task);
        
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
        Assert.AreEqual(false, GDF.Player.HasDataToSync);

        Assert.IsNull(GDF.Player.Get(reference));

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        Assert.IsNull(GDF.Player.Get(reference));

        data = new GDFTestPlayerData();
        data.TestString = value2;

        GDF.Player.Add(reference, data);

        Assert.IsNotNull(GDF.Player.Get(reference));
        
        task = GDF.Player.Save();
        yield return WaitTask(task);
    }

    [UnityTest]
    public IEnumerator CanSave()
    {
        string reference = nameof(CanSave);

        string value = "value 1";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value);

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);
        
        data = GDF.Player.Get<GDFTestPlayerData>(reference);

        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value);
    }

    [UnityTest]
    public IEnumerator DeleteDeleteedDataOnSave()
    {
        string reference = nameof(DeleteDeleteedDataOnSave);

        string value = "value 1";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value);

        GDF.Player.Delete(data);

        task = GDF.Player.Save();
        yield return WaitTask(task);
        
        Assert.IsNull(GDF.Player.Get(reference));

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);
        
        Assert.IsNull(GDF.Player.Get(reference));
    }

    [UnityTest]
    public IEnumerator DataAreLostWhenDisconnected()
    {
        string reference = nameof(DataAreLostWhenDisconnected);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        data.TestString = value2;
        
        GDF.Player.AddToSaveQueue(data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value2);

        task = GDF.Authentication.SignOut();
        yield return WaitTask(task);

        yield return Connect();

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value1);
    }
    
    [UnityTest]
    public IEnumerator KeepDataToSyncEvenAfterReloading()
    {
        string reference = nameof(KeepDataToSyncEvenAfterReloading);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        data.TestString = value2;
        
        GDF.Player.AddToSaveQueue(data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value2);

        task = GDF.Authentication.SignOut();
        yield return WaitTask(task);

        yield return Connect();

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value1);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);
    }

    [UnityTest]
    public IEnumerator AutoLoadsOnAccountConnect()
    {
        string reference = nameof(AutoLoadsOnAccountConnect);

        string value = "value 1";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        task = GDF.Authentication.SignOut();
        yield return WaitTask(task);

        yield return Connect();

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value);
    }

    [UnityTest]
    public IEnumerator SwitchingGamesaveDoesNotSave()
    {
        string reference = nameof(SwitchingGamesaveDoesNotSave);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        data.TestString = value2;
        
        GDF.Player.AddToSaveQueue(data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value2);

        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNotNull(data);
        Assert.AreEqual(data.TestString, value1);
    }

    [UnityTest]
    public IEnumerator DataFromAnAccountIsNotRetrieved()
    {
        string reference = nameof(DataFromAnAccountIsNotRetrieved);

        string value1 = "value 1";
        string value2 = "value 2";
        
        GDFTestPlayerData data = new GDFTestPlayerData();
        data.TestString = value1;
        GDF.Player.Add(reference, data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value1);

        UnityTask task = GDF.Player.Save();
        yield return WaitTask(task);

        data.TestString = value2;
        
        GDF.Player.AddToSaveQueue(data);
        
        Assert.IsNotNull(GDF.Player.Get(reference));
        Assert.AreEqual(data, GDF.Player.Get(reference));
        Assert.AreEqual(data.TestString, value2);
        
        Assert.AreEqual(true, GDF.Player.HasDataToSave);
        Assert.AreEqual(true, GDF.Player.HasDataToSync);

        yield return AlternateConnect();

        data = GDF.Player.Get<GDFTestPlayerData>(reference);
        
        Assert.IsNull(data);
        Assert.AreEqual(false, GDF.Player.HasDataToSave);
        Assert.AreEqual(false, GDF.Player.HasDataToSync);
        
        yield return Connect();
    }

    [UnityTest]
    public IEnumerator CanSyncData()
    {
        int count = 39;
        
        GDFTestPlayerData data;

        for (int i = 0; i < count; i++)
        {
            data = new GDFTestPlayerData();
            data.TestInt = i;
            GDF.Player.Add(data);
        }

        UnityTask task = GDF.Player.Sync();
        yield return WaitTask(task);

        List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
        Assert.GreaterOrEqual(list.Count, count);
        
        task = GDF.Player.Purge();
        yield return WaitTask(task);
        
        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        list = GDF.Player.Get<GDFTestPlayerData>();
        Assert.AreEqual(0, list.Count);

        task = GDF.Player.Sync();
        yield return WaitTask(task);

        list = GDF.Player.Get<GDFTestPlayerData>();
        Assert.GreaterOrEqual(list.Count, count);
    }

    [UnityTest]
    public IEnumerator CanSyncDataAutoSaves()
    {
        int count = 39;

        List<GDFTestPlayerData> list = GDF.Player.Get<GDFTestPlayerData>();
        Assert.AreEqual(0, list.Count);
        
        GDFTestPlayerData data;

        for (int i = 0; i < count; i++)
        {
            data = new GDFTestPlayerData();
            data.TestInt = i;
            GDF.Player.Add(data);
        }

        UnityTask task = GDF.Player.Sync();
        yield return WaitTask(task);
        
        task = GDF.Player.LoadCommonGameSave();
        yield return WaitTask(task);

        list = GDF.Player.Get<GDFTestPlayerData>();
        Assert.Greater(list.Count, 0);
    }
    
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        UnityTask task = GDF.Launch;
        yield return WaitTask(task);

        yield return Connect();

        task = GDF.Player.Purge();
        yield return task;
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        UnityTask task = GDF.Authentication.SignOut();
        yield return WaitTask(task);
        
        GDF.Kill();
    }
    
    private IEnumerator Connect()
    {
        UnityTask task = GDF.Authentication.SignInDevice(GDFCountryISO.GetFromTwoLetterCode("FR"));
        yield return WaitTask(task);
    }

    private IEnumerator AlternateConnect()
    {
        UnityTask task = GDF.Launch;
        yield return WaitTask(task);

        string address = "test-account-no-use-please@not-existing.plop";
        string password = "Super-seecret_Password+12357865";
        
        task = GDF.Authentication.SignInEmailPassword(GDFCountryISO.GetFromTwoLetterCode("FR"), address, password);
        yield return task;

        if (task.State == TaskState.Failure)
        {
            task = GDF.Authentication.RegisterEmailPassword(GDFCountryISO.GetFromTwoLetterCode("FR"), address, password, password);
            yield return WaitTask(task);
        }
    }

    private IEnumerator WaitTask(UnityTask task, TaskState expectedState = TaskState.Success)
    {
        yield return task;

        if (task.State != expectedState)
        {
            Assert.Fail("Task '" + task.Name + "' finished with the unexpected state '" + task.State + "' !\n" + task.Error);
        }
    }
}
