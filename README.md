# NewRepoProject3

WASD to move!

Observer pattern:
The road only generates when the player reaches the appropriate distance in which they need to see more road. The player has a delegate that only invokes when it reaches a certain distance. The road manager observes this delegate to create more road and delete old road when the player reacches their milestone. 

States:
The player has a driving state and a dry state. The player starts in the driving state which consumes fuel while they move. When the player runs out of fuel, they switch the the dry state which slows them down until they stop moving. The player manager has no olgic other than managing the logic of handling states, all of the players input and control is handled within the driving state. All player states inherit from a base PlayerState, so the player manager does not even need to know which states it currently has. 

Dirty:
The player manager checks if the "highscore dirty flag" should become dirty only if it is not already dirty. When the player runs out of fuel, if the flag is set to dirty, the system knows to update the highscore by writing to PlayerPrefs. Writing to PlayerPrefs may be swapped out with writing to an encrypted file in a larger game, which is an operation expensive enough to warrant checking before doing. The dirty flag means that the highscore is only written to if its needed. 

Object pooling:
Previously, the above observer pattern destroyed and instantiated roads when a player reached a milestone. Now, roads that would be destroyed are set inactive and added to a separate "pool stack". If the stack has a road available, that road is then used and set active instead of instantiating a new road whenever needed. If the stack is empty when a new road is needed, a fallback case exists to instantiate the first few roads. 

I feel that each implementation of these patterns are accurate to the pattern and an effecient application of the pattern. 
