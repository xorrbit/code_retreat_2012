window.Life = class Life
  constructor: ->
    @aliveCells = []
  # [[0, 1], [0, 2]]
  genesisAt: (x, y) =>
    @aliveCells.push [x, y]
  evolve: =>
    @aliveCells = [[1, 2]]
    this
  isAliveAt: (x, y) =>
    @aliveCells.some (cell) -> cell[0] == x and cell[1] == y
