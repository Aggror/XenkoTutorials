using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace CSharpBasics.Code
{
    /// <summary>
    /// This script demonstrates how to get and remove components that are attached to an entity. 
    /// Try not to Get a component every frame as this will have negative performance impact. 
    /// Instead try to cache a component in the start method or when an object is initialized/triggered
    /// </summary>
    public class GettingAComponent : SyncScript
    {
        int ammoCount1 = 0;
        int ammoCount2 = 0;

        public override void Start()
        {
            //We retrieve the Ammo component that is also attached to the current entity
            AmmoComponent ammoComponent1 = Entity.Get<AmmoComponent>();

            //We can now access public methods and properties of the retrieve component
            ammoCount1 = ammoComponent1.GetTotalAmmo();

            //We now remove the AmmoComponent from our entity. If we try to retrieve it again, null will be returned
            Entity.Remove<AmmoComponent>();
            AmmoComponent ammoComponent2 = Entity.Get<AmmoComponent>();

            //Now that 'ammoComponent' is null, we will never be able to retrieve the total ammo
            if (ammoComponent2 != null)
            { 
                //This line will never happen
                ammoCount2 = ammoComponent2.GetTotalAmmo();
            }

        }

        public override void Update()
        {
            //We display the stored ammo count on screen
            DebugText.Print("Ammo count 1: " + ammoCount1.ToString(), new Int2(10, 200));
            DebugText.Print("Ammo count 2: " + ammoCount2.ToString(), new Int2(10, 220));
        }
    }
}
