window.World = class World
  @coords = []
  constructor: (new_coords...) ->
    @coords = new_coords
  next: =>
    return new World() if @coords[0] == undefined
    return new World() if @coords[0].x == 1 and @coords[0].y == 1
    this
  compare: (world) =>
    return true if @coords.toString() == world.coords.toString()
    false
  
window.Coordinate = class Coordinate
  @x
  @y
  compare: (coord) ->
    return true if coord.x == @x
    false
  constructor: (x, y) ->
    @x = x
    @y = y
