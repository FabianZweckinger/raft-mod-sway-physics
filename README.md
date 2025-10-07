<div align = center>

![Banner]

[![Badge License]][License]   
![Badge Contributions]


*A **[Raft]** mod that adds simple physics to roof or wall mounted objects and allows them to sway in the swell.*

---

[![Button Demo]][Video]   
[![Button RaftModding]][RaftModding]   
[![Button RaftModdingAPI]][RaftModdingAPI]

---



</div>

## Development

*How to set up your environment.*

1.  Clone the repository.

2.  Link the cloned folder to the games mod directory.
    
3.  Change mod...

4.  Update version number in `modinfo.json`

5.  Execute `build.bat`
    to compile the project.

6.  Create PR and I will update the mod.

## How does it work
It's actually pretty simple... It mostly just sets the rotation to x = 0° & z = 0° in every frame.
```cs
public class SwayPhysicsBasic : MonoBehaviour {
    private void Update() {
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
```

When the mod is loaded, the right SwayPhysics Component just gets added to the prefabs.
```cs
...
private SwayObject[] swayObjects = 
{
    new SwayObject(SwayPhysics.Basic,
    ItemManager.GetItemByName("Placeable_Lantern_Basic").settings_buildable.GetBlockPrefabs()[1].transform.GetChild(0).gameObject,
    ...
}
...
```

## Credits
@Kasalop for fixing a bug


<!----------------------------------------------------------------------------->

[RaftModding]: https://www.raftmodding.com/mods/lantern-physics
[RaftModdingAPI]: https://api.raftmodding.com
[Video]: https://www.youtube.com/watch?v=K5NRyZBpo-k
[Raft]: https://raft-game.com


[License]: LICENSE
[Banner]: SwayPhysicsMod/banner.jpg


<!----------------------------------[ Badges ]--------------------------------->

[Badge Contributions]: https://img.shields.io/badge/Contributions-Welcome-4a7614.svg?style=for-the-badge&labelColor=68A51C
[Badge License]: https://img.shields.io/badge/License-AGPL3-015d93.svg?style=for-the-badge&labelColor=blue


<!---------------------------------[ Buttons ]--------------------------------->

[Button RaftModding]: https://img.shields.io/badge/RaftModding-3498db?style=for-the-badge&logoColor=white&logo=Wireshark
[Button RaftModdingAPI]: https://img.shields.io/badge/ModdingAPI-3498db?style=for-the-badge&logoColor=white&logo=Wireshark
[Button Demo]: https://img.shields.io/badge/Demo-E40046?style=for-the-badge&logoColor=white&logo=YouTube
