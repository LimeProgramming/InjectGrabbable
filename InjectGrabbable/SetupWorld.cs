using FrooxEngine;
using ResoniteModLoader;

namespace InjectGrabbable
{
    public partial class InjectGrabbable : ResoniteMod
    {
        private static void SetupWorld(World world)
        {
            world.RunSynchronously(() =>
            {
                if (Config.GetValue(ModEnable))
                {
                    // Create Injectgrabble slot under world root
                    Slot InjectGrabbableRoot = world.RootSlot.AddSlot("InjectGrabbable", false);
                    InjectGrabbableRoot.Parent = world.RootSlot;
                    InjectGrabbableRoot.OrderOffset = long.MinValue;


                    // If the User wants to set a custom location for the InjectGrabbableRootLocation
                    if (Config.GetValue(InjectGrabbableRootLocation))
                    {
                        var DynamicDriver = InjectGrabbableRoot.AttachComponent<DynamicReferenceVariableDriver<Slot>>();
                        DynamicDriver.VariableName.Value = "World/InjectGrabbableRootLocation";
                        DynamicDriver.Target.TrySet(InjectGrabbableRoot.ParentReference);
                        DynamicDriver.DefaultTarget.TrySet(world.RootSlot);
                    }


                    InjectGrabbableRoot.ChildAdded += InjectComponentIntoChild;

                    // Regenerates the slot if destroyed
                    InjectGrabbableRoot.Destroyed += d =>
                    {
                        InjectGrabbableRoot.ChildAdded -= InjectComponentIntoChild;
                        SetupWorld(world);
                    };
                }
            });
        }
    }
}