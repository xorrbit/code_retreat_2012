window.Board = class Board
  @state
  constructor: (myState...) ->
    @state = myState
  isAliveAt: (x, y) =>
    @state.some (coord) -> coord[0] == x and coord[1] == y

window.Cell = class Cell
  @liveNeighbors
  @status
  constructor: (myStatus, myLiveNeighbors) ->
    @liveNeighbors = myLiveNeighbors
    @status = myStatus
  isAlive: =>
    @status
  numberOfLiveNeighbors: =>
    @liveNeighbors
  willBeAliveNextTick: =>
    return true if (@status and @liveNeighbors == 2) or @liveNeighbors == 3
    false
