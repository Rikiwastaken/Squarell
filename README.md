# Squarell

## Done:

### Electricity
- Alimentation: Powers cables.
- Cables: Transmits electricity.
- Movable Cables: Cables that can be moved in all directions, only vertically or only horizontally.
- Pressure Plate: Power supply that is activated only when a block is on it. Also works with Alphonse.
- Doors: Acts as a wall unless powered.
- Conveyor Belt: If powered, pushes player and movable blocks. Available in all directions.
- Magnet Tile: Attracts or repels movable metallic objects when powered.

### Obstacles
- Wall: Can't walk through or pull objects on the other side.
- Seethrough: Can't walk through but can pull objects on the other side.
- Floor: Can walk on it.
- Ice Tiles: If you push an object in a direction or walk in a direction, you'll keep going in that direction until you touch a wall or a tile that isn't ice.
- One-Way Tiles: Allows movement or pushing of objects in one direction but blocks movement in the opposite direction acts like ice, except the direction is set and does not depend on the input.
- Locked Door: Alphonse must pick up a key which then can be used a single time to open a locked door.

### Interactables
- Alphonse : the joyful sexagenarian who you play as. Can move in all 4 directions and pull movables objects.
- Movables walls : walls that can be moved in all 4 directions, or only horizontaly or vertically.
- Victory Flag : A Nice flag that you have to touch in order to win the level.
- Key : Alphonse may pick up a key to open locked doors

## Todo:
- Checkpoint
- Laser
- piston
- movable that goes against the conveyor belts
- Tile that reverses electrical currents
- Tile that creates a delay in electrical currents.
- Merger Tile: Combines two electrical currents into one, but only works if both inputs are active.
- Toggle Tile: Changes state (on/off) each time it receives power, enabling complex timing-based puzzles.
- Water Tile: Blocks movement unless an object is pushed into it to create a bridge.
- Box creator or destructor
- Lava Tile: Destroys any movable object or Alphonse that touches it unless covered by a bridge object.
- Mirror Tile: laser beams in a new direction.
- Spring Tile: Launches Alphonse or objects several tiles in a specified direction when stepped on or activated.
- Wind Tile: Constantly pushes objects and Alphonse in a direction, similar to a conveyor belt but always active.
- Crumbling Tile: Breaks after a set number of uses, turning into an impassable obstacle.