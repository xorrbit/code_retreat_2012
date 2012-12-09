window.Cell = class Cell
  @liveNeighbors
  @lifeStatus
  constructor: (myLifeStatus, myLiveNeighbors) ->
    @liveNeighbors = myLiveNeighbors
    @lifeStatus = myLifeStatus
  isAlive: ->
    @lifeStatus
  willBeAlive: ->
    return true if (@liveNeighbors == 2 and @lifeStatus) or @liveNeighbors == 3
    false
  countLiveNeighbors: ->
    @liveNeighbors
