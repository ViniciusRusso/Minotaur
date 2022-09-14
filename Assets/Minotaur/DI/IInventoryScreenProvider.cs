public interface IInventoryScreenProvider<T> where T: Inventory {
    InventoryScreenTemplate GetInventoryScreen(T inventory);
}

public interface IInventoryScreenProvider : IInventoryScreenProvider<Inventory> {}