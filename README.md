# 3DPlatformer

Gravity Platformer Game
This prototype was made for an assignment where we were supposed to implement third person character with animations and 3 moving parts (e.g. platforms, bullets, etc). For my project, I made a 3D Unity platformer featuring  gravity-manipulation mechanics where players can walk on ceilings and navigate challenging obstacle courses.

Play the game here: 

🎮 Gameplay Features

Core Mechanics
Gravity Flip Ability: Toggle gravity to walk on ceilings and reach new areas
Third-Person Camera: Smooth orbital camera with mouse controls
Combat System: Raycast-based shooting with crosshair targeting
Checkpoint System: Progressive checkpoint saving for quick respawns
Moving Platforms: Dynamic platforms triggered by player progression
Tutorial System: Context-sensitive hint displays to guide players

Controls

WASD - Movement
Mouse - Camera control
Space - Jump (works on both ground and ceiling)
Z - Toggle gravity ability
Left Click - Shoot

🏗️ Technical Architecture
Design Patterns

Finite State Machine: Clean state management for player controller
Singleton Pattern: Global access for core managers (GameManager, UIManager, CheckpointSystem)
Component-Based Design: Modular scripts for easy maintenance and iteration

Key Systems
Player Controller
Implements a Finite State Machine with 5 states:

Idle
Run
Jump
Gravity Ability (ascending)
On Ceiling (inverted gameplay)

Features include:

Camera-relative movement
Physics-based jump mechanics
Smooth state transitions
Animation integration

Checkpoint System

Automatic checkpoint detection based on level progression
Position-based checkpoint ordering (z-axis)
Respawn functionality on obstacle collision

Camera System

Third-person orbital camera
Configurable distance, height, and rotation limits
Smooth mouse-based rotation
Look-at offset for better player framing

Project Structure
Scripts/
├── PlayerController.cs      # Main player logic and state machine
├── CameraController.cs       # Third-person camera system
├── GameManager.cs            # Score tracking and level management
├── CheckpointSystem.cs       # Respawn point management
├── UIManager.cs              # Tutorial hints and UI displays
└── MovingPlatform.cs         # Dynamic platform movement

Unity Version: 6000.0.56f1

Note: This is a work-in-progress portfolio project showcasing game development fundamentals and Unity engine capabilities.




