# CSC495 Lab 09 — Intelligent Enemy AI (Indoor Facility)

**Course:** CSC495 — Game Development (Fall 2026)  
**Project Folder:** `CSC495_IndoorAI`  
**Current Milestone:** **Completed through Part C (Step 35) — Before Part D**

## Project Progress
This repository currently contains the project state **completed up to Part C (before Part D)**:
- **Part A (Steps 01–07):** Unity project setup, `IndoorAIDemo` scene, project folders (`Scenes`, `Scripts`, `Models`, `Animations`, `Materials`, `Prefabs`, `Textures`, `Evidence`), Input compatibility (`Both`), AI Navigation package, and top-level Hierarchy structure (`Environment`, `PatrolPoints`, `Player`, `Enemy`, `Lighting`).
- **Part B (Steps 08–19):** Floor and wall geometry across three rooms and two corridors with open doorways, room materials, props, room identities/lighting, and colliders.
- **Part C (Steps 20–35):** Player (`Ch14_nonPBR`) and Enemy (`GirlScout`) models imported and configured with Humanoid rigs and extracted textures/materials; `Idle`, `Walk`, and `Run` animation clips configured (`In Place`, looping, root transforms baked into pose); and `PlayerAnimator` and `EnemyAnimator` controllers created with the `Speed` float parameter, states, and transitions (completed before Part D character/script/camera wiring).

## How to Get It and Open It in Unity

### Option 1: Clone with Git (Recommended)
1. Open **Terminal** or **Git Bash** where you want to store the project.
2. Clone the repository:
   ```bash
   git clone [https://github.com/saadmohammad-dev/game-lab10INTELLIGENT-ENEMY-AI.git](https://github.com/saadmohammad-dev/game-lab10INTELLIGENT-ENEMY-AI.git)

   Open Unity Hub, click Add -> Add project from disk, select the cloned folder, and open it in Unity 6 (matching the project's Unity 6 editor version).

Wait for Unity to import assets and regenerate the Library folder automatically, then open Assets/Scenes/IndoorAIDemo.

### Option 2: Download ZIP from GitHub
On the GitHub repository page, click Code -> Download ZIP.

Extract the ZIP archive to a folder on your drive (avoiding overly long paths or OneDrive sync folders).

Open Unity Hub, click Add -> Add project from disk, select the extracted project folder, and open it in Unity 6.

Let Unity finish importing/building Library on first launch, then open Assets/Scenes/IndoorAIDemo.
