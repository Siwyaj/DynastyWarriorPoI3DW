
# Dynasty Warrior but worse
## Programing of interactive 3d worlds mini-project rapport
Project name: Dynasty Warriors but worse

Name: Jesper Soelberg Jensen

Student number: 20193809

Link to project: https://github.com/Siwyaj/DynastyWarriorPoI3DW 

### Overview of the game
This project is loosely based on the game dynasty warriors.
Dynasty Warriors is a game where you, the player, control a leader of a dynasty going into battle with your army behind you fighting enemy armies and leaders, trying to capture positions.
Likewise in this project, you, the player, will control a knight and have an army fighting with you in battle against the goblin army
All character has the ability to move and attack, with the player dealing more damage than minions, to reduce enemy health and eliminate them.
The goal of the game is to fight through the enemy army and get to their castle to take it over whilst being careful your own castle isn't being taken by other enemies.

### The main parts of the game are:
The Player - a knight wielding a sword, controlled with WASD and mouse

3rd person camera - rotating with mouse movement

Enemy minions - Goblins seeking to take your castle and eliminate you and your army

Ally minions - attacking the nearest enemies


The Battlefield - a giant green plane

Castles - Spawnpoints for the controlling team

### Game features:

Combat

Attacks

Health

Animations

walking

attacking

idle

### Project parts
**Scripts**

Player scripts:

Movement - A simple script for moving forward, back, left, and right.

Camara Movement - handles the movement of the camera, this was actually a bit triggier than initially thought and was changed many times as seen in the time management. This was because, in the end, the desired position for the camera should be behind and a bit to the right of the player. this resulted in when turning a bit of math was applied to rotate around and offset it properly in relation to the player. The player should also rotate the same amount as the camera so the character always looked forward.

Animation state Controller - A script which uses the same inputs as movement to trigger different animations. The script also takes mouse button 1 as input to do both the attack and the attack animation. The attack is an instantiation of a hitbox object as a child, which has its own script handling damage dealt.

Enemies and allies:

Ally and Enemy Behavior - controls what the ally/enemy does. It finds the nearest Enemy/ally and uses Navmesh to move towards it. When the ally/enemy gets close enough it attacks

Stats - keeps track of the Ally/enemy's health

GameControllers:
Settings - keeps options like sensitivity, had the intent of storing more settings in here like damage and speed.

Spawn enemy - spawn minions for whoever controls the castle.

Who controls the castle - Log enemies and allies entering and exiting the castle's zone, whoever has the majority will begin to capture the castle if they do t own it. Capturing it changes the colour of the zone and changes what the spawn enemy script spawns.

Others:

Hitboxes - 3 different ones for the player, allies and enemies. the all function basically the same. Another script initialises the hitbox and it then proceeds to rotate around the player. An OnTriggerEnter handles dealing damage to anything in the hitbox’s path. For each team, the Collison will first check for a “Good” or “enemy” tag as to avoid friendly fire. Then it will deal damage with the player dealing more than the minions.

**Prefabs and other models**

Attack Hitboxes for each character-
Player character,
Goblins,
Allies.

Goblins models and animation

Allies models and animation

Player character model and animation -
With sword

**Material/Texture**
Plane texture - A green colour to visualize grass on a battlefield

Point colours - two fade materials; blue and red for each their own team

The Goblins, the knights, and the castles all came with their own materials and texture.

**Scene**
Main scene - Also called sample scene, is the scene where the battle takes place

YouWon scene - Just a simple scene with a text telling the player they won and that they can press ESC to close the game.


### Time Management

| Task          | Time(hours)   |
| ------------- | ------------- |
| **Programming**  | 1  |
| Player movement  | 2  |
| Camara movement  | 1  |
| Player attack  | 4  |
| Ally/enemy behaviour like attacking and moving  | 3  |
| Castle capture mechanics  | 2  |
|   |   |
| **Unity**  |  |
| Finding and implementing models  | 0.5  |
| Animation  | 2  |
| Texture  | 0.25  |
| Navmesh  | 0.5  |
| Placing objects  | 0.5  |
|   |   |
| **Other**  |   |
| Ideation  | 0.5  |
| Github  | 0.25  |
| Rapport, presentation and readme  | 1  |
| testing  | 1  |
|   | |
| Total  | 19.5  |

### Used Resources
Animation and models with texture for Goblins, allies, and player characters - https://www.mixamo.com/ 

Claymore for player character - https://sketchfab.com/3d-models/claymore-17446286237f49c49594b171cd58b302 

Castle model with texture -https://assetstore.unity.com/packages/3d/environments/medieval-castle-227378 

Navmesh Tutorial - https://www.youtube.com/watch?v=CHV1ymlw-P8 
