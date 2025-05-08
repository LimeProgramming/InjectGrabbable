using FrooxEngine;
using ResoniteModLoader;

namespace InjectGrabbable
{
    public partial class InjectGrabbable : ResoniteMod
    {

        private static void InjectComponentIntoChild(Slot slot, Slot child)
        {
            var Grabbable = child.AttachComponent<Grabbable>();

            // What else you wanna do?
        }
    }
}