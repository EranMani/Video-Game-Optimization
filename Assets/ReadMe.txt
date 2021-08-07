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
									   
* Performance Budget
	- The performance budget is what you are going to use to determine how well your game is running, and exactly where you need to focus your 
	  attentions with respect to optimization. Just knowing if you have got performance issues with the CPU and GPU is not enough to perform the 
	  optimization cycle. When you have budget determined, you can now focus efforts on the essential subsystems and easily see where you are 
	  going to have to make changes to your allocations
	- With the informatio above, we can determine how to carve up a frame and allocate enough of it for each of the subsystems. With these in mind,
	  we can determine a performance budget (An example budget table will be shown as an image in the Assets folder)
	- Subsystems are:
		1) Rendering
		2) Physics
		3) Sound
		4) Gameplay
		5) Miscellaneous
	- The budget table will list each of the subsystems and the time per frame that you want to allocate to each, given how many FPS you want 
	  your game to run at. 
	- Memory items should also be included in the budget table. This will determine the amount of memory needed in case the algorithm is modified to
	  run faster but use up more memory. You need to make sure that you actually have enough memory to run that (Memorisation)
	- Hardware: Time allocations for the CPU and GPU will depend on the frame rate you are targeting. This will depend on the type of hardware you need
				to run the game. The amount of memory is also based on hardware.
				Mobile devices for example will have a slower frame rate to that of the console, and it will also have less memory. Also, on mobile
				devices the V-Sync is actually locked to be turned on all of the time.
	- Because of different hardwares, when creating a performance budget, you have to put together two budgets:
		1) For high-end machines (with the maximum system requirements for the game)
		2) For low-end machines (with the minimum system requirements for the game)
	- In case the project will be cross-platforms, it will force to create a budget for each one of those  platforms with high and low end specifications
	- When project is cross-platforms (targeting numerous operating systems) you need to have all of these devices available to run benchmarks on them for
	  low-end and high-end versions. When declaring the minimum and maximum system requirements of the game, you should have the machines with these specs
	  to test in order to promise the users that the game can actually run on a minimum spec hardware
	  
