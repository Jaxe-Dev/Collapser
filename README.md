# Collapser
![Mod Version](https://img.shields.io/badge/Mod_Version-1.8-blue.svg)
![RimWorld Version](https://img.shields.io/badge/Built_for_RimWorld-1.6-blue.svg)
![Harmony Version](https://img.shields.io/badge/Powered_by_Harmony-2.3.6-blue.svg)\
![Steam Downloads](https://img.shields.io/steam/downloads/1499847220?colorB=blue&label=Steam+Downloads)
![GitHub Downloads](https://img.shields.io/github/downloads/Jaxe-Dev/Collapser/total.svg?colorB=blue&label=GitHub+Downloads)

[Link to Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1499847220)\
[Link to Ludeon Forum thread](https://ludeon.com/forums/index.php?topic=43486.0)

---

Remove overhead mountains on collapse as long as there is non-overhead mountain roof next to the collapse.

Without this mod there is no way to remove overhead mountain, no matter how many times it collapses it does not go away. With this mod if an overhead mountain roof collapses and there is a non-overhead roof on a tile directly adjacent to it then the overhead mountain will be removed.

While there are other mods that enable removing overhead mountains manually like normal roofs, this mod restricts it to only edges of mountains so you could technically remove a whole mountain as long as you start from the edge and work inwards.

---

##### STEAM INSTALLATION
- **[Go to the Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=1499847220) and subscribe to the mod.**

---

##### NON-STEAM INSTALLATION
- **[Download the latest release](https://github.com/Jaxe-Dev/Collapser/releases/latest) and unzip it into your *RimWorld/Mods* folder.**

---

The following base methods are patched with Harmony:
```
Prefix* : Verse.RoofCollapserImmediate.DropRoofInCellPhaseTwo
```
*A prefix marked by a \* denotes that in some circumstances the original method will be bypassed*
