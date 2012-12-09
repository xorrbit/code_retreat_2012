describe "Conway's Game of Life", ->
  describe "Rules", ->
    it "is alive, has 1 live neighbors, and so it dies", ->
      cell = new Cell(true, 1)
      expect(cell.isAlive()).toBe(true)
      expect(cell.countLiveNeighbors()).toBe(1)
      expect(cell.willBeAlive()).toBe(false)
    it "is alive, has 2 live neighbors, and so it lives", ->
      cell = new Cell(true, 2)
      expect(cell.isAlive()).toBe(true)
      expect(cell.countLiveNeighbors()).toBe(2)
      expect(cell.willBeAlive()).toBe(true)
    it "is alive, has 3 live neighbors, and so it lives", ->
      cell = new Cell(true, 3)
      expect(cell.isAlive()).toBe(true)
      expect(cell.countLiveNeighbors()).toBe(3)
      expect(cell.willBeAlive()).toBe(true)
    it "is alive, has 4 live neighbors, and so it dies", ->
      cell = new Cell(true, 4)
      expect(cell.isAlive()).toBe(true)
      expect(cell.countLiveNeighbors()).toBe(4)
      expect(cell.willBeAlive()).toBe(false)
    it "is dead, has 3 live neighbors, and so it springs to life",  ->
      cell = new Cell(false, 3)
      expect(cell.isAlive()).toBe(false)
      expect(cell.countLiveNeighbors()).toBe(3)
      expect(cell.willBeAlive()).toBe(true)
    it "is dead, has 2 live neighbors, and so it stays dead",  ->
      cell = new Cell(false, 2)
      expect(cell.isAlive()).toBe(false)
      expect(cell.countLiveNeighbors()).toBe(2)
      expect(cell.willBeAlive()).toBe(false)
  