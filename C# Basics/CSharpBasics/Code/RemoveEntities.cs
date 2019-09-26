using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace CSharpBasics.Code
{
    /// <summary>
    /// This script demonstrates how to clone an existing entity and how cloned entities can be added to the scene hierarchy.
    /// </summary>
    public class RemoveEntities : SyncScript
    {
        public Entity entityToClone;
        private Entity clonedEntity1;
        private Entity clonedEntity2;
        private float cloneCounter = 0;
        private float timer = 0;
        private float createAndRemoveTime = 2;

        public override void Start()
        {
            CloneEntityAndAddToScene();
        }

        private void CloneEntityAndAddToScene()
        {
            clonedEntity1 = entityToClone.Clone();
            clonedEntity1.Transform.Position += new Vector3(-2, 0, 0);
            SceneSystem.SceneInstance.RootScene.Entities.Add(clonedEntity1);
            cloneCounter++;
        }

        public override void Update()
        {
            //We use a simple timer
            timer += (float)Game.UpdateTime.Elapsed.TotalSeconds;
            if (timer > createAndRemoveTime)
            {
                //If the clonedEntity variable is null, we clone an entity and add it to the scene
                if (clonedEntity1 == null && clonedEntity2 == null)
                {
                    CloneEntityAndAddToScene();
                }
                else
                {
                    //We remove the cloned entity from the scene 
                    SceneSystem.SceneInstance.RootScene.Entities.Remove(clonedEntity1);

                    //We also need to set it to null, otherwise the clonedEntity still exists
                    clonedEntity1 = null;
                }

                //Reset timer
                timer = 0;
            }

            DebugText.Print("Every uneven second we clone an entity and att it to the scene.", new Int2(200, 80));
            DebugText.Print("Clone counter: " + cloneCounter, new Int2(200, 120));
            DebugText.Print("Every even second we remove the cloned entity from the scene.", new Int2(200, 200));
            if (clonedEntity1 == null)
            {
                DebugText.Print("Cloned entity is null", new Int2(200, 240));
            }
            else
            {
                DebugText.Print("Cloned entity is in the scene", new Int2(200, 240));
            }
        }
    }
}
