# [School Project] Day&Knight
[RepoLink](https://github.com/UncleThree0402/DayAndKnight) : https://github.com/UncleThree0402/DayAndKnight

## Index
* [Assets](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets)
    * [Animation](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Animation)
    * [Input](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Input)
    * [Prefabs](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Prefabs)
    * [Scenes](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scenes)
    * [Scripts](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts)
      * [AnimatorScripts](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/AnimatorScripts)
      * [Combat](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Combat)
      * [Controller](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Controller)
      * [Interfaces](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Interfaces)
      * [InventoryScripts](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/InventoryScripts)
      * [Quest](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Quest)
      * [Scene](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Scene)
      * [StateMachine](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/StateMachine)
      * [Stats](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Stats)
      * [UI](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/UI)
      * [Weapons](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/Weapons)
    * [UI](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/UI)
  
## About
It is a action game with medieval background, in this version there are three map. <br>
Player can clear a region by eliminate enemy, if all regions are clear in a map, game will end.

## Control
Forward : Press W <br>
Backward : Press S <br>
Left : Press A <br>
Right : Press R <br>
Crouch : Press Clt <br>
Jump : Press Space <br>
Roll : Press C <br>
Run : Press RShift <br>
Attack : Press LMouse <br>
Block : Press RMouse <br>
Combo1 : Press Key1 <br>
Combo2 : Press Key2 <br>
Combo3 : Press Key3 <br>
Combo4 : Press Key4 <br>
Run : Press RShift <br>
Map : Press Map <br>
GameMenu : Press Esc <br>

## Map
![Easy](https://github.com/UncleThree0402/DayAndKnight/blob/master/Assets/UI/MapImage/mapEasy.png)

![Normal](https://github.com/UncleThree0402/DayAndKnight/blob/master/Assets/UI/MapImage/mapMedium.png)

![Hard](https://github.com/UncleThree0402/DayAndKnight/blob/master/Assets/UI/MapImage/mapHard.png)

## Scene
* Map1
* Map2
* Map3
* Credit
* GameMenu
* MapMenu
* MainMenu

## Technical

### StateMachine

#### PlayerStateMachine

##### SubState
Sub state of player state machine<br>
![PlayerStateMachineSubState](https://github.com/UncleThree0402/DayAndKnight/blob/master/Photo/PlayerStateMachineSubState.png)

##### Main State
Main state of player state machine<br>
![PlayerStateMachine](https://github.com/UncleThree0402/DayAndKnight/blob/master/Photo/PlayerStateMachine.png)

> [PlayerStateMachine](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/StateMachine/PlayerStateMachineScripts)

#### EnemyStateMachine
![EnemyStateMachine](https://github.com/UncleThree0402/DayAndKnight/blob/master/Photo/EnemyStateMachine.png)

> [EnemyStateMachine](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/StateMachine/EnemyStateMachineScripts)

#### CombatStateMachine
![CombatStateMachine](https://github.com/UncleThree0402/DayAndKnight/blob/master/Photo/CombatStateMachine.png)

> [CombatStateMachine](https://github.com/UncleThree0402/DayAndKnight/tree/master/Assets/Scripts/StateMachine/CombatStateMachineScripts)

### Interfaces

#### CharacterBehaviour
* ICanMove
* ICanRotate
* IHaveGravity
* IHealth
* IStamina
> Movement Interface

### Observer
* IObservable
* IObserver
> Design Pattern

### Stage
* IRegion
* IStage
* IStageListener
> For stage and region (Modify observer design pattern)

### UI
* ISkillBar
> Skill bar UI

### Weapon
* IHit
* IHitBox
* IWeapon
> Hit Box and weapon