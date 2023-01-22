namespace NoPsycasts;

[StaticConstructorOnStartup]
public static class StartupHandler
{
    static StartupHandler()
    {
        Mod.Instance?.OnStartup();
    }
}