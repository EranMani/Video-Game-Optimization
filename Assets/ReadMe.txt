* What is optimization?
	- Optimizing a project involves examining the performance of the code, rendering, physics, sound, artkwork, AI and many other things
	- In case of using 3rd party API's or a game engine, we will optimize things that we can control to fix the frame rate drop
	- Unity caps its editor game view at 60 frames per second
	- The amount of frame rate we need to have derived from the way our eyes work to perceive motion. Our visual system is able to recognize 
	  individual frames around the 12 frames per second mark. Any faster then this, the images are perceived as motion
	- The idea is that if it works, then we dont actually need to optimize it any further. Dont optimize if you dont need to
	- Optimization should be as important as a process in your game development version control. Optimization needs to be approached methodically, and 
	  for that there is an "optimization cycle":
		- Once you have an interactive product of some sort, you can begin the cycle by benchmarking the game
		- Benchmark: a point of reference to use to determine if the optimization efforts improve the game performance or make it worse. In short,
		             you make a benchmark out of the current state of the game. It must be something that you can run that is going to generate
					 the frame rate values for you. Then you make a change to your game and compare it against the benchmark
					 NOTE -> don't use the entire game as a benchmark since it will surely be performance fluctuations throughout
					 To start, you need to identify the parts of the game that is giving you grief with respect to performance. This might be
					 a particular scene or some kind of user interaction or a game event that slow things down. The benchmark should receive a 
					 consistent performance level across all runs.
					 1) Identify points of bad performance
					 2) Benchmark should repetitively produce the same performance level
					 3) Be quick to run (under a minute)
					 4) Representative of real game play
					 5) Responsive to change
					 
					 In practice, this means running the game and monitoring the performance a couple of times and identifying the issues. Once this
					 is done, you need to modify the game enough so that you can get straight back to the problem area without going through menus 
					 or other scenes.Then run the benchmark and record the performance. Compare it against anything that you fixed, make the change
					 and run the test again.
					 
					 Benchmark -> Detect issues -> Solve issues -> Check performance ->? Benchmark (start cycle again as you are making improvements)
		- There will be times where trade-offs will be required, like balancing between fixing issue version time and effect upon game budget,
		  release date and player experience.
		  1) Performance versus Space
				* Figure out if you want to use more memory to make calculations faster. Sometimes code will run a lot faster if it is allowed
				  to use more memory for storing values that it requires. This method is called MEMORIZATION for storing states needed
				  by an algorithm as it is running with the effect of speeding up the processing.
				  It is common practice in games to store values of things for use later on, rather then recalculating them from scratch. Like
				  storing object in a dictionary rather then using findAllWithTag method
		  2) Accuracy versus Speed
				* Balancing visual and processing accuracy with performance speed. 
				  For example: 
						real time shadows will blow out the performance, espically if you have them on many objects. While they look great, you might
						consider a much cheaper by using blob shadows which is just a texture on a quad that moves around with the character. In case
						of a game with many characters, this can get the game to run at 30 frames per second on a mobile device
		  3) Maintainability versus complexity
				* How you put the whole game together and the architecture that you put behind your game. While it might be extermely clever and faster
				  way to use for example ECS or SHADER CODE, it can bring more complexity that will be build into the budget and will make the game
				  much more difficult to maintain in the future
				  
	- Finally:
		* in optimization it is crucial that you will be consistent in your testing and change of modifications
		* Always test under the same conditions as you created your benchmark with
		* Ensure you are testing like with like and make a change one thing at a time.
			For example:
				When debugging code, changing 5 to 10 things that might cause a problem before testing them again. By doing this you cant know 
				which part is causing an issue.