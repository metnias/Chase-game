# Chase-game
 Unity study game 1

First proper "game" I've made from the scratch... except those assets.
It's playable, winnable, and losable. Not very replayable though.

I was practicing Component Pattern with this,
which is why there are separate cs files for movement and animation.
(Also using Singleton Pattern but I'm already used to that thanks to RW's PM)

I tried keeping everything (except the build settings for UNITY_EDITOR and STANDALONE)
within the knowledge from the class I've taken so far.
That's why it's using four arrays and enum for animating Human sprite (Walker.cs)
instead of, y'know, Unity's built-in finite-state-machine animator.
