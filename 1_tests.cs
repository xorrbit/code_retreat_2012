describe "Conway's Game of Life", ->
  describe "produces the following transitions", ->
    it "dies by under-population", ->
      life = new Life()
      life.genesisAt(1, 1)
      expect(life.isAliveAt(1, 1)).toBe(true)
      expect(life.evolve().isAliveAt(1, 1)).toBe(false)
    it "lives with 2 neighbors", ->
      life = new Life()
      life.genesisAt(1, 1)
      life.genesisAt(1, 2)
      life.genesisAt(1, 3)
      expect(life.isAliveAt(1, 1)).toBe(true)
      expect(life.isAliveAt(1, 2)).toBe(true)
      expect(life.isAliveAt(1, 3)).toBe(true)

      life = life.evolve()
      expect(life.isAliveAt(1, 2)).toBe(true)
    it "lives with 3 neighbors", ->
      life = new Life()
      life.genesisAt(1, 1)
      life.genesisAt(1, 2)
      life.genesisAt(1, 3)
      life.genesisAt(2, 2)
    
      life = life.evolve()
      expect(life.isAliveAt(1, 2)).toBe(true)
      
      
