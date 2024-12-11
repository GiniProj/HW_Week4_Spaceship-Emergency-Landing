# Spaceship Emergency Landing
**A Unity-based physics game about precise spacecraft landing**

[**Play on Itch.io**](https://kg-proj.itch.io/spaceshipemergencylanding)

<img src="GamePicture.png" alt="Spaceship Emergency Landing Gameplay" width="400" height="200">

## Description
Spaceship Emergency Landing is a challenging physics-based game where players must carefully navigate and land their spacecraft in designated landing zones while managing velocity and avoiding obstacles. Test your piloting skills across three increasingly difficult levels!

## Game Features
- Physics-based spacecraft controls
- Multiple landing zones
- Velocity-based landing mechanics
- Progressive difficulty across 3 levels
- Obstacle avoidance challenges

## Gameplay Mechanics
- Successfully land by keeping your velocity below the safe threshold
- Navigate through increasingly complex environments
- Avoid collision with obstacles and non-landing zones
- Master precise control of your spacecraft

## Controls
- Up Arrow - Apply thrust
- Left/Right Arrows - Rotate spacecraft
- Careful thrust management is key to safe landing

## Technical Implementation
The game features several key components:
- `LandingPhysics.cs`: Handles spacecraft movement and physics
- `CollisionHandler.cs`: Manages landing success/failure conditions
- `GoToNextScene.cs`: Controls level progression
- `Spaceship.cs`: Core spacecraft functionality
- `StartLandingPoint.cs`: Initial positioning system

## Installation
1. Clone this repository:
```bash
git clone https://github.com/GiniProj/HW_Week4_Spaceship-Emergency-Landing.git
```
2. Open the project in Unity 2022.3.7f1 or later
3. Load the starting scene and press Play

## Development
Built with Unity and C#, featuring:
- Rigidbody-based physics system
- Scene management for level progression
- Collision-based victory/failure conditions
- Input system for precise controls

## License
This project is licensed under the MIT License.