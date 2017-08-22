# Final Project - Vegan Zombie

An infinite runner game where you take control of businessman who had unfortunately turned into a zombie. The only human sense that the businessman retained was that he was a vegan. So, as to resist his carnivore urges, he tries to continue to eat vegetables in hopes he will become human again. A food truck with its back door unlatched drives by the zombie and started dropping vegetables and meats. With only his sense of vegetarian and carnivore instincts left, he chases after the truck to get all the food that it drops despite of the on-coming traffic.

Gameplay: Try to become the best vegan zombie by collecting all the vegetables. Be careful of on-coming traffic and wade past through the cars. Meat will also be dropped on to the road, but collecting those will decrease your vegan score and you must collect more vegetables to counteract the negative score.   

Chase the food while avoiding cars!
![On Coming Image of Scene](https://github.com/csc631-831-spring-2017/Team11-final-project/blob/master/Assets/Screenshots/OnComing.jpg)

Limited view means you need to carefully weave between the cars...
![In-game screenshot](https://github.com/csc631-831-spring-2017/Team11-final-project/blob/master/Assets/Screenshots/inGame.jpg)

## Due 04/08:
* ~~Decide on the Idea.~~
	+ We are going to do a "runner game" 
* ~~Decide on the target platform(Mac/Android/IOS,etc).~~
	+ The platform is Android. 
* Discuss weekly scrum meeting times outside of class times. Can be remote meetings, but in-person meetings are highly recommended.
* Decide who is going to be the manager for the Git Repo. 
* Write out the various milestones below in the following format "Requirement - person responsible."
* Example: "Prepare health manager and mechanism for all relevant players to have a health component - Omar" 
* Make sure you discuss the idea and milestones with me on the first day, or anytime you decide to pivot your project.
* You must have access to your target platform in order to build for it (ex: Must have an android phone for android projects, Must have a Daydream ready phone and controller for Daydream project. Tango device for a tango project. A nintendo switch dev kit for nintendo switch project.)
* Each of your team members must answer the following in your **scrum meetings**:
	1. What have I done since our last meeting
	2. What I plan do to till the next meeting
	3. Are there any issues that the team can help me with.


## Due 04/15:
Player and terrain.

* Implement a player - Jason
* ~~Set up menu system - Jenny~~		
* Set up (sidestep) swipe controls for player - Youssef 

Updates on the assigned task.
* A scene called "Demo" added along with a test player character. Camera already setup to follow the movement of the player - Jason
* A menu layout has been implemented, but still needs work on: Menu Design, Color Scheme, Menu Animations. - Jenny

### Scrum meeting notes (4/10):
Absent: Youssef

* Discussed on two types of gameplay, infinite runner and 2D platformer.
	* Decided on an infinite runner, leaving 2D platformer as an extra thing if we have time.
#### Infinite Runner Notes
*  Objective: Collect rewards to up a High Score.
* Controls: Has forced forward movement,  but player will be allowed to sidestep  obstacles in their path. 	
* Lose: Player will die if they hit an obstacle.	
* Setting: Most likely city. 
* Difficulty settings:
	* Speedup over time
	* More obstacles 
* Enemy(s): Something that is causing the Player to run away from.
	* Rocks, people, animals, etc...
* Map Transition Idea: We have one piece of terrain. As player nears the edge of the terrain, another piece of the terrain will append to the current piece. When the player moves on to the next terrain, the previous terrain will be destroyed.
	* Player will be detected by how far along they are on terrain via x-coordinates.
* Optional Notes
	* Powerups to help increase the score or help the player move further the map.
	* Extra controls: Swipe up to jump and swipe down to slide.

##### 2D platformer Notes (Here to keep note of, but not required to do)
	* Objective: Get to the goal.
	* Controls: Has free movement on a 2D plane.
	* Setting: City
	* Has an event triggers.
		* Good/neutral/evil bar affects how NPCs react to player.
		* Example: A gangster robs an store owner. Player may/may not intervene.
		* Triggers into the Infinite Runner upon reaching the goal.
	* NPC(s): Citizens, police, gangster, store owner.	

##### Another Note on Player
	Possibly have a hamster? To have something cute running around.
	- Currently dependent on Jason if he has time to make a hamster model.

---
## Due 04/22:
Camera and Enemies

* Implement spawnable points using the EventSystem - Jason
* ~~Implement a Pause Button to allow the Player to go back to Main Menu - Jenny~~
* ~~Find appropriate assets to help fit our new Setting - Youssef~~

### Scrum meeting notes (4/17):
Everyone present.

* Discussed 
	* Map design 
	* How to implement map design in code 
	* Gameplay
	* Some UI.

#### Map Design
* Number of lanes would be either three/four.
* Setting was changed to country side.
	* Player will be running on the road with grasslands/fences off to the side.
	* Animals consisted of cows/dogs/sheep.
	* Player would be eating vegetables or eating farm animals.
* General layout: 
	* Side panels on the side of the playable lanes to have enemies spawn from and move on to the playable lane.
	* Boundaries on both sides of the playable lanes to prevent the player moving off the lanes.
	
#### Thoughts on Implementation of Map Design
* Have a plane (game object) and spawn the road prefab on top of the plane.
	* The idea is to try and use current code to spawn things in.
* The plane will have points of spawnable areas where they'll activated by a raycast from the camera.
	* This would help set up safeguards so that the Player always has at least one open path to move through.

#### Gameplay
* Moral bar: Good (Positive) / Neutral (Zero) / Evil (Negative)
	* Good actions (+points): Eating vegetables
	* Evil actions (-points): Eating animals
* High score will be based on how evil/good the Player is.
* Difficulty is based around the moral bar:
	* If the player is on the Good side, more evil actions will spawn more often. This prompts a higher difficulty by having the Player do more work to keep their Good Bar score high.
		* Also suggested to have more pitfalls with "roadblock" signs to have the player dodge more obstacles.	
	* If the player is more on the evil side, there will be more hostile dogs to attack the Player. 
* Death/Lose Conditions
	* Hitting animals or other things will cause the Player to lose a bit of health.
	* Falling into pitfalls will be instant death.

#### Player UI
* Health bar on the top-left side.
* Pause Button will be top-right side.
	* On press will allow Player to resume or go back to Main Menu.
* Moral bar appears next to Pause button.

---
## Due 04/29:
Health, Highscore and Animation

* Figure out spawn points. - Jason
* ~~Adjust the main Score. - Jenny~~
* ~~Create prefabs for Spawnable Objects. - Jenny~~
* ~~Implement a player health bar. - Youssef~~
* Implement a player's score canvas.

### Scrum meeting notes (4/24):
Absent: Youssef

Discussed the details of how to implement gameplay's functionality as code and how objects in the scene should be organized.

#### Organization of Objects in Scene
* Prefab for road
	* Plane is viewed as left side lane, road (playable area), and right side lane.
	* Plane is laid along on the x, z axes with y being perpendicular. 
		* Along the z-axis, Player is running in the negative z-direction.
		* Along the x-axis, is the width of the plane. 
		* Along the y-axis, is just the "up" direction.
	* Bottom-left corner of the prefab will be (0,0,0) in x, y, z coordinates respectively. 	
	* Still need to figure out scaling of prefab so that we can accurately spawn objects and set up boundaries for the Player.
		* x = 6 was suggested; Meaning that the prefab would sliced into |--2--||--2--||--2--| where we have left lane, middle, and right lane respectively.
		* z = 6 was suggested to help grid out the spawn points of the objects in front of the player.
* Player
	* Score canvas above their head. This is used to show how much each item's object is worth.
		* Functionality: Whenever the Player collides with an object, the score of the object will be displayed in Player's score canvas. 
		* Player will be checking if they have collided with objects in script.
		* Display: When player hits object, the object's point worth is displayed in the Player's score canvas. After a few seconds, the points fade away. Check under Score for coloring. 
	* Health Bar (overlay on the same plane as the Main Score)
		* When the Player hits objects that cause damage, health -= object's hit points.
		* When the Player hits an object that cause instant death, health -= maxHP.
* Score
	* Player will initially start with zero points when the game begins. 
		* When score is = 0, score text color will be colored white.
	* Good objects are a positive increase to the score.		
		* When score is > 0, score text will be colored green.
	* Evil objects are a negative detriment to the score.
		* When score is < 0, score text will be colored red. 
	* Functionality: Score += (Incoming points from Player)
	* Determining which score to record to high score.
		* If score is positive, record to Good High Score
		* If score is negative, record to Evil High Score
		* If score is equal to zero, display a special message.
* Spawnable Objects
	* These are the objects that collide with the Player to affect the score or the Player's health in some way.
	* Animals: These objects influence a negative score
		* Cow
			* Collider 
			* Rigidbody
			* Script for movement (along the x-axis) 
	* Vegetables: These objects influence a positive score
		* ??? (some vegetable)
			* Collider
			* Rigidbody
	* Traps: These objects either cause instant death or a loss of health
		* Hole (Instant death)
			* Collider

---
## Due 05/06:
Gameplay and menu system

* ~~Generate objects randomly - Jason~~
* ~~Sound effects & background music - Jason~~
* Score update - Jenny
* Collider Trigger - Jenny
* ~~Work on shifting terrain - Youssef~~ 
* ~~Create prefabs of objects - Youssef~~

### Scrum meeting notes (5/1):
Everyone present.

Discussed gameplay mechanics and how to setup spawns on established terrain. 

#### More on Spawnable Objects
* We want to adjust the frequency of the kind of objects that spawn based on the Player's current score. 
	* If the Player has a high Good Score, then we spawn the Evil objects more frequently and less of the Good objects. And vice versa if the Player had a high Evil Score.
	* However, we should be careful to not completely stop spawning one of the objects of which forces the Player to lower their score.
* Placement of objects should spawn just out of the Player's Field of View. 
* When a player collides with an object, the type of object will be determined by their tag.
	* The point values will be accessed through the object's Script which has a Getter method to access the object's point value.

#### Pesudocode for random spawnings.
	Start() Method
		Collectable objects are loaded on one tile in front of player.
		Note: Player is at tile index 1.

	Update() Method
		Collectable objects will be created along the tiles

	Helper(int random) Method (to discern between different objects)
		switch(int)
			// Different prefabs of the collectables
			case 1:  
			case 2: 
			// etc..

---
## Due 05/13:
Debugging 

* Work out death animation. - Jenny
* ~~Add difficulty. - Youssef~~
### Scrum meeting notes (5/8):
Everyone present.

Discussed gameplay and various animations. Also had to fix GitHub issues.

#### Death Animation for Player
* When a player hits a car, everything should be paused except for the cars.
	* Pause almost everything; the only thing that should be moving is the car.
		* Player movement and freeze input controls.
		* Camera
		* Background music
		* Terrain Generation
	* Let the Player be pushed out of the scene by the car.
		* A corountine will be used to let the car drive "off-screen" (i.e. when the car moves past the camera).
		* This can be detected by the camera's z-position.
	* Play the death sound.
	* Call Gameover scene
		* Will have options to either Play Again or Go back to Main Menu. 
#### Point Collection Animation
* Discussed two ways to express responsiveness.
	* Show the amount of points collected on the Player.
	* Have the object fade to the top-left of the screen where the points are.

---
## Due 05/20:DEMO DAY
Done / Debugging

* ~~Death animation - Jenny~~ 
* ~~Point +1/-1 feedback to player when collecting vegetable/meat. - Jason~~
### Scrum meeting notes (5/15):
* Fixed various bugs and collider issues that had interfered with an implementation. 

---
##Notes

* Make sure to updated the meeting notes from the scrum meeting outside of class.
* When work is finished, and milestones completed, strikethrough the requirement line to show progress,  ~~such as this~~
* You have to write a completed by: for each strikethrough.
* Example: ~~"Prepare health manager and mechanism for all relavant players to have a health component - Omar"~~ Completed by John Doe.
* Your requirements and intended features may change during scrums. Make sure you update this Readme if that happens(I support active change in reqs).
* Make sure you attend class regularly and show me the completed requirements in class. I will be interviewing teams every Saturday for grading purposes.
* Individual grading criteria: Saturday interviews, github commits, eventual team review form.
* Group Grading criteria: The usual grading criterial at the end of the project.(Fun to play, no bugs, Good contextual art, other minor things).
* You have been allocated Git LFS storage space on GitHub. You must use it if you intend to upload large files.

