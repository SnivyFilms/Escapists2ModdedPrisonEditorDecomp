using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MyFirstPlugin.patches;
using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace MyFirstPlugin
{
  [BepInPlugin("org.anonymusdennis.net.MapEditor", "MapEditor", "1.0.0.0")]
  public class Plugin : BaseUnityPlugin
  {
    public static List<int> blockList;
    public static ManualLogSource Logger;
    public static Plugin instance;

    private void Awake()
    {
      Plugin.blockList = new List<int>();
      ManualLogSource manualLogSource = new ManualLogSource("MapEditor");
      BepInEx.Logging.Logger.Sources.Add((ILogSource) manualLogSource);
      Plugin.Logger = manualLogSource;
      Plugin.Logger.LogInfo((object) "Plugin MapEditor is loaded!");
      Plugin.instance = this;
      Harmony harmony = new Harmony("org.anonymusdennis.net.MapEditor");
      MethodInfo methodInfo1 = AccessTools.Method(typeof (BuildingBlockManager), "GetBlocksOfType");
      AccessTools.Method(typeof (BuildingBlockManager.LimitationGroup), "LimitationGroupChanged");
      MethodInfo methodInfo2 = AccessTools.Method(typeof (BBManagerFix.GetBlocksOfTypePatch), "patch_GetBlocksOfType");
      AccessTools.Method(typeof (LevelDetailsManager_fix), "patch_LimitationGroupChanged");
      harmony.Patch(methodInfo1, new HarmonyMethod(methodInfo2));
    }

    private void Update()
    {
      try
      {
        BuildingBlockManager.LimitationGroup[] limitationGroups = BuildingBlockManager.GetInstance().m_LimitationGroups;
        if (limitationGroups == null || limitationGroups.Length == 0)
          return;
        BuildingBlockManager.GetInstance().m_LimitationGroups[21].m_CurrentTotal = 24;
        BuildingBlockManager.GetInstance().m_LimitationGroups[20].m_CurrentTotal = 24;
      }
      catch (Exception ex)
      {
      }
    }
  }
}
