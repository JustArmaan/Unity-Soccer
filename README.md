A 3D soccer game built with Unity and C# that features realistic physics, goal tracking, and controller support.

![unity-soccer-cover](https://github.com/user-attachments/assets/155e3b91-c974-4f7f-9297-fc4d4d131812)

## Overview

Unity Soccer is a 3D game that allows players to control a character, kick a soccer ball, and score goals. The game features realistic physics for both the player and ball, a score tracking system, and a continuous gameplay loop where the ball resets after each goal while the player maintains their position.

## Features

- **Player Movement**: Control your character in a 3D environment with realistic physics
- **Soccer Ball Physics**: Interact with a ball that responds naturally to kicks and environmental collisions
- **Goal Detection**: Automatic detection and scoring when the ball enters the goal
- **Continuous Gameplay**: Ball resets after each goal while the player maintains position
- **Controller Support**: Play using either keyboard or a connected game controller
- **Score Tracking**: Keep track of goals scored during gameplay

## Motivation

This project was created to explore game development using Unity and C#. It served as a learning opportunity to understand 3D physics, game mechanics, and player interactions in a game environment.

## Technical Details

- **Engine**: Unity 3D
- **Programming Language**: C#
- **Physics**: Rigidbody components for realistic movement and collisions
- **Input Handling**: Support for both keyboard and controller inputs
- **3D Modeling**: Custom-created game elements built from primitive shapes

## Development Process

1. Set up a new Unity project with a 3D template
2. Built the soccer field using a plane and surrounding walls
3. Created goal posts using smaller rectangles (custom 3D mesh work)
4. Implemented the player character with physics and movement controls
5. Added the soccer ball with appropriate physics properties
6. Created a scoring system with UI elements
7. Implemented game loop logic for continuous play
8. Added controller support for alternative input method

## Demo

Check out the gameplay demo on YouTube: [Unity Soccer Demo](https://youtu.be/rckmF3Ejz9I)

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/JustArmaan/Unity-Soccer.git
   ```
2. Open the project in Unity (version 2020.3 or newer recommended)
3. Open the main scene from the Scenes folder
4. Press Play to test the game in the editor, or build for your platform of choice

## Controls

### Keyboard
- WASD or Arrow Keys: Move the player
- Space: Kick the ball
- Escape: Pause game

### Controller
- Left Stick: Move the player
- A/X Button: Kick the ball
- Start Button: Pause game

## Future Improvements

- Add multiplayer functionality
- Implement AI opponents
- Add power-ups and special abilities
- Create additional maps/fields
- Improve graphics and add visual effects

## Contact

For questions or feedback, please reach out through GitHub or open an issue in the repository.
