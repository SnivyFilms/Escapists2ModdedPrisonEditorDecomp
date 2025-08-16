namespace MyFirstPlugin.patches
{
  public class LevelDetailsManager_fix
  {
    public static bool StoreTheLevel(
      object[] __args,
      LevelDetailsManager.RequestResult resultCallback,
      bool bForceNewSave = false)
    {
      resultCallback?.Invoke((LevelDetailsManager.RequestResultEnum) 1);
      __args[0] = (object) null;
      return true;
    }
  }
}
