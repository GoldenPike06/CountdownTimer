# CountdownTimer
Simple countdown timer for Unity.

## Features:
- Display format includes:
  - Second
  - Minute:Second
  - Hour:Minute:Second
- Option to repeat
- Timer delay functionality
- Control single or multiple timers in a scene
- Add custom events when timer reaches a certain point
- Progress bar functionality
- Customize color and UI display

## Quickstart:
1. Create an empty game object and attach the Timer component.
2. Create another game object and attach the TimerManager component, which will contain a list of timers.
3. Create a TextMeshPro-Text game object and attach the TimerUI component
4. Serialize the values for each script in the inspector.

Alternatively, you can create a new Timer in code using the CreateTimer method in the TimerManager class.
1. Set the TimerUI's timer property to the new timer. This will automatically set the Timer in the TimerUI component's Timer field.
2. Use the TimerManager class' methods to start/stop/pause/resume/restart timers.

To add a custom event when the timer reaches a certain point, invoke the OnCustomEvent anywhere in the CountDownTimer in the Timer class.

**Note:**
Deselecting Start On Awake in the Timer component will require you to use the StartTimer method from the TimerManager class wherever you wish to start the timer.
