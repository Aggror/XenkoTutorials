using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace CSharpBasics.Code
{
    /// <summary>
    /// This script demonstrates how to access the entity where the script is attached to. 
    /// We also learn how to access a parent of our entity and how to check if that entity exists.
    /// </summary>
    public class GettingTheEntity : SyncScript
    {
        string name = "";
        string parentName = "";

        //Executes only once, at the start of the game
        public override void Start()
        {
            //We store the name of the Entity that we are attached to
            name = Entity.Name;

            //We retrieve the parent entity by using the GetParent() command.
            Entity parentEntity = Entity.GetParent();

            //It is possible that our entity does not have a parent. We therefor check if the parent is not null.
            if (parentEntity != null)
            {
                //We store the name of our Parent entity
                parentName = parentEntity.Name;
            }

            //The above code can be shortened to 1 line by using the '?' operator  
            parentName = Entity.GetParent()?.Name;
        }

        //Updates every frame
        public override void Update()
        {
            //Using the 'DebugText.Print' command, we can quickly print information to the screen
            //NOTE: DebugText only works when debugging the game. During release it is automatically disabled
            DebugText.TextColor = Color.Red;
            DebugText.Print(parentName, new Int2(10, 20));
            DebugText.Print(name, new Int2(30, 40));
        }
    }
}
