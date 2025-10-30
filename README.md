# NewRepoProject3

Observer pattern:
The road only generates when the player reaches the appropriate distance in which they need to see more road. The player has a delegate that only invokes when it reaches a certain distance. The road manager observes this delegate to create more road and delete old road when the player reacches their milestone. 

States:
The player has a driving state and a dry state. The player starts in the driving state which consumes fuel while they move. When the player runs out of fuel, they switch the the dry state which slows them down until they stop moving. The player manager has no olgic other than managing the logic of handling states, all of the players input and control is handled within the driving state. All player states inherit from a base PlayerState, so the player manager does not even need to know which states it currently has. 