* Unity profiler
	- The profiler will reveal all of the components and their frame allocation amount
	- Project Build: When optimizing, you don't want to optimize the game from the editor scene. The editor itself adds overhead to your performance, 
	  so you are not actually getting a true representation of the thing running. Instead, you can make a build of the project and then link up the 
	  profiler to that in order to actually run it on the machine (hardware) that you want to test it on.
	  In order to hook the profiler to the build, you go to the build settings and check:
		* Development Build
		* Autoconnect Profiler
		* Deep Profiling Support
	  Keep the Unity scene open and open the build game. In the profiler, you can switch between the connected devices. When the build game runs,
	  the profiler will be active and will show the results.
	  NOTE: Make sure that the devices are on the same WIFI network in order for you to be able to find them
	- In the profiler you can filter between the components of each subsystem in order to micro-test each component
	- Below there is a timeline which shows the components and from there we can actually target down what is taking up a lot of time to process
	- In the timeline you can see how much miliseconds it took to allocate all the components in the specific frame
	- We can switch the timeline into hierarchy mode. A list will show up which will show you what is taking up time in a frame based on particular
	  profile markers:
		* EditorLoop -> Will be shown only when you are running the profiler with the editor. The editor itself has to run because its actually
						an application which is taking up resources that might be affecting your performance. Take that into consideration that your game
						is not actually going to incur any of this editor loop stuff. If you want to get rid of it, you can run the profiler standalone
						menu which can be outside of the editor
		* PlayerLoop -> Important one. This is where the script is getting called from. 
							COLUMNS
								- Total: The total amount of time Unity spent on a particular function, as a percentage
								- Self: The total amount of time Unity spent on a particular function as a percentage, excluding the time Unity spends calling sub-functions
								- calls: Indicating how many times in a frame the shown methods are called.
								- GC Alloc: How much scripting heap memory Unity has allocated in the current frame. The scripting heap memory is
											managed by the garbage collector
								- Time ms: The total amount of time Unity spent on a particular function, in milliseconds
								- Self ms: The total amount of time Unity spent on a particular function, in milliseconds, excluding the time Unity
								           spends calling sub-functions
								- Warning: Displays how many times the application has triggered a warning during the current frame
								
							METHODS
								- Gfx methods in list: Indicating the wait time between the CPU and GPU
								- Update.ScriptRunBehaviourUpdate: Relate to the Update methods inside the scripts that are called in the frame. Open the
																   stack to see all of the Update methods that are being called
																   Inside the parent, there is a group called -BehaviourUpdate- which shows all the scripts
																   that are running the Update method
																   NOTE: Once you have got a full game with a whole bunch of different objects, if they
																		 all got their Update methods on them and they are not using them, they are still
																		 being called. So, its a good practice to get rid of them altogether
																   
							HOW TO USE
								- When going through the list, mark the methods that have a value above 0% which may impact performance and check there
								- Dig around the hierarchy within these methods to reveal the amount of calls that are going on inside
	- Threads: Unless using the job system, pretty much all of your code is going to be on the main thread. We can see a list of all the different threads 
	           that you can have, and Unity have ones that its going to use for some parallel processing within the engine. The job worker threads referring
			   to the job system if you were going to implement that
	- Profile marker for the GPU can be found in the list of threads under the name RENDER THREAD. Just like the CPU in the main thread, the Render Threads
	  also have its relevant markers. In the Render Thread, the GPU usage is hidden under
		** Gfx.WaitForGfxCommandsFromMainThread/Semaphore.WaitForSignal -> that means that the CPU is having a little bit of snooze, because its waiting
																		   for the GPU to finish. So basically, that signals when the drawing is happening,
																		   the CPU is not doing anything at all
																		   
***************************************************************************************************************************
-------------------------------------------------------------------------------------------------------------------
----------------------------------------------Subsystems Optimization----------------------------------------------
-------------------------------------------------------------------------------------------------------------------

------------------------------------------------ Optimizing Script ------------------------------------------------
* Get Component
	- Often you will want to get a component when your script needs to access on of the components you have added to something
	- There are 3 ways to call get component:
		1) GetComponent<T>() -> GetComponent<Transform>()
		2) GetComponent(string) -> (Transform) GetComponent("Transform")
		3) GetComponent(typeof(T)) -> (Transform) GetComponent(typeof(Transform))
		
		With Unity version of 2020.1.2f1, the second GetComponent call is the fastest to complete
		When using different Unity versions, we can run all three of these GetComponent calls and check each Time ms it takes to complete the calls
		and use the faster one for the project.
		Now, why is this call (Transform) GetComponent("Transform") is the fastest? if we open the stack in the profiler (click the down arrow),
		we can see the process it takes for Unity when calling that methods. When Unity calls (Transform) GetComponent("Transform"), it does it
		with less processes then the other two.
		
		Other comparable calls might be -
			Find object by tag or name -> GameObject.FindGameObjectWithTag() VS GameObject.Find()
			Using gameObject itself is redundant and implies an extra access. Instead can use 'this'
			
