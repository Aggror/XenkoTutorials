using Xenko.Core.Mathematics;
using Xenko.Engine;

namespace CSharpBasics.Code
{
    /// <summary>
    /// DeltaTime is used to calculate frame independant values. 
    /// DeltaTime can also be used for creating Timers.
    /// </summary>
    public class DeltaTime : SyncScript
    {
        //In this variable we keep track of the total time the game runs
        float totalTime = 0;

        //We use these variable for creating a simple countdown timer
        float countDownStartTime = 5.0f;
        float countDownTime = 0;

        public override void Start()
        {
            //We start the countdown timer at the initial countdown time of 5 seconds
            countDownTime = countDownStartTime;
        }

        public override void Update()
        {
            ///We can access Delta time through the static 'Game' object.
            var deltaTime = (float)Game.UpdateTime.Elapsed.TotalSeconds;

            //We update the total time
            totalTime += deltaTime;

            //Since we have a countdown timer, we subtract the delta time from the count down time
            countDownTime -= deltaTime;

            //If the repeatTimer, reaches 0, we reset the countDownTime back to the count down start time
            if (countDownTime < 0)
            {
                countDownTime = countDownStartTime;
            }

            //We display the total time and the countdown time on screen
            DebugText.Print("Total time: " + totalTime, new Int2(30, 200));
            DebugText.Print("Countdown time: " + countDownTime, new Int2(30, 220));
        }
    }
}
