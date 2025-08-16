using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace MyFirstPlugin.patches
{
  public class BBManagerFix
  {
    public class GetBlocksOfTypePatch
    {
      public static bool patch_GetBlocksOfType(
        ref List<int> blockList,
        BaseBuildingBlock.BuildingBlockType blockType,
        BaseLevelManager.LevelLayers layer,
        BaseLevelManager.LayersEnvironment environment,
        BaseBuildingBlock.BlockSet filterTheme = 8191,
        BaseBuildingBlock.PurposeGroups filterPurpose = 4194303,
        long iFamily = -1,
        bool automatic = true,
        BaseBuildingBlock.CompletionState validity = 0,
        bool bOnlySelectable = true)
      {
        if (Plugin.blockList.Count > BuildingBlockManager.GetInstance().m_BuildingBlocks.Length - 5)
          Plugin.blockList.Clear();
        int num1 = 0;
        bool flag = true;
        int num2 = layer == 6 | flag ? (environment != null ? 178956970 : 89478485) : (environment != null ? 1 << layer * 2 + 1 : 1 << layer * 2);
        for (int index = BuildingBlockManager.GetInstance().m_BuildingBlocks.Length - 1; index >= 0; --index)
        {
          BaseBuildingBlock buildingBlock = BuildingBlockManager.GetInstance().m_BuildingBlocks[index];
          if (Object.op_Inequality((Object) buildingBlock, (Object) null) && !buildingBlock.m_EditorOnly | flag && ((buildingBlock.m_ValidLayers & num2) != 0 || layer == 6) && (automatic || !automatic && !buildingBlock.m_AutomaticBlock) && (buildingBlock.m_Variation == -1 || buildingBlock.m_VariationSelectable || !bOnlySelectable) && (buildingBlock.m_OurBlockSets & filterTheme) != null && (filterPurpose == 4194303 || (buildingBlock.m_BlocksPurpose & filterPurpose) != null) && (iFamily == -1L || (buildingBlock.m_Family & iFamily) != 0L))
          {
            Plugin.blockList.Add(index);
            ++num1;
            blockList.Add(index);
          }
        }
        BuildingBlockManager.SortBlockList(ref blockList);
        return false;
      }
    }
  }
}
