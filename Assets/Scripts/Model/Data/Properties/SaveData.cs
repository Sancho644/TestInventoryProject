namespace Scripts.Model.Data.Properties
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class SaveData
    {
        public List<InventoryItemData> SaveItems = new List<InventoryItemData>();
    }
}