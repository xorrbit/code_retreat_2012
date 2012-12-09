window.Board = class Board
  @state
  constructor: (myState...) ->
    @state = myState.sort()
  evolve: =>
    possible_cells = []
    for coords in @state
      for xoff in [-1..1]
        for yoff in [-1..1]
          x = coords[0] + xoff
          y = coords[1] + yoff
          possible_cells.push([x, y]) if not (possible_cells.some (coord) -> (coord[0] == x and coord[1] == y))
    alive_cells = []
    for coords in possible_cells
      alive_cells.push(coords) if this.cellAt(coords[0], coords[1]).willBeAliveNextTick()
    new Board(alive_cells)
  compare: (newBoard) =>
    return @state.toString().localeCompare newBoard.state.toString()
  cellAt: (x, y) =>
    status = this.isAliveAt(x, y)
    neighbors = this.countNeighboursForCellAt(x, y)
    new Cell(status, neighbors)
  isAliveAt: (x, y) =>
    @state.some (coord) -> coord[0] == x and coord[1] == y
  countNeighboursForCellAt: (x, y) =>
    neighbours = 0
    for xoff in [-1..1]
      for yoff in [-1..1]
        neighbours++ if not (xoff == yoff == 0) and this.isAliveAt(x + xoff, y + yoff)
    neighbours

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