* Caching VS Dynamic Finds
	- Caching: getting a hold of any of your game objects or other assets that you want to use in your game. Instead of getting a hold on them
			   dynamically every frame, we can store them in memory so that we can access them at all times. The variable that will hold the object
			   will be global and will run only once, in the Start() method. 
			   Another example is to initialize the variable with the amount of objects it needs from the start, and then set or get information
			   on them, instead of using GameObject.Find(), which is expensive
			   
	- Finding objects or components are happening many times within a game environment. The idea is to strive and do these tasks as little as possible
	- These tasks shouldn't be running insdie the playerLoop, which means the Update method, maybe Fixed Update or Late Update. Therefore, you have
	  to use them very sparingly
	- A GameObject.FindObjectsOfType<Transform>() is a generic way of finding objects with the same type as the T. It will go through all the 
	  objects in the hierarchy and check if they have the same type or component attached. This takes alot of resources and shouldn't run in the 
	  Update method. It is not something you should do in your game environment as such
	  
	- Populate object in inspector VS find object dynamically in code: Exposing the object in the inspector is very efficient because you are not 
																	   trying to populate them dynamically, which might look clever, but when it comes 
																	   down to performance, its a really bad idea
																	   
	- NOTE: when working with a component, we should to hold that component directly instead for instance to create a game object and then
	        call its transform. For example, we want to move tank objects with Translate direction:
				public GameObject[] tanks; -> Instead of calling the game object itself and call its transform 
				public Transform[] tanks; -> Cache the transform of the object directly and then access it whenever needed
			Same goes for other components. If you want to change the material color of 100 tank objects then you should not cache the game object itself,
			rather cache the material component directly and access it at all times
			So, caching should happen once, in the Start() method. Then in the Update() method we can use the variable that is caching the information,
			and do something with it.
			
	- NOTE: In case of trying for example to move an object using Translate and you have 100 of them, if you run the code individually on each object
			or run it in one place where we have a loop that runs for all the 100 objects, the amount of Time ms in the profiler is almost the same. 
			You should always try and experiment to see how each code designs affect the performance and choose the one that works the best.
			
* Spread Loading Time
	- In case of running 100 objects which process movement every frame, we can try and spread their movement 
		Example: InvokeRepeating("FollowPlayer", Random.Range(0f, 1f), 1) -> Run the method every second for a period of time. You can see in the 
				 profiler that spikes are not evenly spaced, but spread acrossed the frame and that can help increase the FPS a bit.
	  If you see in the profiler that the spikes that you have are evenly spaced, then you should try to find a way to spread them and let the application
	  breath more from frame to frame. With the Invoke, we can invoke the method for each object in the scene at a different time.
	  
	- Coroutine: It is almost the same like using the invoke repeating method. You can choose the invoke-repeating or the coroutine, you will get
				 the same performance result more or less
				
	- NOTE: There are time when you dont have choice but to put code in the Update method, for example moving objects should happen every frame
			for them to move smoothly. You can try and apply rigidbody and add force instead, but adding physics to many object running at the same
			time in the scene will eat up the performance
			 
* Garbage Collection
	- When running any method in the Update() is placed on the stack above it.
	  First, you run Update, then it goes and sits in the stack and from there you run another method. This method will sit in the stack on top of
	  the Update()
	  Once the method is finished running, it's removed from the stack
	  Another method that will run wil be placed on the stack above the Update()
	  As you go deeper into methods inside methods, they will be placed on each other in the stack.
	  At some point the stack will overflow, if you got too many methods that have run too deep
	  
	  Now, what is happening when you run a method? The heap comes into play
	  Lets say the method runs a for loop to create amount of game objects. 
	  for(int i = 0; i < 100; i++){
			GameObject tank = new GameObject();
	  }
	  
	  The 'i' variable is stored in the heap and changed as the for loop goes around
	  Each time you create a new game object, it goes to the heap. All those 100 tanks are sitting in the heap memory.
	  Now, even when the method is done and removed from stack, any memory that was allocated in the heap is still sitting there. The local 'i' variable
	  is able to be removed, but its still sits there until the process of the garbage collection comes along and cleans it up
	  
	  Things only get marked to be deleted or picked up by the garbage collection if they are no longer used. In Unity, when it instantiated a new
	  game object, you know that that game object now exists in the hierarchy and there are other process that are accessing it, so it is not
	  going to get picked up by the garbage collection
	  When running the Destroy() method on an object, the object still stays in the heap. It just marks the object to be removed. And again, your code
	  has to wait for the garbage collector to come around, pick them up and take them away.
	  
	  Basically, you got very little control over when garbage collection occurs because that is the nature of C#
	  
	- In the Unity profiler, the garbage collector is mark with green color. The allocations for the garbage collector in the beginning is related to 
	  you and what you are doing in your code, for example create new object instances such as gameObjects, materials and more.
	  Creating new game objects while in Update() can overwhelm the system.
	  Most of the time, you dont have much control over the garbage collector actions because it may be related to Unity doing its own stuff
	  In the search bar, you can type gc.alloc to find all related calls to the garbage collection in the frame\
	  
	- Garbage is being created whenever you create new instance of something, like lists, gameObjects etc. So to avoid it, make sure you don't have 
	  alot of new things being created in memory inside anything that is going to loop a lot or anywhere inside of your Update(). Do those sorts of things
	  in the Awake() and Start()
	
	- GC.Alloc relates to the scripting side, while GC.Collect relates to the garbage collection side
	
	- C# types such as lists and strings are native to the language and therefore can be gotten rid of. However, any classes that belong to Unity
	  that are still going tobe used within Unity, they are going to go into the heap and then they are going to stay there, especially game objects,
	  because they become sort of instantiated as in a real thing inside of your game world and therefore you need to remove them but do that when you
	  don't need them
	  
	- Garbage collection is not forced to come any earlier just by calling the Destroy(). It will only mark the objects to be collected, and in the next
	  garbage collection phase they will be removed from the heap
	  
	- Destroy() will set your object to null or being empty at the end of the frames
	- DestroyImmediate() will set the game object to null at that point in the code
	
