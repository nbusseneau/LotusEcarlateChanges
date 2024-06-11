# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Changed

- Make MonsterLabZ spiders have guaranteed fang drops, and adjust tree spiders spawns.
- Adjust Renegade Vikings weapons / shields to remove weaker options.
- Adjust Grizzly armor costs.

### Fixed

- Fix custom skills icons not working.

### Removed

- Remove MonsterLabZ frost drakes.

## [0.6.16] - 2024-06-10

### Fixed

- Fix Monstrum adjustments (oops).

## [0.6.15] - 2024-06-10

### Changed

- Adjust Monstrum creature drops to remove uncertainty on meat / leather drops.

## [0.6.14] - 2024-06-09

### Changed

- Rebalance armor costs.

## [0.6.13] - 2024-06-09

### Removed

- Remove some sail schematics from Balrond Shipyard.

## [0.6.12] - 2024-06-09

### Added

- Add RenegadeVikings with a major overhaul to functionality (including equipment and drops).

### Changed

- Rebalance various movement speed modifiers.

## [0.6.11] - 2024-06-07

### Fixed

- Fix bronze-tier items upgrades having incorrect costs.

## [0.6.10] - 2024-06-07

### Changed

- Rebalance BowsBeforeHoes quivers initial size, max quality/size, and costs.

## [0.6.9] - 2024-06-07

### Changed

- Rebalance bronze-tier items costs.

## [0.6.8] - 2024-06-06

### Changed

- Rebalance recipes for some vanilla pieces.

## [0.6.7] - 2024-06-06

### Changed

- Rebalance BalrondHumanoidRandomizer spawner changes.
- Update dependencies.

## [0.6.6] - 2024-06-05

### Changed

- Adjust armor / capes costs.

### Fixed

- Fix Clutter bucket not being properly removed from craftable items.

## [0.6.5] - 2024-06-04

### Fixed

- Fix bogus null errors in logs due to Backpacks client config synchronization timing.

## [0.6.4] - 2024-06-04

### Changed

- Adjust Monstrum's Razorback (buff) and Black Bear (nerf) spawns.
- Nerf MonsterLabZ Tree and Jumping Spiders spawns.
- Display movespeed modifier on backpack status effect icon, improve backpack status effect tooltip.

## [0.6.3] - 2024-06-03

### Fixed

- Fix BowsBeforeHoes errors on quiver equip due to being too zealous and removing non-Item prefabs.

## [0.6.2] - 2024-06-02

### Added

- Add SpeedyPaths.

### Removed

- Remove MonsterLabZ Ashlands locations and creatures.

## [0.6.1] - 2024-05-29

### Fixed

- Fix BowsBeforeHoes items crafting recipes / requirements.

## [0.6.0] - 2024-05-29

### Added

- Support for 0.218.15 (Ashlands).
- Add BowsBeforeHoes.
- Add RefinedStonePieces.

### Changed

- Interface directly with plugins via publicized assemblies rather than via reflection.
- Change SouthsilArmor armors to provide set effects with the new custom skills.
- Change round shields movement speed modifier to -10%.

### Fixed

- Fix station requirement for gravestone in Clutter.
- Fix incorrect movement speed modifiers on Vanilla and Warfare items, notably two handed weapons and war pikes.

### Removed

- Remove RtDBiomes traps removal as it's now handled by RtDBiomes itself.
- Remove PotteryBarn.
- Remove logs in More Gates as they were already covered by vanilla.

## [0.5.1] - 2024-05-07

### Fixed

- Fix crafting station requirements for Monstrum / Warfare / SouthsilArmor items.
- Fix station requirement for stone-based and metal-based pieces in Clutter and FineWoodBuildPieces.

## [0.5.0] - 2024-05-06

### Added

- Decrease movespeed based on weight when using backpack.

## [0.4.0] - 2024-05-05

### Added

- Add Workbench as requirement for Clutter pieces missing a workstation requirement.
- Double Torch durability for even more counterplay to the modpack's extremely dark nights.

### Fixed

- Fix MonsterLabZ spiders taking fall damage.
- Fix MonsterLabZ brown spider still dropping Ooze.

## [0.3.0] - 2024-05-04

### Changed

- Adjust armor recipes to use less leather from Monstrum creatures considering spawn rates.
- Adjust More Gates pieces to require additional materials (e.g. crystal for windows).
- Adjust MonsterLabZ drops to remove early game Ooze.

### Fixed

- Fix `Chieftain deer head` recipe to properly require deer trophies.

## [0.2.0] - 2024-05-01

### Added

- Double the range of fireplace and torch-like prefabs to allow counterplay to the modpack's extremely dark nights.

## [0.1.2] - 2024-04-30

### Changed

- Remove `Assembly.LoadFile` calls in order not to trigger Thunderstore submission rejection filter.

## [0.1.1] - 2024-04-30

### Fixed

- Fix Thunderstore manifest missing dependencies.

## [0.1.0] - 2024-04-30

### Added

- Initial release.

[unreleased]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.16...HEAD
[0.6.16]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.15...0.6.16
[0.6.15]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.14...0.6.15
[0.6.14]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.13...0.6.14
[0.6.13]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.12...0.6.13
[0.6.12]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.11...0.6.12
[0.6.11]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.10...0.6.11
[0.6.10]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.9...0.6.10
[0.6.9]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.8...0.6.9
[0.6.8]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.7...0.6.8
[0.6.7]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.6...0.6.7
[0.6.6]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.5...0.6.6
[0.6.5]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.4...0.6.5
[0.6.4]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.3...0.6.4
[0.6.3]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.2...0.6.3
[0.6.2]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.1...0.6.2
[0.6.1]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.0...0.6.1
[0.6.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.5.1...0.6.0
[0.5.1]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.5.0...0.5.1
[0.5.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.4.0...0.5.0
[0.4.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.3.0...0.4.0
[0.3.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.2.0...0.3.0
[0.2.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.1.2...0.2.0
[0.1.2]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.1.1...0.1.2
[0.1.1]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.1.0...0.1.1
[0.1.0]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/109c5406d49203ca632622244d1aed63f19b95e8...0.1.0
