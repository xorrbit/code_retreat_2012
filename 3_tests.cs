describe "Game of Life", ->
  describe "Cell", ->
    it "should construct properly given cell is alive", ->
      cell = new Cell(true, 5)
      expect(cell.isAlive()).toBe(true)
      expect(cell.numberOfLiveNeighbors()).toBe(5)
    it "should construct properly given cell is dead", ->
      cell = new Cell(false, 6)
      expect(cell.isAlive()).toBe(false)
      expect(cell.numberOfLiveNeighbors()).toBe(6)
  describe "Rules", ->
    describe "Any live cell with fewer than two live neighbours dies, as if caused by under-population.", ->
      it "has 1 neighbor", ->
        cell = new Cell(true, 1)
        expect(cell.willBeAliveNextTick()).toBe(false)
      it "has 0 veighbors", ->
        cell = new Cell(true, 0)
        expect(cell.willBeAliveNextTick()).toBe(false)
    describe "Any live cell with two or three live neighbours lives on to the next generation.", ->
      it "has 2 neighbors", ->
        cell = new Cell(true, 2)
        expect(cell.willBeAliveNextTick()).toBe(true)
      it "has 3 neighbors", ->
        cell = new Cell(true, 3)
        expect(cell.willBeAliveNextTick()).toBe(true)
    describe "Any live cell with more than three live neighbours dies, as if by overcrowding.", ->
      it "has 4 neighbors", ->
        cell = new Cell(true, 4)
        expect(cell.willBeAliveNextTick()).toBe(false)
    describe "Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.", ->
      it "has 3 neighbors", ->
        cell = new Cell(false, 3)
        expect(cell.willBeAliveNextTick()).toBe(true)
      it "has 4 neighbors", ->
        cell = new Cell(false, 4)
        expect(cell.willBeAliveNextTick()).toBe(false)
      it "has 2 neighbors", ->
        cell = new Cell(false, 2)
        expect(cell.willBeAliveNextTick()).toBe(false)
  describe "Board class", ->
    describe "evolve()", ->
      it "empty board should evolve into empty board", ->
        board = new Board([])
        expect(board.evolve().compare(new Board([]))).toBe(0)
      it "board with one cell should evolve into empty board", ->
        board = new Board([1, 1])
        expect(board.evolve().compare(new Board([]))).toBe(0)
      it "board with single blinker should blink", ->
        board = new Board([1, 1], [1, 2], [1, 3])
        expect(board.evolve().compare(new Board([0, 2], [1, 2], [2, 2]))).toBe(0)
      it "board with single blinker in opposite start state should blink", ->
        board = new Board([0, 2], [1, 2], [2, 2])
        expect(board.evolve().compare(new Board([1, 1], [1, 2], [1, 3]))).toBe(0)
      it "board with single block still life will evolve into same", ->
        board = new Board([1, 1], [1, 2], [2, 1], [2, 2])
        expect(board.evolve().compare(new Board([1, 1], [1, 2], [2, 1], [2, 2]))).toBe(0)
    describe "cellAt()", ->
      it "should generate a cell from a static board", ->
        board = new Board([1, 1], [1, 2], [1, 3])
        cell = board.cellAt(1, 2)
        expect(cell.isAlive()).toBe(true)
        expect(cell.numberOfLiveNeighbors()).toBe(2)
    describe "constructor", ->
      it "retains seed state", ->
        board = new Board([1, 2])
        expect(board.isAliveAt(1, 2)).toBe(true)