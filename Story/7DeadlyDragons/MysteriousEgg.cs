//cs_include Scripts/CoreBots.cs
//cs_include Scripts/CoreStory.cs
using RBot;

public class MysteriousEgg
{
    public ScriptInterface Bot => ScriptInterface.Instance;
    public CoreBots Core => CoreBots.Instance;
    public CoreStory Story = new CoreStory();

    public void ScriptMain(ScriptInterface bot)
    {
        Core.SetOptions();

        GetMysteriousEgg();

        Core.SetOptions(false);
    }

    public void GetMysteriousEgg()
    {

        if (Core.CheckInventory("Mysterious Egg"))
            return;

        Story.PreLoad();

        Core.AddDrop("Mysterious Egg", "Key of Pride", "Key of Gluttony", "Key of Greed", "Key of Sloth", "Key of Lust", "Key of Envy", "Key of Wrath");

        Core.EnsureAccept(6171);
        Core.HuntMonster("pride", "Valsarian", "Key of Pride", isTemp: false);
        Core.HuntMonster("gluttony", "Deflated Glutus", "Key of Gluttony", isTemp: false);
        Core.HuntMonster("greed", "Goregold", "Key of Greed", isTemp: false);
        if (!Core.CheckInventory("Key of Sloth"))
        {
            Core.EnsureAccept(5944);
            Core.GetMapItem(5380, map: "sloth");
            Core.GetMapItem(5381, map: "sloth");
            Core.EnsureComplete(5944);
        }
        if (!Core.CheckInventory(40710))
        {
            Core.EnsureAccept(5944);
            Core.GetMapItem(5380, 1, "sloth");
            Core.GetMapItem(5381, 1, "sloth");
            Core.EnsureComplete(5944);
        }
        Core.Equip("Hazmat Suit(Temp)");
        Core.HuntMonster("sloth", "Phlegnn", "Key of Sloth", isTemp: false);
        Core.HuntMonster("lust", "Lascivia", "Key of Lust", isTemp: false);
        Bot.Quests.UpdateQuest(6000);
        Core.HuntMonster("maloth", "Maloth", "Key of Envy", isTemp: false);
        Core.HuntMonster("wrath", "Gorgorath", "Key of Wrath", isTemp: false);
        Core.EnsureCompleteChoose(6171, new[] { "Mysterious Egg" });
    }
}