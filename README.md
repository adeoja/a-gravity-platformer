# 3D Platformer - Gravity Manipulation Game

A 3D Unity platformer prototype featuring unique gravity-manipulation mechanics where players can walk on ceilings and navigate challenging obstacle courses.

> **Play the game here:** [Link to game]

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
- **Language:** C#
- **Physics:** Unity Physics System
- **UI:** TextMeshPro

---

## 🚀 Setup Instructions

1. Clone the repository
   ```bash
   git clone [your-repo-url]
   ```

2. Open the project in Unity 6000.0.56f1 or later

3. Open the main scene

4. Assign required references in the Inspector:
   - Player references (Rigidbody, Animator, transforms)
   - Camera reference to player
   - UI elements (TextMeshPro components)
   - Prefabs (bullet prefab)

5. Configure the following tags:
   - `Ground`
   - `Ceiling`
   - `Obstacle`
   - `Checkpoint`
   - `Tutorial Trigger`

6. Press Play to test

---

## 🎯 Core Features Showcase

### Gravity Manipulation
The unique selling point of this game - players can invert gravity to walk on ceilings, opening up vertical level design possibilities.

### State Machine Implementation
Clean, maintainable player controller using FSM pattern, making it easy to add new states or modify existing behaviors.

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

## 👤 Developer

Created as a portfolio piece demonstrating:

- Unity engine proficiency
- C# programming skills
- Game design patterns knowledge
- Physics-based gameplay implementation
- Clean code practices

---

## 📄 License

This project is available for educational and portfolio purposes.

---

**Note:** This is a work-in-progress portfolio project showcasing game development fundamentals and Unity engine capabilities.
