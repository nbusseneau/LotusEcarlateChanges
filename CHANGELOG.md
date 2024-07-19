# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

## [0.6.37] - 2024-07-19

### Fixed

- Fix Balrond Containers comfort values.

## [0.6.36] - 2024-07-18

### Fixed

- Fix RefinedStonePieces chest and hearth piece category.

## [0.6.35] - 2024-07-14

### Fixed

- Fix Renegade Vikings item drops not working on relog / ZDO owner change.

## [0.6.34] - 2024-07-13

### Fixed

- Fix French chest tutorial.

## [0.6.33] - 2024-07-13

### Fixed

- Fix weather tutorial markup.

## [0.6.32] - 2024-07-11

### Changed

- Update RenegadeVikings to 1.2.8, but still ignore T7 vikings (Ashlands).

## [0.6.31] - 2024-07-06

### Changed

- Set Forge as required crafting station for iron firepit.

## [0.6.30] - 2024-07-06

### Added

- Add Balrond Containers.

### Changed

- Relocate some items from Misc to Furniture for consistency.

## [0.6.29] - 2024-06-24

### Added

- Double the range of Dvergr lanterns and Lava lanterns akin to torches / fireplaces.

### Fixed

- Remove bogus error logs on subsequent logins due to tutorial guidepoints already having been added on first login.
- Remove bogus warning log due to Clutter's stash book container resize.

## [0.6.28] - 2024-06-24

### Removed

- Remove fireplaces disable during day, offloaded to independent mod instead.
- Remove food slot coloring, offloaded to independent mod instead.
- Remove plant / pickable fertiziling, offloaded to independent mod instead.

## [0.6.27] - 2024-06-21

### Added

- Disable fireplaces during day to reduce fuel consumption (except campfire / hearth because comfort / cooking, and fireplaces that don't require fuel).
- Add food slot coloring based on consumed food.
- Add plant / pickable fertiziling with 3x Ancient Seeds or 1x Ymir Flesh.

### Changed

- Rebalance Monstrum foxes / razorbacks / prowlers spawns.

## [0.6.26] - 2024-06-19

### Changed

- Rebalance shields and tower shields movement speed and parry bonus.
- Change Wolf armor helmet drake trophy cost.
- Rebalance Berserkir and Grizzly armor cost.
- Rebalance MonsterLabZ dwarf goblins, wraith warrior, and deep sea serpent.
- Rebalance Monstrum monsters spawn rates.

### Fixed

- Remove Grizzly armor heat resistance.
- Remove MonsterLabZ obsidian golem (already present in Monstrum).

## [0.6.25] - 2024-06-18

### Changed

- Adjust MonsterLabZ fuling and draugr ships spawns.

## [0.6.24] - 2024-06-17

### Changed

- Rebalance stamina costs for dodging / jumping / blocking.
- Rebalance recipes using prowler fangs / lox bones.
- Rebalance saddle costs.
- Change Clutter's secret stash book container size to 1x1 and remove the public version.

### Fixed

- Fix some patches being applied more than once.

## [0.6.23] - 2024-06-16

### Changed

- Rebalance armor sets resistances and skill bonuses.
- Change weather-related Hugin tutorial to better reflect capes/clothing changes.

## [0.6.22] - 2024-06-16

### Fixed

- Fix bulk harvest on hover keyhints displaying when they should not (for real this time).

## [0.6.21] - 2024-06-15

### Changed

- Adjust when food is considered "expiring", and thus when players can eat again to replace it.

### Fixed

- Fix bulk harvest on hover keyhints displaying when they should not.
- Fix bulk harvest on hover keyhint using the wrong text for beehives.

## [0.6.20] - 2024-06-15

### Changed

- Rebalance cape resistances.
- Small adjustment to Swamp-tier armor costs.

### Fixed

- Fix `Throw` keyhint not being displayed in some instances it should be.
- Fix missing bulk harvest on hover keyhint.

## [0.6.19] - 2024-06-14

### Added

- Add new raven tutorials or edit existing ones to help with all the new stuff in the modpack.
- Add MaxAxe tweaks internal excludes to authorize throwing all bucklers and shields but deny all tower shields.

### Changed

- Rebalance tower shields movement speed reduction to be more in line with other shields, considering their drawbacks and also heavy armour being available now.
- Edit Balrond Shipyard raven tutorials.

## [0.6.18] - 2024-06-12

### Changed

- Adjust Razorbacks meat drops compared to Boars to be consistent with the Black Bears / Grizzlys duo.
- Adjust Renegade Vikings archetypes drops.

## [0.6.17] - 2024-06-12

### Changed

- Make MonsterLabZ spiders have guaranteed fang drops, and adjust tree spiders spawns.
- Adjust Renegade Vikings weapons / shields to remove weaker options, buff bows, nerf crossbow.
- Adjust Grizzly armor costs.

### Fixed

- Fix custom skills icons not working.

### Removed

- Remove MonsterLabZ frost drakes.
- Remove Renegade Vikings' War Horn and Healing Pill.

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

[unreleased]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.37...HEAD
[0.6.37]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.36...0.6.37
[0.6.36]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.35...0.6.36
[0.6.35]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.34...0.6.35
[0.6.34]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.33...0.6.34
[0.6.33]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.32...0.6.33
[0.6.32]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.31...0.6.32
[0.6.31]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.30...0.6.31
[0.6.30]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.29...0.6.30
[0.6.29]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.28...0.6.29
[0.6.28]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.27...0.6.28
[0.6.27]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.26...0.6.27
[0.6.26]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.25...0.6.26
[0.6.25]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.24...0.6.25
[0.6.24]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.23...0.6.24
[0.6.23]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.22...0.6.23
[0.6.22]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.21...0.6.22
[0.6.21]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.20...0.6.21
[0.6.20]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.19...0.6.20
[0.6.19]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.18...0.6.19
[0.6.18]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.17...0.6.18
[0.6.17]: https://github.com/nbusseneau/LotusEcarlateChanges/compare/0.6.16...0.6.17
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
