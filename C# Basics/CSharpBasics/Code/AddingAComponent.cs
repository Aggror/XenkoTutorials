using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace CSharpBasics.Code
{
    /// <summary>
    /// This script demonstrates how to add a component to an entiy. 
    /// We also learn a way to automically create and attach a component to our entity. 
    /// </summary>
    public class AddingAComponent : SyncScript
    {
        AmmoComponent ammoComponent1;
        AmmoComponent ammoComponent2;

        int ammoInStart;
        int ammoInUpdate;

        public override void Start()
        {
            //We can add a new component to an entity using the 'Add' method.
            ammoComponent1 = new AmmoComponent();
            Entity.Add(ammoComponent1);

            //We can even add the component a second time
            ammoComponent2 = new AmmoComponent();
            Entity.Add(ammoComponent2);

            //Lets remove all components of type AmmoComponent
            Entity.RemoveAll<AmmoComponent>();


            //When there is no component of this type attached, but we like there to be one, we can create it automatically
            //NOTE: when a component is created like this, the 'Start' method will be called after this script's Update method has executed
            ammoComponent1 = Entity.GetOrCreate<AmmoComponent>();

            //Because the start method of AmmoComponent1 is not called yet at this point, 'ammoInStart' will remain at 0
            ammoInStart = ammoComponent1.GetTotalAmmo();
        }

        public override void Update()
        {
            //We always retrieve the latest value for "ammoInUpdate" every frame
            ammoInUpdate = ammoComponent1.GetTotalAmmo();

            DebugText.Print("Total ammo during Start()  : " + ammoInStart.ToString(), new Int2(10, 240));
            DebugText.Print("Total ammo during Update() : " + ammoInUpdate.ToString(), new Int2(10, 260));
        }
    }
}
