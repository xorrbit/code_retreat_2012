describe "world", ->
  it "empty world generates empty world", ->
    world = new World()
    expect(world.next().compare(new World())).toBe(true)
  it "world with one cell generates empty world", ->
    world = new World(new Coordinate(1, 1))
    expect(world.next().compare(new World())).toBe(true)
  it "world with only 3 cells in a row generates 3 perpendicular", ->
    world = new World(new Coordinate(345, 888), new Coordinate(346, 888), new Coordinate(347, 888))
    expect(world.next().compare(new World(new Coordinate(346, 887), new Coordinate(346, 888), new Coordinate(346, 889)))).toBe(true)
  it "world with only 3 cells in a row does not generates empty world", ->
    world = new World(new Coordinate(345, 888), new Coordinate(346, 888), new Coordinate(347, 888))
    expect(world.next().compare(new World())).toBe(false)
