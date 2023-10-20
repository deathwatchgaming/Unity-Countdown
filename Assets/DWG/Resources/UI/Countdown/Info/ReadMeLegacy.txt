CountDown (Text Legacy)
-----------------------------------

Description:

Primarily, this simple script simply allows you to add a visible display
CountDown in your scene UI Canvas via Text (Legacy) that counts down seconds to
completion and then at the end of said countdown to do something if you
choose to define something to do or not. For example we switch scenes but
this can be anything you want, and this example part can be commented out if
not desired. 

Manual Setup:

This first part is added just as an example of something that can be done when
the countdown completes: (Switch Scene say just for example and can be easily
removed by commenting out those parts in source)

Also note: 

If you do not desire any of the debug logs to display, you can comment those
out, but they are left there to help be informative while you work on things,
so that is up to you to comment out or not.

Important Note: 

* The desired scene to switch to must first be defined in the build
  settings: "Add Open Scenes"!

Example:

Create 2 scenes:

1) Demo Start 
2) Demo Switched

open each and add them to build settings.

ie:

Scenes/Demo Start       0 
Scenes/Demo Switched    1

In the Demo Start Scene:

Ok, now lets get to the manual setup in UI:

1.A) Create an Empty Game Object called UI  to house your UI canvas(unless you
already have a UI empty object to house your Canvas) * (Else You can alos
instead just opt to just create a UI Canvas, up to you.)

1.B) Create: in UI -> Canvas (unless you already have a UI Canvas)

2) Create inside UI Canvas as child: -> Text (Legacy)

Rename it to: CountDown Text (Legacy)

Details:

Rect Trans: top center  

Position: X: 0 Y: -50 Z: 0

Width: 200  Height: 50

Text Legacy - Text UI: -> Text Input: lets say 15 just for scene tab viewing
display example.

Font: Legacy Runtime

Font Style: Bold

Font Size: 46

Font Alignment: Center & Middle

Horizontal Overflow: Overflow
Vertical Overflow: Overflow

Color Hex: #DD1C1C

3) On that CountDown Text (Legacy)  -> Inspector: 

Add Script: CountDownLegacy.cs

4) Ok, now view in inspector the added scipt:

"Script": Count Down Legacy (Script)

By default it should look like:

Script: CountDownLegacy.cs 
Scene To Load: 
Start Timer: 
Count Down Enabled: 
Countdown Time:

5) Add desired switch to "Scene Name" in corresponding input textarea:

ie:

"Scene To Load": Demo Switched

6) Add "Start Timer":

Select:

CountDown Text (Legacy)

7) You can ignore the checked "Count Down Enabled" check box unless you want
to disable the CountDown

8) Add your "CountDown Time": For example lets say add 15 say for 15 seconds.


By now it should look somthing like:

Script: CountDownLegacy.cs 
Scene To Load: Demo Switched
Start Timer: CountDown Text (Legacy)
Count Down Enabled: Yes
Countdown Time: 15

 
Alright that is it for setup! Simple enough, right?!

You can now go ahead and load/play your start scene and watch the timer count
down and then switch to the scene you selected. Best of luck!

Final Note:

If you do not desire the debug logs display then simply comment out any and or
all of those specifically in the script, no biggie. :)
