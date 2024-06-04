# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

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

[unreleased]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.4...HEAD
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
