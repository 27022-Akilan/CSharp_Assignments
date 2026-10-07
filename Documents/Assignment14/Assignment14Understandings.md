# Project, Solutions and Build Orders

### Issues Faced : Cyclic Dependency

Here in the question they have stated
- Project B should depend on the Project C.
- Project C should utilize the functionalities from Project B.

B -> C and C -> B :: Cyclic dependency

"C:\C#\C#_Assignment\Demo_Asg\Documents\Assignment14\Images\Screenshot 2026-10-07 151210.png"

The compiler cant decide which to build first as B <-> C are depending on each other.

So just,

GreetingsApp -> Math App -> Display App -> Utility App,
there is no cyclic dependency between Math app and display app.

### Build Order: 
1.Utility App
2.Display App
3.Math App
4.Greetings App

After adding project E(Report App)

1.Utility App
2.Display App
3.Math App
4.Report App
5.Greetings App
"C:\C#\C#_Assignment\Demo_Asg\Documents\Assignment14\Images\Screenshot 2026-10-07 154702.png"
The exact positions the projects that do not have a dependency relationship
with each other can vary, as long as all dependency constraints are not varied.

