namespace LazyEvade.KappaCommon.Databases.Items
{
    public static class ItemsDatabase
    {
        public static ItemData Youmuus = new ItemData(3142, ItemCastType.Active, int.MaxValue, int.MaxValue, 0);
        public static ItemData Cutlass = new ItemData(3144, ItemCastType.Targeted, 550, int.MaxValue, 0);
        public static ItemData Botrk = new ItemData(3153, ItemCastType.Targeted, 550, int.MaxValue, 0);
        public static ItemData Tiamat = new ItemData(3077, ItemCastType.Active, 200, int.MaxValue, 0);
        public static ItemData Hydra = new ItemData(3074, ItemCastType.Active, 200, int.MaxValue, 0);
        public static ItemData TitanicHydra = new ItemData(3748, ItemCastType.Active, 200, int.MaxValue, 0);
        public static ItemData HydraItem => Hydra.Ready ? Hydra : TitanicHydra.Ready ? TitanicHydra : Tiamat;
    }
}
