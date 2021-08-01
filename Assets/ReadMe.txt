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
				
* Frame
	- A game must interact with a computer central processing (CPU) and the graphics processing unit (GPU).
		CPU: the chip that executes instructions in a computer program. It performs arithmetic, logic, system, control and input output operations.
			The fundamental components of a CPU include a:
				1) Control unit that coordinates the movement of data between the Algorithmic Logic Unit (ALIYU) that performs operations and
					the registers that store the values used by the ALIYU
			
		GPU: specifically designed to manipulate and accelerate the processing of images. It provides better and faster graphical experiences.
		     It contains eight components:
				1) Graphics memory controller that controls the flow of data between the chip and the chips memory and processing
				2) VGA bias, that contains firmware to initialize the chip
				3) Graphics and compute array that performs the arithmetic operations and runs shader code on images
				4) BUS interface for transporting data between the chip and other computer components
				5) Compression unit to move data from memory to the array for processing
				6) Power management unit
				7) Video processing unit to deal with moving image dat in video files such as MPEG
				8) Display interface that communicates data from the chip to the equipment displaying the graphics
		Both of these chips are equally as important in prodcing the frames from a computer game.
		
		The CPU processes the game engine components, your code and calls the renderer, which then passes control to the GPU that produces the image 
		you finally see on the screen.
		
	- The CPU must complete all of the things it has to do before the GPU will start drawing the frame. If the CPU and GPU can finish their tasks
	  in the time you allocate for one frame, then the desired frame rate will be achieved. However, if they can't be completed in time, the frame
	  time will get longer and the frame rate will go down.
	  
	- How long should you allocate for a frame? How to determine how much of the frame the CPU gets and how much the GPU gets?
		In the case of GPU: 
			If a frame runs at 60 FPS, then anything that takes up half of this would be running at a speed of 120 FPS, and anything at a quarter would be
			running at 240 FPS. If you cycled them back to back, you will get 240 of them in a second.
		In the case of CPU:
			When cycle back to back you will get 80 FPS, which means at half this will be running at a speed of 40 FPS and etc.
			
		To calculate these you take the number of FPS and divide them by the percentage.
			For example:
				60/0.75 = 80FPS
				
		To make the calculation easier is by working with miliseconds.
		60 FPS = 1000 miliseconds
		1 FPS = 1000 / 60 = 16 miliseconds
		For example, if the CPU takes 75% of frame, it will take 12 miliseconds to complete and the GPU 4 miliseconds to complete.
		So, when the CPU and GPU finish what they both need do to within the frame time allocatio, you will hit the desired FPS
		
		When the CPU and GPU does not finish their tasks on time:
			1)  The CPU takes longer to complete its turn, and then the GPU wait for it before it begins his tasks and that will push the time for
			    that frame out. As a frame takes up more miliseconds, the frame rate decreases.
			    For example: 
					CPU pushed the frame out to 25 miliseconds instead of 16. This will result in a frame rate of 1000/25 = 40 FPS
			    This will get a lot of underutilized GPU time and the CPU will cause a bottleneck. This is called CPU BOUND APPLICATION
			   
			    The same thing goes for the GPU. If the GPU tasks time delays, then the CPU needs to wait and that is called GPU BOUND
			  
				Examples:
					How long in FPS will the CPU be running if it takes up 30% of a 60 FPS frame? -> 60/0.3 = 200 FPS
					How long in FPS will the GPU be running if it takes up 40% of a frame that runs at 120 FPS? -> 120/0.4 = 300 FPS
					How long does each frame take in an application running at 120 FPS? -> 1000ms/120 = 8ms
					How long does each frame take in an application running at 30 FPS? -> 1000ms/30 = 33ms
					With a single frame length of 10ms, with the CPU taking up 8ms, how much time does the GPU take?
						It is hard to answer because we might not be sure just how much time the GPU takes, because the CPU and GPU combined
						dont have to take up the amount of allocated freespace. They might run with less or with more added to this.
						They can also run in parallel and overlap as many processors will.
						While calculating the exact length, it might not be entirely accurate, but here some things to know:
							- it is most likely the CPU is going to start running before the GPU for at least a small amount of time
							- If you are looking for a frame length of 16ms and both the GPU and CPU takes 16ms, its more likely that the frame rate will suffer
			2) V-Sync(Vertical Sync) - it forces a sync between the refresh rate of the monitor and your game. Essentially, it makes sure that
			                           your code has finished doing all the work it needs to do before it draws a frame.
									   Example: screen tearing, which happens when the new frame to be drawn is not completely ready while the monitor is ready
									   How does it affects the frame rate? 
											- Monitors run in either 60 or 120 hertz, which is the same as saying frame rate (FPS)
											- If the game cycle runs over the six miliseconds into the next frame, the V-Sync will wait until a new refresh.
											  If you have a 60 Hertz monitor and are aiming for 60 FPS (16 ms), but the code pushes it out to 22ms, you will
											  not get 45 FPS, but 30 FPS.
											- If you are trying to draw each 16ms and dont make it, the monitor will render the same frame again. That means,
											  you get two frames of exactly the same thing rendered. So in one second, you end up with half as many
											  new images, and that essientally drops your frame rate in half.
									   The longer it takes to process a frame, the less frames you can fit into a second