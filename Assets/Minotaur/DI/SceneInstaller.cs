using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    public Player mainPlayer;

    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(mainPlayer).AsSingle();
        Container.Bind<InteractionManager>().AsSingle();
        Container.Bind<IInventoryScreenProvider>().To<InventoryScreenTemplate>().FromComponentInHierarchy().AsSingle();

        Item wood = new Item() { name = "Wood", maxStackSize = 64, icon = null, prefab = null };
        Inventory testInv = new Inventory(10);
        testInv.Stacks[0].Replace(new ItemStack(wood, 5));

        Container.Bind<Inventory>().FromInstance(testInv).WhenInjectedInto<Player>();
    }
}