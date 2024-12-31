using System;
using UnityEngine;

public class SwayPhysicsMod : Mod
{

    private enum Action { Load, Unload }
    private enum SwayPhysics { Basic, XAxisOnly, YAxisOnly, ZAxisOnly }
    private class SwayObject
    {
        public SwayPhysics swayPhysics;
        public GameObject ceiling = null;
        public GameObject wall = null;

        public SwayObject(SwayPhysics swayPhysics, GameObject ceiling = null, GameObject wall = null)
        {
            this.swayPhysics = swayPhysics;
            this.ceiling = ceiling;
            this.wall = wall;
        }
    }

    private SwayObject[] swayObjects = {
        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Lantern_Basic").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_Lantern_Basic").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Lantern_Metal").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_Lantern_Metal").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Bed_Hammock").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_StringLight_Vertical").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_StringLight_Horizontal").settings_buildable.GetBlockPrefabs()[0].transform.GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_StringLight_Horizontal").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_MotivationalSign_1").settings_buildable.GetBlockPrefabs()[0].transform.GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_MotivationalSign_1").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_MotivationalSign_2").settings_buildable.GetBlockPrefabs()[0].transform.GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_MotivationalSign_2").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_MotivationalSign_3").settings_buildable.GetBlockPrefabs()[0].transform.GetChild(0).gameObject,
            ItemManager.GetItemByName("Placeable_MotivationalSign_3").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_Clock_Fine").settings_buildable.GetBlockPrefabs()[1].gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_Sign").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Sign").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Cropplot_Small").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Flower_AloeVera").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Flower_Cactus").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Flower_Monstera").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_Flower_Rose").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(2).gameObject),

         new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Flower_Rose").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.ZAxisOnly,
            ItemManager.GetItemByName("Placeable_Flower_Sunflower").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.Basic,
            ItemManager.GetItemByName("Placeable_Flower_Sunflower").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_01").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_02").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_03").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_04").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_05").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_06").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

        new SwayObject(SwayPhysics.XAxisOnly,
            ItemManager.GetItemByName("Placeable_Flag_07").settings_buildable.GetBlockPrefabs()[2].transform.GetChild(0).gameObject),

    };

    public void Start()
    {
        foreach (SwayObject swayObject in swayObjects)
        {
            HandleSwayPhysicsObject(Action.Load, swayObject);
        }

        Debug.Log("Mod LanternPhysicsMod has been loaded!");
    }

    public void OnModUnload()
    {
        foreach (SwayObject swayObject in swayObjects)
        {
            HandleSwayPhysicsObject(Action.Unload, swayObject);
        }

        Debug.Log("Mod LanternPhysicsMod has been unloaded!");
    }
    private void HandleSwayPhysicsObject(Action action, SwayObject swayObject)
    {
        if (action == Action.Load)
        {
            switch (swayObject.swayPhysics)
            {
                case SwayPhysics.Basic:
                    swayObject.ceiling?.AddComponent<SwayPhysicsBasic>();
                    swayObject.wall?.AddComponent<SwayPhysicsBasic>();
                    break;

                case SwayPhysics.XAxisOnly:
                    swayObject.ceiling?.AddComponent<SwayPhysicsXAxisOnly>();
                    swayObject.wall?.AddComponent<SwayPhysicsXAxisOnly>();
                    break;

                case SwayPhysics.YAxisOnly:
                    swayObject.ceiling?.AddComponent<SwayPhysicsYAxisOnly>();
                    swayObject.wall?.AddComponent<SwayPhysicsYAxisOnly>();
                    break;

                case SwayPhysics.ZAxisOnly:
                    swayObject.ceiling?.AddComponent<SwayPhysicsZAxisOnly>();
                    swayObject.wall?.AddComponent<SwayPhysicsZAxisOnly>();
                    break;
            }
        }
        else if (action == Action.Unload)
        {
            switch (swayObject.swayPhysics)
            {
                case SwayPhysics.Basic:
                    if (swayObject.ceiling != null) Destroy(swayObject.ceiling.GetComponent<SwayPhysicsBasic>());
                    if (swayObject.wall != null) Destroy(swayObject.wall.GetComponent<SwayPhysicsBasic>());
                    break;

                case SwayPhysics.XAxisOnly:
                    if (swayObject.ceiling != null) Destroy(swayObject.ceiling.GetComponent<SwayPhysicsXAxisOnly>());
                    if (swayObject.wall != null) Destroy(swayObject.wall.GetComponent<SwayPhysicsXAxisOnly>());
                    break;

                case SwayPhysics.YAxisOnly:
                    if (swayObject.ceiling != null) Destroy(swayObject.ceiling.GetComponent<SwayPhysicsYAxisOnly>());
                    if (swayObject.wall != null) Destroy(swayObject.wall.GetComponent<SwayPhysicsYAxisOnly>());
                    break;

                case SwayPhysics.ZAxisOnly:
                    if (swayObject.ceiling != null) Destroy(swayObject.ceiling.GetComponent<SwayPhysicsZAxisOnly>());
                    if (swayObject.wall != null) Destroy(swayObject.wall.GetComponent<SwayPhysicsZAxisOnly>());
                    break;
            }
        }
    }
}