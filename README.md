# LSW
Implemented dialogue system (prewritten) that is based on graphs and callback + game flow system which is also based on callbacks. Dialogue system uses scriptable objects, which is really convinient. Character movement's really simple, using the rigidbody2D component to move and horizontal&vertical axis to direct. Shop system works with sriptable objects, in Resources\Items folder you can create as many objects as you want, not only hats btw. I implemented ItemUI which generates itemContainers based on how many objects you have in that resources folder for buy menu, and generates them containers based on what and how many items the player has. Equipping items : just spawns a prefab, that you have set to the scriptable object, and sets it as child to itemSpawn (in player prefab). Destroys that prefab if current item has changed. Used LeanTween to add a cool transition to the shop menu. There's a bug with the ui elements in the shop menu, which unfortunately I didn't have time to fix. Kept the ui simple cause I'm more of a programmer, didn't want to spend a lot of time on it. Overall i think i did a pretty good job with the time i had, just learned how graphs work so was pretty cool to use them.
Build exe in PC Build folder     Art : Pixel Art Top Down - Basic
Spent time on project : ~7h