* Null Testing
	- There are 2 ways to test if something is null:
		1) if (object != null) {} 
		2) if (ReferenceEquals(object, null)) {} <-- This null checking option is way more optimized!
		
		When running these checks on a scene that generates thousands of objects, you can see that the second check option is taking much less 
		resources then the first check option, which is commonly used. 

* String As ID
	- Strings is quite expensive to use a string in place of where you could use an integer, because Unity does not use strings as such
	- If you give Unity a string, it needs to convert it into something else and then it can use it. In the profiler you can see that Unity
	  calls a method to convert the string 
	- If possible, try to pass on int's instead of string as ID, for example: 
		Input.getKey("up") <-- string is bad as ID / Input.getKey(keycode.UP) <-- pass int as an ID, which is less performance consuming
		
	- In the Unity API there are two special cases where you can easily get an integer ID instead of using a string
		1) Animator
		2) Shader and materials
		
		With the animator, we can call a static method upon an integer variable that will convert string to hash. That operation will happen once,
		in the Start() since it is going to exists in memory for the whole time rather then constantly creating it over and over again.
		
		int animRunningID;
		
		void Start(){
			animRunningID = Animator.StringToHash(action_string) -> converts the string into the internalized version that the animator already knows
		}
		
		With the shader, we can make the call to 'PropertyToID' manualy by code. 
		
		int colorPropertyID;
		void Start()
		{
			colorPropertyID = Shader.PropertyToID("_Color");
		}
		
	- Strings are easy to understand for humans, but the computer does not understand them and therefore they have to convert them from one thing
	  to another in order to use them
	  
	- NOTE: if you want to check if other classes has those methods for getting a unique identifier for the property name, you can check their 
	        static methods of that class
		
* Memory VS Performance
	- We can declare variables once to be properties of a class, which do take up more memory.
	- If you use a variable constantly all the time, it makes sense to actually put it into memory.
	- The negotiation will be:
		* Whether you want to use up MORE memory or whether you want to use up more of your PERFORMANCE time
	  
* Tag VS CompareTag
	- The CompareTag option is far better to use then Tag, because:
		1) testGameObject.tag == "Player" : the profiler shows that checking for equal tag actually perform 2 calls:
			* get_tag - get the tag itself and store it in memory, therefore using quite a bit of memory
			* string_equality - compare between two strings
		   Both of the calls are using large amount of memory and decrease performance
		2) the CompareTag has only 1 call and doesn't use memory at all, therefore it gives better performance