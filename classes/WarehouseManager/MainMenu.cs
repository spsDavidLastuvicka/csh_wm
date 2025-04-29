public partial class WarehouseManager
{
    public static int MainMenu()
    {
        return Tools.OptionSelector(
            Text: "Nabídka správy skladu",
            Options: new string[]
            {
                "Přidat produkt",
                "Přidat šablonu produktů",
                "Vypsat produkty",
                "Vyhledat produkt podle jména",
                "Vyhledat produkt podle jména a max. ceny",
                "Smazat produkt",
                "Potvrdit změny & ukončit",
                "Rollback"
            }
        );
    }
}