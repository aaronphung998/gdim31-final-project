# gdim31-final-project

This repository holds a game "Ocean Runner" that is a 2D platforming game. There are four
scenes in the game: the "MainMenu", "InGame", "GameOverCrab", and "GameOverFish" scene.

After the player runs the game, the main menu is displayed. The main menu provides two
options: start and quit. If the "start" button is pressed then the player is directed to
the game, and if the "quit" button is pressed then the player quits the application. Once in
the game the player may press 'esc' at any point in time to pause. From the pause screen
the player may click on the "How To Play" button to learn the game or the "Quit" button
to quit the application.

Once the game is started, the player starts as a crab avatar that is running across the ground. The
goal of the player is to avoid obstacles and increase one's score overtime. If the player runs
into an obstacle then they will die. In the crab state the player can press space to jump. If
the player crosses a portal then they will go into the fish state. In the fish state the player
can hold the space bar to swim up and let go to swim down. If the player collects a coin
then they gain additional points. If a player collects a sea shell then they will be
invincible for four seconds. The game will go faster overtime until the player dies.

Once the player dies they are redirected to a game over screen that will match the state
they were in when they died. This screen will display the player's high score throughout
all of their runs. In this screen they will be given the option to head back to the menu
and play again or to quit the application.

There are no game breaking bugs in this application and the game should be able to run as expected.
