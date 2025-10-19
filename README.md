# a gravity platformer - Gravity Manipulation Game

A 3D Unity platformer prototype featuring unique gravity-manipulation mechanics where players can walk on ceilings and navigate challenging obstacle courses.

> **Play the game here:** [[Link to game](https://adeoja.itch.io/gravity-platformer)]
>
> **Gameplay Clip:** [[Link to video]()]
<img width="1579" height="865" alt="Screenshot 2025-10-18 202928" src="https://github.com/user-attachments/assets/7a312f23-023e-4143-8159-2a5860d84679" />


## 📚 About This Project

This prototype was created for an assignment requiring:
- Third-person character with animations
- 3+ moving parts (platforms, bullets, etc.)

I expanded on these requirements by implementing a gravity-flip mechanic that opens up vertical level design possibilities.

---

## 🎮 Gameplay Features

### Core Mechanics

- **Gravity Flip Ability** - Toggle gravity to walk on ceilings and reach new areas
- **Third-Person Camera** - Smooth orbital camera with mouse controls
- **Combat System** - Raycast-based shooting with crosshair targeting
- **Checkpoint System** - Progressive checkpoint saving for quick respawns
- **Moving Platforms** - Dynamic platforms triggered by player progression
- **Tutorial System** - Context-sensitive hint displays to guide players

### Controls

| Input | Action |
|-------|--------|
| **WASD** | Movement |
| **Mouse** | Camera control |
| **Space** | Jump (works on both ground and ceiling) |
| **Z** | Toggle gravity ability |
| **Left Click** | Shoot |

---

## 🏗️ Technical Architecture

### Design Patterns

- **Finite State Machine** - Clean state management for player controller
- **Singleton Pattern** - Global access for core managers (GameManager, UIManager, CheckpointSystem)
- **Component-Based Design** - Modular scripts for easy maintenance and iteration

### Key Systems

#### Player Controller

Implements a Finite State Machine with 5 states:

1. **Idle**
2. **Run**
3. **Jump**
4. **Gravity Ability** (ascending)
5. **On Ceiling** (inverted gameplay)

**Features include:**
- Camera-relative movement
- Physics-based jump mechanics
- Smooth state transitions
- Animation integration

#### Checkpoint System

- Automatic checkpoint detection based on level progression
- Position-based checkpoint ordering (z-axis)
- Respawn functionality on obstacle collision

#### Camera System

- Third-person orbital camera
- Configurable distance, height, and rotation limits
- Smooth mouse-based rotation
- Look-at offset for better player framing

---

## 📁 Project Structure

```
Scripts/
├── PlayerController.cs      # Main player logic and state machine
├── CameraController.cs       # Third-person camera system
├── GameManager.cs            # Score tracking and level management
├── CheckpointSystem.cs       # Respawn point management
├── UIManager.cs              # Tutorial hints and UI displays
└── MovingPlatform.cs         # Dynamic platform movement
```

---

## 🛠️ Technologies Used

- **Engine:** Unity 6000.0.56f1

---

## 🎯 Core Features Showcase

### Gravity Manipulation
Players can invert gravity to walk on ceilings, opening up vertical level design possibilities.

### State Machine Implementation
Player controller uses FSM pattern, making it easy to add new states or modify existing behaviors.

### Progressive Checkpoint System
Smart checkpoint management that automatically tracks player progress through the level.

---

## 📝 Code Highlights

- **Clean Architecture** - Well-organized, commented code suitable for team collaboration
- **Scalable Systems** - Modular design allows for easy feature additions
- **Performance Conscious** - Uses appropriate Unity lifecycle methods (FixedUpdate for physics, LateUpdate for camera)
- **Best Practices** - Proper use of SerializeField, regions, and XML documentation

---

## 🔮 Future Enhancements

Potential features for expansion:

- [ ] Multiple gravity directions (not just up/down)
- [ ] Time-based challenges
- [ ] Collectible system
- [ ] Enemy AI
- [ ] Level selection menu
- [ ] Audio system integration
- [ ] Particle effects and visual polish

---

**Note:** This is a work-in-progress portfolio project showcasing game development fundamentals and Unity engine capabilities.
